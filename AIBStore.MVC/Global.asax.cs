using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AIBStore.Domain.Entities;
using AIBStore.MVC.Infrastucture.Binders;
using AIBStore.Constants;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using AIBStore.MVC.Helpers;

namespace AIBStore.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Initialise();
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            Logger.DebugLog("Application Start Called");
        }

        void Session_Start(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            Session[Constants.Constants.SessionCacheKey] = guid;
            Logger.DebugLog(String.Concat("Session Start Called for ", guid.ToString()));
        }

        void Session_End(object sender, EventArgs e)
        {
            Session[Constants.Constants.SessionCacheKey] = null;

        }
       
    }
}
