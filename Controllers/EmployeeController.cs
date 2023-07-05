using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenceManager.Models.Entity;

namespace ExpenceManager.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        MvcDbMasrafEntities db=new MvcDbMasrafEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLCALISANLAR select d;
            if (!string.IsNullOrEmpty(p))
            {
                //İşlem 
                degerler = degerler.Where(m => m.CALISANAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler=db.TBLCALISANLAR.ToList();
            //return View(degerler);
        }
        [HttpGet] 
        public ActionResult NEWEMPLOYEE()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NEWEMPLOYEE(TBLCALISANLAR p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NEWEMPLOYEE");
            }
            db.TBLCALISANLAR.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var calisan = db.TBLCALISANLAR.Find(id);
            db.TBLCALISANLAR.Remove(calisan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       public ActionResult BringEmployee(int id)
        {
            var cal = db.TBLCALISANLAR.Find(id);
            return View("BringEmployee",cal);
        }
        public ActionResult Guncelle(TBLCALISANLAR p1)
        {
            var calisan = db.TBLCALISANLAR.Find(p1.CALISANID);
            calisan.CALISANAD = p1.CALISANAD;
            calisan.CALISANSOYAD = p1.CALISANSOYAD;
            calisan.CALISANBILGI = p1.CALISANBILGI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}