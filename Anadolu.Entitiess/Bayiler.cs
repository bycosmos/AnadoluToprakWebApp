using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.Entitiess
{
   public class Bayiler:EntityBase
    {




        public string Telefon { get; set; }



        public string Fax { get; set; }




        public string Adres { get; set; }




        public string Email { get; set; }




        public int IllerId { get; set; }


        public virtual Iller Iller { get; set; }


    }
}
