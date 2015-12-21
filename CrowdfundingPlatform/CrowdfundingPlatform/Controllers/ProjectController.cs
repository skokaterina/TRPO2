using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdfundingPlatform.Models;

namespace CrowdfundingPlatform.Controllers
{
    public class ProjectController : BaseController
    {
        //private CrowdfundingEntities db = new CrowdfundingEntities();

        public IProjectRepository Repository { get; set; }

        public IAwardRepository AwardRepository { get; set; }

        public ProjectController()
        {
            Repository = DependencyResolver.Current.GetService<IProjectRepository>();

            AwardRepository = DependencyResolver.Current.GetService<IAwardRepository>();
        }
        #region Project
        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View(Repository.List());
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(Guid id )
        {
            Project project = Repository.Project(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            //ViewBag.Owner = new SelectList(db.User, "Id", "Login");
            return View();
        }

        //
        // POST: /Project/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(project);

                return RedirectToAction("Index");
            }

           // ViewBag.Owner = new SelectList(db.User, "Id", "Login", project.Owner);
            return View(project);
        }

        //
        // GET: /Project/Edit/5

        public ActionResult Edit(Guid id)
        {
            Project project = Repository.Project(id);

            if (project == null)
            {
                return HttpNotFound();
            }

           // ViewBag.Owner = new SelectList(db.User, "Id", "Login", project.Owner);
            return View(project);
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(project);

                return RedirectToAction("Index");
            }
        //    ViewBag.Owner = new SelectList(db.User, "Id", "Login", project.Owner);

            return View(project);
        }
        #endregion

        #region Award
        public ActionResult AwardsList(Guid ProjectId)
        {
            ViewBag.OwnerName = Repository.Project(ProjectId).Owner;

            ViewBag.ProjectId = ProjectId;

            return View(AwardRepository.List(ProjectId));
        }

        public ActionResult CreateAward(Guid ProjectId)
        {
            return View(AwardRepository.Create(ProjectId));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAward(Award award)
        {
            if (ModelState.IsValid)
            {
                AwardRepository.Update(award);

                return RedirectToAction("AwardsList", new { ProjectId = award.ProjectId });
            }
            
            return View(award);
        }

        public ActionResult Buy(Guid id)
        {
            return View(AwardRepository.Award(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(Award award)
        {
            if (ModelState.IsValid)
            {
                AwardRepository.Buy(award);

                return RedirectToAction("AwardsList", new { ProjectId = award.ProjectId });
            }

            return View(award);
        }


      


        #endregion
    }
}