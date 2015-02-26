using BugTracking.Data;
using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracking.Controllers
{
    public class HomeController : Controller
    {
        IUowData db;

        public HomeController(IUowData db)
        {
            this.db = db;
        }

        // [OutputCache]
        public ViewResult Index()
        {
            if (this.HttpContext.Cache["Bugs"] == null)
            {
                this.HttpContext.Cache["Bugs"] = db.Bugs.All().ToList();
            }

            return View(this.HttpContext.Cache["Bugs"]);
        }

        public ActionResult TestSession()
        {
            if (this.Session["Count"] == null)
            {
                this.Session["Count"] = 1;
            }
            else
            {
                this.Session["Count"] = (int)this.Session["Count"] + 1;
            }

            return Content(this.Session["Count"].ToString());
        }
    }
}