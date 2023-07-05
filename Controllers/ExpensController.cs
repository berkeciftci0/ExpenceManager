using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ExpenceManager.Models.Entity;

namespace ExpenceManager.Controllers
{
    public class ExpensController : Controller
    {
        // GET: Expens
        MvcDbMasrafEntities db = new MvcDbMasrafEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMASRAFLAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NEWEXPENS()
        {
            //List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = i.KATEGORIAD,
            //                                     Value = i.KATEGORIID.ToString()
            //                                 }).ToList();
            //ViewBag.dgr = degerler;

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            //// TBLCALISANLAR tablosundan çalışan adını çekerek SelectListItem listesine ekleyin
            //List<TBLCALISANLAR> calisanlar = db.TBLCALISANLAR.ToList();
            //foreach (var calisan in calisanlar)
            //{
            //    degerler.Add(new SelectListItem
            //    {
            //        Text = calisan.CALISANAD,
            //        Value = calisan.CALISANID.ToString()
            //    });
            //}

            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult NEWEXPENS(TBLMASRAFLAR p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;           
            db.TBLMASRAFLAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var masraf = db.TBLMASRAFLAR.Find(id);
            db.TBLMASRAFLAR.Remove(masraf);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult bringExpense(int id)
        {
            var masraf = db.TBLMASRAFLAR.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            //List<TBLCALISANLAR> calisanlar = db.TBLCALISANLAR.ToList();
            //foreach (var calisan in calisanlar)
            //{
            //    degerler.Add(new SelectListItem
            //    {
            //        Text = calisan.CALISANAD,
            //        Value = calisan.CALISANID.ToString()
            //    });
            //}
            ViewBag.dgr = degerler;


            return View("bringExpense", masraf);

        }
        public ActionResult Guncelle(TBLMASRAFLAR p)
        {
            var masraf = db.TBLMASRAFLAR.Find(p.MASRAFID);
            masraf.CALISANAD = p.CALISANAD;
            //masraf.KATEGORI = p.KATEGORI;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            masraf.KATEGORI = ktg.KATEGORIID;
            masraf.FIYAT = p.FIYAT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}