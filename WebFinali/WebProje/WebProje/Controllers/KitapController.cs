using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProje.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Kitap_Listesi()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var kitap = session.Query<Models.Kitap>().ToList();
                return View(kitap);
            }
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Models.Kitap kitaplar)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var kitap = new Models.Kitap();
                kitap.KitapAd = kitaplar.KitapAd;
                kitap.KitapYazar = kitaplar.KitapYazar;
                kitap.BaskiSayisi = kitaplar.BaskiSayisi;
                kitap.Yayinevi = kitaplar.Yayinevi;
                session.SaveOrUpdate(kitap);
                session.Flush();

            }
            return RedirectToAction("/Kitap_Listesi");

        }

        public ActionResult Güncelle(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var ktp = session.Query<Models.Kitap>().FirstOrDefault(x => x.Id == id);
                return View(ktp);
            }
        }

        [HttpPost]
        public ActionResult Güncelle(Models.Kitap kitaplar)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var kitap = session.Query<Models.Kitap>().FirstOrDefault(x => x.Id == kitaplar.Id);
                kitap.KitapAd = kitaplar.KitapAd;
                kitap.KitapYazar = kitaplar.KitapYazar;
                kitap.BaskiSayisi = kitaplar.BaskiSayisi;
                kitap.Yayinevi = kitaplar.Yayinevi;
                session.SaveOrUpdate(kitap);
                session.Flush();
                return RedirectToAction("/Kitap_Listesi");
            }
        }


        //BU KISMI ÇALIŞTIRAMADIM..
        public ActionResult Sil(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var kitap = session.Query<Models.Kitap>().FirstOrDefault(x => x.Id == id);
                return View(kitap);
            }
        }

        [HttpPost]
        public ActionResult Sil(Models.Kitap kitaplar)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var kitap = session.Query<Models.Kitap>().FirstOrDefault(x => x.Id == kitaplar.Id);
                kitap.KitapAd = kitaplar.KitapAd;
                kitap.KitapYazar = kitaplar.KitapYazar;
                kitap.BaskiSayisi = kitaplar.BaskiSayisi;
                kitap.Yayinevi = kitaplar.Yayinevi;
                //var yzr = session.Get<Models.Yazar>();
                session.Delete(kitap);
                session.Flush();
                return RedirectToAction("/Kitap_Listesi");
            }
            
        }
    }
}

