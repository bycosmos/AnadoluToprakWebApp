using Anadolu.BusinessLayer;
using Anadolu.BusinessLayer.Results;
using Anadolu.Entitiess;
using Anadolu.Entitiess.ValueObjects;
using Anadolu.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Anadolu.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


        UrunManager urunManager = new UrunManager();

        BayilerManager bm = new BayilerManager();

        AdminManager adminManager = new AdminManager();

        AnasayfaSliderManager sliderManager = new AnasayfaSliderManager();

        AnasayfaFabrikaResimManager fabrikaResimManager = new AnasayfaFabrikaResimManager();

        ReferanslarManager ReferanslarManager = new ReferanslarManager();
        GaleriManager galeriManager = new GaleriManager();
        VideolarManager videolarManager = new VideolarManager();
        IllerManager illerManager = new IllerManager();




        public ActionResult Index()
        {
           HomeIndexModel Model = new HomeIndexModel();
            Model.anaFabrikaResims = fabrikaResimManager.List();
            Model.anaSliderResims = sliderManager.List();
            Model.referanslars = ReferanslarManager.List();
           
            
            return View(Model);
        }
        
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult Urunler()
        {
            List<Product> products = urunManager.List();
            return View(products);
        }
        public ActionResult Galeri()
        {
            GaleriModel galeriModel = new GaleriModel();
            galeriModel.photos = galeriManager.List().OrderByDescending(x => x.Id);
            galeriModel.videolars = videolarManager.List().OrderByDescending(x=>x.Id);
            return View(galeriModel);
        }





        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                BusinessLayerResult<Admin> res = adminManager.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    // Hata koduna göre özel işlem yapmamız gerekirse..
                    // Hatta hata mesajına burada müdahale edilebilir.
                    // (Login.cshtml'deki kısmında açıklama satırı şeklinden kurtarınız)
                    //
                    //if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    //{
                    //    ViewBag.SetLink = "http://Home/Activate/1234-4567-78980";
                    //}

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }

                CurrentSession.Set<Admin>("login", res.Result); // Session'a kullanıcı bilgi saklama..


                return Redirect("~/Admin/Index");   // yönlendirme..


            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
       
       
        public ActionResult _Bayiler(int? id)
        {
           


            List<Bayiler> bayilers = bm.List(x => x.IllerId == id);

            return PartialView("_Bayiler", bayilers);
        }


        public ActionResult Bayiler()
        {
            List<Iller> illers = illerManager.List();

            return View(illers);
        }


        public ActionResult Siparis(int? Id)
        {
            List<Product> products = urunManager.List();


            ViewBag.Id = Id;
           
           
            return View(products);
        }






        public ActionResult _Product1(int? Id)
        {
            if (Id==null)
            {

                Product product1 = urunManager.List().First();
                return PartialView("_Product1", product1);
            }
        Product product = urunManager.List(x => x.Id == Id).First();



            return PartialView("_Product1", product);
        }




        [HttpPost]
        public ActionResult Siparis(Siparis model)
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



                SiparisMail.SendMail(body.ToString());
                TempData["Mesaj"] = "Mesaj";

                TempData["AdSoyad"] = model.MusteriAdiSoyAdi;

                TempData["UrunAdi"] = model.UrunAdi;
                TempData["Adet"]= model.Adet;
            }


            SiparisManager spm = new SiparisManager();
            model.Tarih = DateTime.Now.Date;
            model.DüzenlenmeTarihi = DateTime.Now.Date;
            model.Durum = false;
            model.Musteri = true;
            spm.Insert(model);
            spm.Save();

            return new RedirectResult("/Home/Siparis/");   // yönlendirme..






        }


        }
    }