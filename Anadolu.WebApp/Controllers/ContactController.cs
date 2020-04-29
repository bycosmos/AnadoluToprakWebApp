using Anadolu.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Anadolu.WebApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(İletisimModel model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad Soyad: "+model.Name);
                body.AppendLine("Mail Adres: "+model.Email);
                body.AppendLine("Telefon: "+model.Phone);

                body.AppendLine("Konu: " + model.Subject);


                body.AppendLine("İleti: " + model.Message);
                Gmail.SendMail(body.ToString());
                ViewBag.Success = true;
            }



            return Redirect("Home/Contact");

        }


        [HttpPost]
        public ActionResult Siparis(SiparisModel model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();

                body.AppendLine("Ürün Adı: " + model.UrunAdi);

                body.AppendLine("Ad Soyad: " + model.MusteriAdiSoyAdi);


                body.AppendLine("Mail Adres: " + model.Email);
                body.AppendLine("Telefon: " + model.Telefon);

                body.AppendLine("Adet: " + model.Adet);


                body.AppendLine("Adet Fiyatı: " + model.Fiyat);

                body.AppendLine("Toplam Tutar: " + model.ToplamOrtalamaTutar);

                body.AppendLine("İl: " + model.Il);

                body.AppendLine("İlçe: " + model.Ilce);

                body.AppendLine("Adres: " + model.Adres);


                body.AppendLine("Ek Açıklama: " + model.EkBilgi);



                Gmail.SendMail(body.ToString());
                ViewBag.Success = true;
            }



            return Redirect("../../Home/ProductSiparis/1");





        }
    }
}