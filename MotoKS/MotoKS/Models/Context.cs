using System.Data.Entity;

namespace MotoOgloszeniaKS.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }
    }
}