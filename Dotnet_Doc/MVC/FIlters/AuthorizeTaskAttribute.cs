using System.Web.Mvc;

namespace MySchool.Web.New.Filters
{
    public class AuthorizeTaskAttribute : FilterAttribute
    {
        public string[] TaskName { get; set; }

        public AuthorizeTaskAttribute(params string[] taskName)
        {
            this.TaskName = taskName;
        }
    }

}