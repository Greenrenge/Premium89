using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Premium89
{
    public static class WebConfig
    {
        public static string NavMenuConfigUrl
        {
            get
            {
                return ResolveRelativePath(ConfigurationManager.AppSettings["NavMenuConfigUrl"]);
            }
        }






        internal static string ResolveRelativePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return string.Empty;
            else
            {
                path = path.Trim();
                if(path.StartsWith(@".\"))
                {
                    return path.Replace(@".\", HttpRuntime.AppDomainAppPath);
                }
                else
                {
                    return path;
                }
            }
        }
    }
}