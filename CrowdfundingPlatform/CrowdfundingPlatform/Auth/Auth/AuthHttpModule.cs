using CrowdfundingPlatform.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdfundingPlatform.Auth
{
    public class AuthHttpModule : IHttpModule
    {
        public static bool flag;
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Authenticate);

            flag = true;
        }

        private void Authenticate(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.HttpContext = context;
            context.User = auth.CurrentUser;

            //var s = context.Request.UserAgent;


            flag = true;
        }

        public void Dispose()
        {
        }

    }
}