using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdfundingPlatform.Models;
using Ninject;
using CrowdfundingPlatform.Auth;

namespace CrowdfundingPlatform.Controllers
{
    public class UserController : BaseController
    {
        public UserController()
        {
            Repository = DependencyResolver.Current.GetService<IUserRepository>();
            Auth = DependencyResolver.Current.GetService<IAuthentication>();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, string Password)
        {
            user.Password = Password;

            if (ModelState.IsValid)
            {
                Repository.CreateUser(user);

                return RedirectToAction("Index", "Project");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Login(string Login, string Password)
        {
            if (Auth.Login(Login, Password, true) != null)
            {
                return RedirectToAction("Index", "Project");
            }
            else
            {
                ModelState["Password"].Errors.Add("Пользователя с введеными данными не существует");

                return View();
            }
        }

        public ActionResult Logout()
        {
            Auth.LogOut();

            return RedirectToAction("Index", "Project");
        }

        public ActionResult Basket()
        {
            return View(Repository.Basket());
        }



        

       
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}