using CrowdfundingPlatform.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CrowdfundingPlatform.SQL
{
    public class UserRepository: IUserRepository
    {
       [Inject] 
       CrowdfundingEntities db = new CrowdfundingEntities();
       public List<Role> Roles
       {
           get
           {
               return db.Role.ToList();
           }
       }
       public List<User> Users
       {
           get
           {
               return db.User.ToList();
           }
       }

       public User GetUser(string login)
       {
           return db.User.FirstOrDefault(x => x.Login == login);
       }
       public User GetUser(Guid id)
       {
           return db.User.Find(id);
       }

       public User Login(string login, string password)
       {
           return db.User.FirstOrDefault(x => x.Login == login && x.Password == password);
       }
    //    <add name="CrowdfundingEntities" connectionString="metadata=res://*/Models.Model.csdl|res://*/Models.Model.ssdl|res://*/Models.Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=SK;initial catalog=Crowdfunding;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
        public bool CreateUser(User user)
        {
            // заполняем данные по умолчанию
           
           user.RoleId = "User";
           user.DateRegistrated = DateTime.Now;
           user.Status = 1;

            // создаем кошелек
           //var account = new Account() { 
           //    Id = Guid.NewGuid(),
           //    Owner = user.Id,
           //    Status = "1",
           //    Balance = 1000
           //};

           db.User.Add(user);
           db.SaveChanges();
           //db.Account.Add(account);
           //db.SaveChanges();

           return true;
        }

        public bool UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public List<Basket> Basket()
        {
            return db.Basket.Where(x => x.UserLogin == System.Web.HttpContext.Current.User.Identity.Name).ToList();
        }
    }    
}