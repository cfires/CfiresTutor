using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CfiresTutor.UI.Admin
{
    /// <summary>
    /// 用于获取访问前台页面的Url
    /// </summary>
    public class WebUrls
    {
        private static WebUrls _instance = new WebUrls();

        private WebUrls()
        {
            this.baseUrl = ConfigurationManager.AppSettings["webUrl"];
        }

        public static WebUrls Instance()
        {
            return _instance;
        }

        /// <summary>
        /// 前台的BaseUrl（协议://域名）
        /// </summary>
        private string baseUrl;

        /// <summary>
        /// 构建完整的WebUrl
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public string BuildWebUrl(string relativeUrl)
        {
            return string.Format("{0}/{1}", baseUrl, relativeUrl);
        }

        /// <summary>
        /// 示例
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string Example(object param)
        {
            return BuildWebUrl(string.Format("example/{0}", param));
        }
    }
}