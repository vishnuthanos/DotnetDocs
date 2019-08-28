//<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;


namespace httpHandler
{
    public class upload : IHttpHandler
    {
        string ServerIP = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServerIPName"]);

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = System.IO.Path.GetFileName(uploads.FileName);
            uploads.SaveAs(context.Server.MapPath(".") + "\\Images\\" + file);
            string url = "http://" + ServerIP + ":2015/Images/" + file;
            context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}