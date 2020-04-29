using Anadolu.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anadolu.WebApp.Models
{
    public class HomeIndexModel
    {
       public IEnumerable<AnaSliderResim> anaSliderResims { get; set; }

       public IEnumerable<AnaFabrikaResim> anaFabrikaResims { get; set; }
        
       public IEnumerable<Referanslar> referanslars { get; set; }
    }
}