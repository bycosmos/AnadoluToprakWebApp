using Anadolu.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anadolu.WebApp.Models
{
    public class GaleriModel
    {

        public IEnumerable<Photo> photos { get; set; }

        public IEnumerable<Videolar> videolars { get; set; }
    }
}