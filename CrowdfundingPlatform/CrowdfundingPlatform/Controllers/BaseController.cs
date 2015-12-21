using CrowdfundingPlatform.Auth;
using CrowdfundingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdfundingPlatform.Controllers
{
    public class BaseController : Controller
    {
        public IUserRepository Repository { get; set; }

        public IAuthentication Auth { get; set; }        

        public User CurrentUser
        {
            get
            {
                Auth = DependencyResolver.Current.GetService<IAuthentication>(); // TODO: надо сделать через  [Inject]

                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

    }
}
