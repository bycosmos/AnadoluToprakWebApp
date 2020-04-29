using Anadolu.Entitiess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.DataAccessLayer.EntityFramework
{
    public class DataBaseContext :DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Referanslar> Referanslars { get; set; }
        public DbSet<AnaSliderResim> anaSliderResims{ get; set; }
        public DbSet<AnaFabrikaResim> anaFabrikaResims { get; set; }

        public DbSet<Iller> Illers { get; set; }



        public DbSet<Bayiler> Bayilers { get; set; }

        

        public DbSet<Videolar> Videolars { get; set; }




        public DbSet<Siparis> Siparis { get; set; }

        public DataBaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }







    }
}
