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
    }
}