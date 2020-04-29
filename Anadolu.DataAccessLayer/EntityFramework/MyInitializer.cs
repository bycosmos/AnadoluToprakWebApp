using Anadolu.Entitiess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.DataAccessLayer.EntityFramework
{
  public  class MyInitializer: CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            Admin admin = new Admin()
            {
                AdminEmail = "azizvefa15@gmail.com",
                Password = "542",
               
            };
            context.Admins.Add(admin);

            Category cat = new Category()
            {
                Name = "Tugla",
                

            };
            context.Categories.Add(cat);
            Category cat1 = new Category()
            {
                Name = "Kiremit",


            };
            context.Categories.Add(cat1);
            Category cat2 = new Category()
            {
                Name = "OzelUrun",


            };
            context.Categories.Add(cat2);

            context.SaveChanges();
        }

    }
}
