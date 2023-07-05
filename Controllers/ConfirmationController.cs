using ExpenceManager.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenceManager.Controllers
{
    public class ConfirmationController : Controller
    {
        // GET: Confirmation
        MvcDbMasrafEntities db=new MvcDbMasrafEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeniOnay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLONAYLAR p)
        {
            db.TBLONAYLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}