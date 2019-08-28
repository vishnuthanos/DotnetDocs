using MySchool.Core.Infrastructure.Logging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MySchool.Web.New.Web.New.Filters
{
    public class HandleAndLogErrorAttribute : HandleErrorAttribute
    {
        ILogger _loggger;

        public HandleAndLogErrorAttribute(ILogger Logger)
        {
            _loggger = Logger;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    return;
            //}
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var errorSb = new StringBuilder();
            errorSb.Append("\n Controller Name: " + controllerName);
            errorSb.Append("\n Action Name: " + actionName);
            errorSb.Append("\n Error Stack Trace: " + filterContext.Exception.StackTrace);

            //Log Error
            //_loggerService.Error(filterContext.Exception.StackTrace, filterContext.Exception);
            _loggger.Error(errorSb.ToString(), filterContext.Exception);

            //AJAX request
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true, message = filterContext.Exception.ToString() }
                };
            }
            else //Normal request, redirect to Error Page
            {
                //var controllerName = (string)filterContext.RouteData.Values["controller"];
                //var actionName = (string) filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                //filterContext.Result=new ViewResult{}

                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData,
                };
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }

    }
}
