using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenceManager.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace ExpenceManager.Controllers
{
    public class CattegoryController : Controller
    {

        MvcDbMasrafEntities db = new MvcDbMasrafEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCattegory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCattegory(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCattegory");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult DELETE(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ListCategories(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("ListCategories", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}