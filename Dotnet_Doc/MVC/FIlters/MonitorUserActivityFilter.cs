using System;
using System.Web.Mvc;
using Sacs.Core.Domain.Audit;
using Sacs.Services.Audit;

namespace Sacs.Web.Filters
{
    public class MonitorUserActivityFilter:IActionFilter
    {
        private readonly IActivityLogService _activityLogService;
        public MonitorUserActivityFilter(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;

            var actionName = (string)filterContext.RouteData.Values["action"];

            //Generate an audit
            var activityLog = new ActivityLog()
            {

                //Our Username (if available)
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                //The URL that was accessed
                UrlAccessed = request.RawUrl,
                //Creates our Timestamp
                ActivityDate = DateTime.UtcNow,
                //Action type from controller
                ActivityType = actionName,
                //What is saved for Comments column?
            };

            _activityLogService.AddActivityLog(activityLog);
            _activityLogService.SaveChanges();

        }
    }
}