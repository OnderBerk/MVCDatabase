using mvcdatabase.Models;
using mvcdatabase.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdatabase.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kisiler kisi)
        {
            DatabaseContext db = new DatabaseContext();
            db.Kisiler.Add(kisi);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.Result = "Kişi Kaydedilmiştir";
                ViewBag.Status = "success";
            }
       
            else
            {
                ViewBag.Result = "Kişi Kaydedilememiştir";
                ViewBag.Status = "danger";
            }
               
            return View();
        }

        public ActionResult Duzenle(int? kisiid)
        {
            Kisiler kisi = null;
            if (kisiid != null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }
            return View(kisi);
        }
        [HttpPost]
        public ActionResult Duzenle(Kisiler model, int? kisiid)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            if (kisi != null)
            {
                kisi.Ad = model.Ad;
                kisi.Soyad = model.Soyad;
                kisi.Yas = model.Yas;

                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Kişi Güncellenmiştir";
                    ViewBag.Status = "success";
                }

                else
                {
                    ViewBag.Result = "Kişi Güncellenememiştir";
                    ViewBag.Status = "danger";
                }
            }
            return View(kisi);

       
        }
        [HttpGet]
        public ActionResult Sil(int? kisiid)
        {
            Kisiler kisi = null;
            if (kisiid != null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }
            return View(kisi);
        }
        [HttpPost, ActionName("Sil")]
        public ActionResult SilOk(int? kisiid)
        {
            if (kisiid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Kisiler kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
                db.Kisiler.Remove(kisi);
                db.SaveChanges();
            }
            return RedirectToAction("homepage", "Home");
        }
    }
}