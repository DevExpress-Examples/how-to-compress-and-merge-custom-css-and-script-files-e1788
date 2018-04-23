using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using DevExpress.Web.ASPxClasses.Internal;

public partial class CssHandler : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        Response.Clear();

        // CSS
        if(Request.QueryString["cssfolder"] != null) {
            Response.ContentType = "text/css";

            string path = GetPhysicalPath(Request.QueryString["cssfolder"]);
            string[] files = Directory.GetFiles(path, "*.css");
            WriteFilesToResponse(files);
            Response.AddFileDependency(path);
        }
        else if(Request.QueryString["cssfile"] != null) {
            Response.ContentType = "text/css";

            string fileName = GetPhysicalPath(Request.QueryString["cssfile"]);
            if (Path.GetExtension(fileName).ToLowerInvariant() != ".css")
                return;
            WriteFilesToResponse(new string[] { fileName });
        }
        else // JS
            if(Request.QueryString["jsfolder"] != null) {
                Response.ContentType = "text/javascript";

                string path = GetPhysicalPath(Request.QueryString["jsfolder"]);
                string[] files = Directory.GetFiles(path, "*.js");
                WriteFilesToResponse(files);
                Response.AddFileDependency(path);
            }
            else if(Request.QueryString["jsfile"] != null) {
                Response.ContentType = "text/javascript";

                string fileName = GetPhysicalPath(Request.QueryString["jsfile"]);
                if (Path.GetExtension(fileName).ToLowerInvariant() != ".js")
                    return;
                WriteFilesToResponse(new string[] { fileName });
            } 

        SetCaching();

        //The following line can be removed if the DXEnableHtmlCompression option within Web.config is enabled
        DevExpress.Web.ASPxClasses.ASPxWebControl.MakeResponseCompressed();
    }

    protected string GetPhysicalPath(string path) {
        if(!UrlUtils.IsAppRelativePath(path))
            path = "~/" + path;
        return Server.MapPath(path);
    }
    protected void SetCaching() {
        Response.Cache.VaryByParams["cssfolder"] = true;
        Response.Cache.VaryByParams["cssfile"] = true;
        Response.Cache.VaryByParams["jsfolder"] = true;
        Response.Cache.VaryByParams["jsfile"] = true;

        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
        Response.Cache.SetOmitVaryStar(true);
        Response.Cache.SetLastModifiedFromFileDependencies();
    }
    protected void WriteFilesToResponse(string[] files) {
        foreach(string fileName in files) {
            string text = File.ReadAllText(fileName);
            Response.Write(text);
            Response.AddFileDependency(fileName);
        }
    }
}
