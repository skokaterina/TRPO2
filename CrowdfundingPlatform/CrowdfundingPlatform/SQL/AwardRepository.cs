using CrowdfundingPlatform.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CrowdfundingPlatform.SQL
{
    public class AwardRepository: IAwardRepository
    {
        [Inject]
        CrowdfundingEntities db = new CrowdfundingEntities();

        public Award Award(Guid Id)
        {
            return db.Award.Find(Id);
        }

        public List<Award> List(Guid ProjectId)
        {
            return db.Award.Where(x => x.ProjectId == ProjectId).ToList();
        }
        
        public void Create(Award Award)
        {
            Award.Id = Guid.NewGuid();

           

            db.Award.Add(Award);
            db.SaveChanges();
        }

        public Award Create(Guid ProjectId)
        {
            Award Award = new Award()
            {
                Id = Guid.NewGuid(),
                ProjectId = ProjectId
            };

            db.Award.Add(Award);
            db.SaveChanges();

            return Award;
        }

        public void Update(Award Award)
        {
            db.Entry(Award).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Buy(Award _award)
        {
            var award = db.Award.Find(_award.Id);
            var user = db.User.FirstOrDefault(x => x.Login == System.Web.HttpContext.Current.User.Identity.Name);

            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                UserLogin = user.Login,
                ProjectId = award.ProjectId,
                Amount = award.Price,
                Date = DateTime.Now
            };

            db.Transaction.Add(transaction);

            Basket basket = new Basket()
            {
                Id = Guid.NewGuid(),
                UserLogin = user.Login,
                AwardId = award.Id,
                Price = award.Price,
                Date = DateTime.Now
            };

            db.Basket.Add(basket);

            db.Project.Find(award.ProjectId).CurrentAmount += award.Price;
            award.Qty--;

            //Account userAccount = user.Account.First();

            //userAccount.Balance -= Award.Price;

            //db.Entry(userAccount).State = EntityState.Modified;

            //Account projectAccount = Award.Project.Account.First();

            //projectAccount.Balance += Award.Price;

           // db.Entry(projectAccount).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
    
}