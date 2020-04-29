using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.Entitiess
{
  public  class Siparis : EntityBase
    {


        public string UrunAdi { get; set; }

        public string MusteriAdiSoyAdi { get; set; }

        public string Email { get; set; }


        public string Adet { get; set; }


        public string Fiyat { get; set; }


        public string ToplamOrtalamaTutar { get; set; }





        public string Adres { get; set; }



        public string Telefon { get; set; }

        public string Il { get; set; }


        public string Ilce { get; set; }

        public string EkBilgi { get; set; }

        public bool Musteri { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]

        public DateTime Tarih { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime DüzenlenmeTarihi { get; set; }
        public bool Durum { get; set; }

    }
}
