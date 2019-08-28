using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace httpHandler.App_Start
{
    public class CustomhttpHandler : IHttpHandler
    {

        public RequestContext r1 { set; get; }


        public CustomhttpHandler (RequestContext rq)
        {
            r1 = rq;
        }


        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Write("hello WWE");
            context.Response.Write("<h1 style='Color:#000066'>WelCome To Custom HttpHandler</h1>");
            context.Response.Write("HttpHandler processed on - " + DateTime.Now.ToString());
            using (StreamWriter SW = new StreamWriter(@"D:\HandlerMessages.txt", true))
            {
                SW.WriteLine("The message date time is - " + DateTime.Now.ToString());
                SW.Close();
            }
        }
    }
}