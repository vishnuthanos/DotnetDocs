using MySchool.Core.Infrastructure.Configuration;
using MySchool.Core.Infrastructure.Session;
using MySchool.Services.LogIn;
using System.Web;
using System.Web.Mvc;


namespace MySchool.Web.New.Filters
{
    public class AuthorizeTaskFilter : AuthorizeAttribute
    {

        private readonly string[] taskName;
        private readonly IAclService aclService;
        private readonly ISessionManager sessionManager;
        private readonly IApplicationSettings appSettings;

        public AuthorizeTaskFilter(ISessionManager sessionManager, IAclService _aclService, IApplicationSettings appSettings, string[] taskName)
        {
            this.aclService = _aclService;
            this.sessionManager = sessionManager;
            this.appSettings = appSettings;
            this.taskName = taskName;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (true)//appSettings.EnableSecurity
            {
                var currentUser = sessionManager.CurrentUser;
                var IsPermitted = false;
                foreach (var task in taskName)
                {
                     //Need to check user is having the specific access or not

                    if (aclService.IsPermitted(task, currentUser))
                    {
                        IsPermitted = true;
                        break;
                    }

                }
                return IsPermitted;
            }
           
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //AJAX request
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //IIS hijacks 401 and redirects user to login page even for AJAX requests
                //As a work around, set http status code to 403 Forbidden( same used for Session timeout too in basecontroller) and also send the real httpcode 401 in the message
                //Filter on the client by the code in the message to determine access denied or session timeout

                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true, httpCode = 401, message = "You do not have permissions to perform this task." }
                };

            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Unauthorized",
                };
            }

        }

    }
}