using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.Entitiess
{
   public class Product : EntityBase
    {
       
        public string Agirlik { get; set; }
        public string BasincDayanimi { get; set; }
        public string IsiIletkenligi { get; set; }
        public string MetrekareTuglaSayisi { get; set; }
        public string UrunResimAdres { get; set; }
        public string Boyut { get; set; }
        public string Fiyat { get; set; }

        public string PaletSayisi { get; set; }

        public string UrunEkBilgi { get; set; }

        public string UrunEkBilgi1 { get; set; }

        public string UrunEkBilgi2 { get; set; }

        public int CategoryId { get; set; }


        public virtual Category Category { get; set; }


    }
}
