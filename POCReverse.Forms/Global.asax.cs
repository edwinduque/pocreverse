using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace POCReverse.Forms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
            .AddProxySupport(options => options.UseForwardedHeaders = true)
            .AddJsonSessionSerializer(options =>
            {
                options.RegisterKey<string>("Test");
            })
            .AddRemoteAppServer(options => options.ApiKey = "24B0E9BE-22D4-4979-9E08-6C2726839885")
            .AddSessionServer();
        }
    }
}