using MotoKS.Models;
using System.Data.Entity;

namespace MotoOgloszeniaKS.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Cars> Cars { get; set; }

        public DbSet<Conversations> Conversations { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Photos> Photos { get; set; }

        public DbSet<Favs> Favs { get; set; }

        public DbSet<Brands> Brands { get; set; }

        public DbSet<CarModels> CarModels { get; set; }
    }
}