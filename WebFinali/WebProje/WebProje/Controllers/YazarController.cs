using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;

namespace WebProje.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yazar_Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yzr = session.Query<Models.Yazar>().Fetch(x => x.KitapAd).ToList();
                return View(yzr);
            }
        }

        public ActionResult Güncelle(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yazar = session.Query<Models.Yazar>().FirstOrDefault(x => x.Id == id);
                return View(yazar);
            }
        }

        [HttpPost]
        public ActionResult Güncelle(Models.Yazar yazarlar)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yazar = session.Query<Models.Yazar>().FirstOrDefault(x => x.Id == yazarlar.Id);
                yazar.YazarAd = yazarlar.YazarAd;
                yazar.YazarYas = yazarlar.YazarYas;
                yazar.YazarUlke = yazarlar.YazarUlke;
                session.SaveOrUpdate(yazar);
                session.Flush();
                return RedirectToAction("/Yazar_Listele");
            }
        }

        public ActionResult Sil(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yazar = session.Query<Models.Yazar>().FirstOrDefault(x => x.Id == id);
                return View(yazar);
            }
        }

        [HttpPost]
        public ActionResult Sil(Models.Yazar yazarlar)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yazar = session.Query<Models.Yazar>().FirstOrDefault(x => x.Id == yazarlar.Id);
                yazar.YazarAd = yazarlar.YazarAd;
                yazar.YazarYas = yazarlar.YazarYas;
                yazar.YazarUlke = yazarlar.YazarUlke;
                session.Delete(yazar);
                session.Flush();
                return RedirectToAction("/Yazar_Listele");
            }
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Models.Yazar yazarlar)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yazar = new Models.Yazar();
                yazar.YazarAd = yazarlar.YazarAd;
                yazar.YazarYas = yazarlar.YazarYas;
                yazar.YazarUlke = yazarlar.YazarUlke;
                session.SaveOrUpdate(yazar);
                session.Flush();

            }
            return RedirectToAction("/Yazar_Listele");

        }
    }
}