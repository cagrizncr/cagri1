using SigortamNetProject.Models;
using System.Data.Entity;

namespace SigortamNetProject.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DataModel> Datas { get; set; }
        public DbSet<OfferModel> Offers { get; set; }

        public DatabaseContext()
        {
            //Database.SetInitializer(new MyInitializer());
        }
    }
}