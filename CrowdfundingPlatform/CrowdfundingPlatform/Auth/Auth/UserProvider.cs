using CrowdfundingPlatform.Models;
//using CrowdfundingPlatform.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CrowdfundingPlatform.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string roles)
        {
            return userIdentity.User.InRoles(roles);
        }

        #endregion


        public UserProvider(string name, IUserRepository repository)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return userIdentity.HelloName;
        }
    }
}