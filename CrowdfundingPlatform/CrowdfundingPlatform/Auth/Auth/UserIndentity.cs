using CrowdfundingPlatform.Models;
//using CrowdfundingPlatform.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CrowdfundingPlatform.Auth
{
   
    public class UserIndentity : IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Login;
                }

                return "anonym";
            }
        }

        public string Role
        {
            get
            {
                if (User != null)
                {
                    return User.RoleId;
                }

                return "anonum";
            }
        }
        public string HelloName
        {
            get
            {
                if (User != null)
                {
                    return User.Login;
                }

                return "anonym";
            }
        }

        public void Init(string email, IUserRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }
    }
}