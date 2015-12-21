using CrowdfundingPlatform.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CrowdfundingPlatform.SQL
{
    public class ProjectRepository : IProjectRepository
    {
        [Inject]
        CrowdfundingEntities db = new CrowdfundingEntities();

        public Project Project(Guid Id)
        {
            return db.Project.Find(Id);
        }

        public List<Project> List()
        {
            return db.Project.Where(x => x.DateStarted < DateTime.Now).ToList();
        }
        
        public void Create(Project project)
        {
            project.Id = Guid.NewGuid();
            project.DateCreated = DateTime.Now;
            project.Owner = System.Web.HttpContext.Current.User.Identity.Name;
            project.CurrentAmount = 0;


            // создаем кошелек
            //var account = new Account()
            //{
            //    Id = Guid.NewGuid(),
            //    Owner = project.Id,
            //    Status = "1",
            //    Balance = 0
            //};

            db.Project.Add(project);
            db.SaveChanges();
        }

        public void Update(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}