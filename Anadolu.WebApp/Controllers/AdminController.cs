using Anadolu.Entitiess;
using Anadolu.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Security;
using Anadolu.WebApp.Models;
using Anadolu.WebApp.Filters;
using PagedList;
using PagedList.Mvc;

namespace Anadolu.WebApp.Controllers
{


    [Auth]
    public class AdminController : Controller
    {

        UrunManager urunManager = new UrunManager();

        BayilerManager bm = new BayilerManager();

        AdminManager adminManager = new AdminManager();

        AnasayfaSliderManager sliderManager = new AnasayfaSliderManager();

        AnasayfaFabrikaResimManager fabrikaResimManager = new AnasayfaFabrikaResimManager();

        ReferanslarManager ReferanslarManager = new ReferanslarManager();
        GaleriManager galeriManager = new GaleriManager();
        VideolarManager videolarManager = new VideolarManager();
        IllerManager illerManager = new IllerManager();

        // GET: Admin
        public ActionResult Index()
        {
            
           
            return View();
        }

        
        public ActionResult ProductList()
        {
            List<Product> products = urunManager.List();
            return View(products);
        }



        public ActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product pro, HttpPostedFileBase uploadfile)
        {

            if (uploadfile != null)
            {



                if (uploadfile.ContentLength > 0)
                {
                    string GuidYol = Guid.NewGuid().ToString();
                    string filePath = Path.Combine(Server.MapPath("~/img/UrunResim"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                    uploadfile.SaveAs(filePath);



                    pro.UrunResimAdres = "../../img/UrunResim/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);




                }
            }

            else
            {

                return RedirectToAction("ProductAdd");

            }



            UrunManager um = new UrunManager();
            
          
           
            um.Insert(pro);
            um.Save();
            
            return View();

            
        }


        public ActionResult Slider()
        {
            List<AnaSliderResim> anaSliderResims = sliderManager.List();
            return View(anaSliderResims);

        }
        [HttpPost]
        public ActionResult Slider(AnaSliderResim asr,HttpPostedFileBase uploadfile)
        {
            if (uploadfile!=null)
            {

                if (uploadfile.ContentLength > 0)
                {
                    Image img = Image.FromStream(uploadfile.InputStream);
                    int width = Convert.ToInt32(ConfigurationManager.AppSettings["SliderWidth"].ToString());


                    int height = Convert.ToInt32(ConfigurationManager.AppSettings["SliderHeight"].ToString());
                    Bitmap bm = new Bitmap(img, width, height);


                    string GuidYol = Guid.NewGuid().ToString();
                    string filePath = Path.Combine(Server.MapPath("~/img/hero-slider"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                    bm.Save(filePath);




                    asr.SliderResimAdres = "../../img/hero-slider/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);




                }
            }

            else
            {

                return RedirectToAction("Slider");

            }


            AnasayfaSliderManager am = new AnasayfaSliderManager();
            am.Insert(asr);
            am.Save();

            return RedirectToAction("Slider");

        }

        public ActionResult SliderDelete(int Id)
        {

            
            AnasayfaSliderManager am = new AnasayfaSliderManager();
            AnaSliderResim asrSil = am.Find(x => x.Id == Id);
            am.Delete(asrSil);
            am.Save();

            return RedirectToAction("Slider");

        }




        public ActionResult FabrikaResimAdd()

        {
            return View();
        }

        [HttpPost]
        public ActionResult FabrikaResimAdd( HttpPostedFileBase uploadfile,AnaFabrikaResim fr)

        {
            if (uploadfile!=null)
            {

                if (uploadfile.ContentLength > 0)
                {
                   

                    Image img = Image.FromStream(uploadfile.InputStream);
                    int width = Convert.ToInt32(ConfigurationManager.AppSettings["SliderWidth"].ToString());


                    int height = Convert.ToInt32(ConfigurationManager.AppSettings["SliderHeight"].ToString());
                    Bitmap bm = new Bitmap(img, width, height);

                    string GuidYol = Guid.NewGuid().ToString();
                    string filePath = Path.Combine(Server.MapPath("~/img/FabrikaResim"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                    uploadfile.SaveAs(filePath);



                    fr.ResimAdres = "../../img/FabrikaResim/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);

                    bm.Save(filePath);



                }
            }
            else
            {
                        
            return RedirectToAction("FabrikaResimAdd"); 

            }
            AnasayfaFabrikaResimManager afrm = new AnasayfaFabrikaResimManager();
            afrm.Insert(fr);
            afrm.Save();

            return RedirectToAction("FabrikaResim"); 

        }
        [HttpPost]
        public ActionResult FabrikaResimSil(AnaFabrikaResim anaFabrikaResim)
        {


            AnasayfaFabrikaResimManager fabrikaResim = new AnasayfaFabrikaResimManager();
            AnaFabrikaResim sil = fabrikaResim.Find(x => x.Id == anaFabrikaResim.Id);
            fabrikaResim.Delete(sil);
            fabrikaResim.Save();

            return RedirectToAction("Slider");

        }


        
        [HttpPost]
        public ActionResult ReferansEkle(Referanslar referanslar, HttpPostedFileBase uploadfile)

        {

            if (uploadfile != null)
            {

                if (uploadfile.ContentLength > 0)
                {


                    if (uploadfile.ContentLength > 0)
                    {

                        Image img = Image.FromStream(uploadfile.InputStream);
                        int width = Convert.ToInt32(ConfigurationManager.AppSettings["ReferansWidth"].ToString());


                        int height = Convert.ToInt32(ConfigurationManager.AppSettings["ReferansHeight"].ToString());
                        Bitmap bm = new Bitmap(img, width, height);

                        string GuidYol = Guid.NewGuid().ToString();
                        string filePath = Path.Combine(Server.MapPath("~/img/Referanslar"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                        bm.Save(filePath);


                        referanslar.Address = "../../img/Referanslar/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);





                    }





                }
            }

            else
            {

                return RedirectToAction("Referans");

            }

            ReferanslarManager referanslarManager = new ReferanslarManager();
            referanslarManager.Insert(referanslar);
            referanslarManager.Save();

            return RedirectToAction("Referans"); 

        }
        
        public ActionResult ReferansSil(int Id)
        {


            ReferanslarManager referanslarManager = new ReferanslarManager();
            Referanslar sil = referanslarManager.Find(m=> m.Id==Id);
            referanslarManager.Delete(sil);
            referanslarManager.Save();

            return RedirectToAction("Referans");

        }


        public ActionResult Fabrika()
        {

            return View();
        }


        public ActionResult ProductEdit(int? Id)
        {



            UrunManager urunManager = new UrunManager();
            Product product = urunManager.Find(x => x.Id == Id);
            return View(product);
        }


        [HttpPost]
        public ActionResult ProductEdit(Product model, HttpPostedFileBase uploadfile)

        {
            if (uploadfile != null)
            {


                if (uploadfile.ContentLength > 0)
                {
                    string GuidYol = Guid.NewGuid().ToString();
                    string filePath = Path.Combine(Server.MapPath("~/img/UrunResim"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                    uploadfile.SaveAs(filePath);



                    model.UrunResimAdres = "../../img/UrunResim/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);




                }
            }
            UrunManager um = new UrunManager();
            Product pro = um.Find(x => x.Id == model.Id);
            pro.Name = model.Name;
            pro.Fiyat = model.Fiyat;
            pro.CategoryId = model.CategoryId;
            pro.BasincDayanimi = model.BasincDayanimi;
            pro.Boyut = model.Boyut;
            pro.Agirlik = model.Agirlik;
            pro.UrunResimAdres = model.UrunResimAdres;
            pro.MetrekareTuglaSayisi = model.MetrekareTuglaSayisi;
            pro.IsiIletkenligi = model.IsiIletkenligi;




            um.Update(pro);

            return RedirectToAction("ProductList");

        }



        public ActionResult ProductDelete(int? Id)
        {



            UrunManager urunManager = new UrunManager();
            Product product = urunManager.Find(x => x.Id == Id);
            urunManager.Delete(product);


            return RedirectToAction("ProductList");

        }


       
        public ActionResult GalleryList()
        {
            GaleriModel galeriModel = new GaleriModel();
            galeriModel.photos = galeriManager.List().OrderByDescending(x => x.Id);
            galeriModel.videolars = videolarManager.List().OrderByDescending(x => x.Id);
            return View(galeriModel);

        }

        

        [HttpPost]
        public ActionResult GalleryAdd(Photo photo, HttpPostedFileBase uploadfile)
        {



            if (uploadfile != null)
            {

                if (uploadfile.ContentLength > 0)
                {


                    if (uploadfile.ContentLength > 0)
                    {


                        if (uploadfile != null)
                        {
                            string GuidYol = Guid.NewGuid().ToString();
                            string filePath = Path.Combine(Server.MapPath("~/img/Galeri"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                            uploadfile.SaveAs(filePath);



                            photo.Address = "../../img/Galeri/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);




                        }

                    }





                }
            }

            else
            {

                return RedirectToAction("GalleryList");

            }


            GaleriManager gm = new GaleriManager();
            gm.Insert(photo);
            gm.Save();

            return RedirectToAction("GalleryList");

        }


        public ActionResult GalleryDelete(int Id)
        {
            GaleriManager gm = new GaleriManager();
            Photo photo = gm.Find(x=>x.Id==Id);
            gm.Delete(photo);

            return RedirectToAction("GalleryList");

        }



        public ActionResult GalleryEdit(int? Id)
        {



            GaleriManager gm = new GaleriManager();
            Photo photo = gm.Find(x => x.Id == Id);
            return View(photo);
        }

        [HttpPost]
        public ActionResult GalleryEdit(Photo model, HttpPostedFileBase uploadfile)

        {

            if (uploadfile !=null)
            {
                string GuidYol = Guid.NewGuid().ToString();
                string filePath = Path.Combine(Server.MapPath("~/img/Galeri"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filePath);



                model.Address = "../../img/Galeri/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);




            }
            GaleriManager gm = new GaleriManager();
            Photo p = gm.Find(x => x.Id == model.Id);
            p.Name = model.Name;
            p.Address = model.Address;
            p.Aciklama = model.Aciklama;



            gm.Update(p);

            return RedirectToAction("GalleryList");

        }


        public ActionResult FabrikaResimEdit(int? Id)
        {



            AnasayfaFabrikaResimManager arm = new AnasayfaFabrikaResimManager();
            AnaFabrikaResim photo = arm.Find(x => x.Id == Id);
            return View(photo);
        }


        [HttpPost]
        public ActionResult FabrikaResimEdit(AnaFabrikaResim model, HttpPostedFileBase uploadfile)

        {

            if (uploadfile !=null)
            {
                string GuidYol = Guid.NewGuid().ToString();
                string filePath = Path.Combine(Server.MapPath("~/img/FabrikaResim"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filePath);



                model.ResimAdres = "../../img/FabrikaResim/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);




            }
            AnasayfaFabrikaResimManager arm = new AnasayfaFabrikaResimManager();
            AnaFabrikaResim p = arm.Find(x => x.Id == model.Id);
            p.Name = model.Name;
           
            p.ResimAdres = model.ResimAdres;


            arm.Update(p);

            return RedirectToAction("FabrikaResim");

        }


        public ActionResult ReferansEdit(int? Id)
        {

            ReferanslarManager rm = new ReferanslarManager();
            Referanslar referanslar = rm.Find(x => x.Id == Id);
            return View(referanslar);
        }

        public ActionResult FabrikaResimDelete(int Id)
        {
            
            AnaFabrikaResim p = fabrikaResimManager.Find(x => x.Id == Id);
            fabrikaResimManager.Delete(p);

            return RedirectToAction("FabrikaResim");

        }




        [HttpPost]
        public ActionResult ReferansEdit(Referanslar model, HttpPostedFileBase uploadfile)

        {



            if (uploadfile !=null)
            {

                Image img = Image.FromStream(uploadfile.InputStream);
                int width = Convert.ToInt32(ConfigurationManager.AppSettings["ReferansWidth"].ToString());


                int height = Convert.ToInt32(ConfigurationManager.AppSettings["ReferansHeight"].ToString());
                Bitmap bm = new Bitmap(img, width, height);

                string GuidYol = Guid.NewGuid().ToString();
                string filePath = Path.Combine(Server.MapPath("~/img/Referanslar"), GuidYol + "_" + Path.GetFileName(uploadfile.FileName));
                bm.Save(filePath);


                 model.Address = "../../img/Referanslar/" + GuidYol + "_" + Path.GetFileName(uploadfile.FileName);





            }











            ReferanslarManager rm = new ReferanslarManager();
            Referanslar p = rm.Find(x => x.Id == model.Id);
            p.Name = model.Name;
            p.WebUrl = model.WebUrl;
            p.Address = model.Address;


            rm.Update(p);

            return RedirectToAction("Referans");

        }






        
        public ActionResult Referans()

        {
            List<Referanslar> referanslars = ReferanslarManager.List();

            return View(referanslars);

        }




        public ActionResult FabrikaResim()

        {
            List<AnaFabrikaResim> fabrikaResims = fabrikaResimManager.List();
            return View(fabrikaResims);

        }

        public ActionResult BayiAdd()
        {
            return View();
        }

        


        public ActionResult Siparisler()
        {


            SiparisManager siparisManager = new SiparisManager();
            List<Siparis> siparis = siparisManager.List();




            return View(siparis);

        }








        [AllowAnonymous]
         public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Admin/Index");


        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {

                AdminManager rpstryadmn = new AdminManager();
                //Aşağıdaki if komutu gönderilen mail ve şifre doğrultusunda kullanıcı kontrolu yapar. Eğer kullanıcı var ise login olur.
                Admin adm = rpstryadmn.Find(a => a.AdminEmail == model.EMail && a.Password == model.Password);
                if (adm!=null)
                {
                    FormsAuthentication.SetAuthCookie(model.EMail, true);
                    return RedirectToAction("Slider", "Admin");
                }

                else
                {
                    ModelState.AddModelError("", "EMail veya şifre hatalı!");
                }
            }
            return View(model);
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }


        public ActionResult BayiList()
        {
            List<Iller> illers = illerManager.List();
            return View(illers);
        }
        public ActionResult _BayilerList(int? id)
        {
            BayilerManager bm = new BayilerManager();
            List<Bayiler> bayilers = bm.List(x => x.IllerId == id);

            return PartialView("_BayilerList", bayilers);
        }
        public ActionResult _Siparisler(int id)
        {
            SiparisManager spm = new SiparisManager();
            Siparis Sip = spm.List(x => x.Id == id).First();
            return PartialView("_Siparisler",Sip);




        }





        public ActionResult SiparisDelete(int? Id)
        {



            SiparisManager m = new SiparisManager();
            Siparis siparis = m.Find(x => x.Id == Id);
            m.Delete(siparis);


            return RedirectToAction("Siparisler");

        }


        public ActionResult SiparisEdit(int? Id)
        {



            SiparisManager m = new SiparisManager();
            Siparis sip = m.Find(x => x.Id == Id);
            return View(sip);
        }
        [HttpPost]
        public ActionResult SiparisEdit(Siparis model)

        {
            SiparisManager m = new SiparisManager();
            Siparis siparis = m.Find(x => x.Id == model.Id);
            siparis.Name = model.Name;
            siparis.Adet = model.Adet;
            siparis.Adres = model.Adres;
            siparis.Durum = model.Durum;
            siparis.DüzenlenmeTarihi = DateTime.Now.Date;
            siparis.EkBilgi = model.EkBilgi;
            siparis.Email = model.Email;
            siparis.Fiyat = model.Fiyat;
            siparis.Il = model.Il;
            siparis.Ilce = model.Ilce;
            siparis.MusteriAdiSoyAdi = model.MusteriAdiSoyAdi;
            siparis.Tarih = model.Tarih;
            siparis.Telefon = model.Telefon;
            siparis.ToplamOrtalamaTutar = model.ToplamOrtalamaTutar;
            siparis.UrunAdi = model.UrunAdi;
            siparis.Musteri = model.Musteri;



            m.Update(siparis);

            return RedirectToAction("Siparisler");

        }




        public ActionResult SiparisAdd()
        {

            return View();
        }


        [HttpPost]
        public ActionResult SiparisAdd(Siparis sip)
        {



            SiparisManager um = new SiparisManager();

            sip.Musteri = false;
            sip.Tarih = DateTime.Now.Date;
            sip.DüzenlenmeTarihi = DateTime.Now.Date;

            um.Insert(sip);
            um.Save();

            return RedirectToAction("SiparisAdd");

        }






        public ActionResult BayiDelete(int? Id)
        {



            BayilerManager bm = new BayilerManager();
            Bayiler bayiler = bm.Find(x => x.Id == Id);
            bm.Delete(bayiler);


            return RedirectToAction("BayiList");

        }


        public ActionResult BayiEdit(int? Id)
        {



            BayilerManager bm = new BayilerManager();
            Bayiler bayiler = bm.Find(x => x.Id == Id);
            return View(bayiler);
        }
        [HttpPost]
        public ActionResult BayiEdit(Bayiler model)

        {
            BayilerManager bm = new BayilerManager();
            Bayiler bayiler = bm.Find(x => x.Id == model.Id);
            bayiler.Name = model.Name;
            bayiler.Telefon = model.Telefon;
            bayiler.IllerId = model.IllerId;
            bayiler.Email = model.Email;
            bayiler.Adres = model.Adres;
            bayiler.Fax = model.Fax;



            bm.Update(bayiler);

            return RedirectToAction("BayiList");

        }



        [HttpPost]
        public ActionResult BayiAdd(Bayiler pro)
        {
            



            BayilerManager bm = new BayilerManager();



            bm.Insert(pro);
            bm.Save();

            return View();


        }



        public ActionResult IlList()
        {

            List<Iller> illers = illerManager.List();

            return View(illers);

           
        }


        [HttpPost]
        public ActionResult IlAdd(Iller pro)
        {



            IllerManager um = new IllerManager();



            um.Insert(pro);
            um.Save();

            return RedirectToAction("IlList");

        }



        public ActionResult IlDelete(int? Id)
        {



            IllerManager im = new IllerManager();
            Iller il = im.Find(x => x.Id == Id);
            im.Delete(il);


            return RedirectToAction("IlList");

        }


        public ActionResult IlEdit(int? Id)
        {



            IllerManager im = new IllerManager();
            Iller il = im.Find(x => x.Id == Id);
            return View(il);
        }
        [HttpPost]
        public ActionResult IlEdit(Iller model)

        {
            IllerManager im = new IllerManager();
            Iller il = im.Find(x => x.Id == model.Id);
            il.Name = model.Name;
            



            im.Update(il);

            return RedirectToAction("IlList");

        }







        [HttpPost]
        public ActionResult VideoAdd(Videolar videolar)
        {

            if (videolar.Adres==null)
            {

                return RedirectToAction("GalleryList");

            }


            VideolarManager vm = new VideolarManager();
            
            videolar.Adres = videolar.Adres.Replace("watch?v=","embed/");
           
            vm.Insert(videolar);
            vm.Save();

            return RedirectToAction("GalleryList");

        }


        public ActionResult VideoDelete(int? Id)
        {



            VideolarManager vm = new VideolarManager();
            Videolar videolar = vm.Find(x => x.Id == Id);
            vm.Delete(videolar);


            return RedirectToAction("GalleryList");

        }


        public ActionResult VideoEdit(int? Id)
        {


            VideolarManager vm = new VideolarManager();
            Videolar videolar = vm.Find(x => x.Id == Id);



            return View(videolar);

        }
        [HttpPost]
        public ActionResult VideoEdit(Videolar model)

        {
            VideolarManager vm = new VideolarManager();
            Videolar videolar = vm.Find(x => x.Id == model.Id);


            model.Adres = model.Adres.Replace("watch?v=", "embed/");
            videolar.Adres = model.Adres;
            videolar.Aciklama = model.Aciklama;
            videolar.Name = model.Name;

            vm.Update(videolar);

            return RedirectToAction("GalleryList");

        }


        public ActionResult Admin()

        {
            List<Admin> admins = adminManager.List();

            return View(admins);


        }
        public ActionResult AdminEkle()
        {
           


            return View();

        }
        [HttpPost]
        public ActionResult AdminEkle(Admin admin)
        {
            if (admin.AdminEmail==null || admin.Password==null)
            {
                return RedirectToAction("Admin");
            }
            adminManager.Insert(admin);
            adminManager.Save();

            return RedirectToAction("Admin");

        }


        public ActionResult AdminDuzenle(int? Id)
        {


           
            Admin admin = adminManager.Find(x => x.Id == Id);



            return View(admin);

        }
        [HttpPost]
        public ActionResult AdminDuzenle(Admin model)

        {

            if (model.AdminEmail == null || model.Password == null)
            {
                return RedirectToAction("Admin");
            }
            Admin admin = adminManager.Find(x => x.Id == model.Id);
            admin.Password = model.Password;
            admin.AdminEmail = model.AdminEmail;
            
            adminManager.Update(admin);

            return RedirectToAction("Admin");

        }

        public ActionResult AdminSil(int id)

        {

            Admin admin = adminManager.Find(x => x.Id == id);
            
            adminManager.Delete(admin);

            return RedirectToAction("Admin");

        }



















    }


}