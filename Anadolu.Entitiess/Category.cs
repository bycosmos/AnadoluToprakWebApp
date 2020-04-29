using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.Entitiess
{
    public class Category : EntityBase
    {
      
        public virtual List<Product> Products { get; set; }
        

       

    }
}
