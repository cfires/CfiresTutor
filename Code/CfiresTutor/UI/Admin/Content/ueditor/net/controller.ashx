<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System;
using System.Web;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        Handler action = null;
        switch (context.Request["action"])
        {
            case "config":
                action = new ConfigHandler(context);
                break;
            case "uploadimage":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = JConfig.GetStringList("imageAllowFiles"),
                    PathFormat = JConfig.GetString("imagePathFormat"),
                    SizeLimit = JConfig.GetInt("imageMaxSize"),
                    UploadFieldName = JConfig.GetString("imageFieldName")
                });
                break;
            case "uploadscrawl":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = new string[] { ".png" },
                    PathFormat = JConfig.GetString("scrawlPathFormat"),
                    SizeLimit = JConfig.GetInt("scrawlMaxSize"),
                    UploadFieldName = JConfig.GetString("scrawlFieldName"),
                    Base64 = true,
                    Base64Filename = "scrawl.png"
                });
                break;
            case "uploadvideo":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = JConfig.GetStringList("videoAllowFiles"),
                    PathFormat = JConfig.GetString("videoPathFormat"),
                    SizeLimit = JConfig.GetInt("videoMaxSize"),
                    UploadFieldName = JConfig.GetString("videoFieldName")
                });
                break;
            case "uploadfile":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = JConfig.GetStringList("fileAllowFiles"),
                    PathFormat = JConfig.GetString("filePathFormat"),
                    SizeLimit = JConfig.GetInt("fileMaxSize"),
                    UploadFieldName = JConfig.GetString("fileFieldName")
                });
                break;
            case "listimage":
                action = new ListFileManager(context, JConfig.GetString("imageManagerListPath"), JConfig.GetStringList("imageManagerAllowFiles"));
                break;
            case "listfile":
                action = new ListFileManager(context, JConfig.GetString("fileManagerListPath"), JConfig.GetStringList("fileManagerAllowFiles"));
                break;
            case "catchimage":
                action = new CrawlerHandler(context);
                break;
            default:
                action = new NotSupportedHandler(context);
                break;
        }
        action.Process();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}