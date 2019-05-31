using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Brands")]
    public class Brands
    {
        public Brands()
        {
            Cars = new HashSet<Cars>();
            Models = new HashSet<CarModels>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Brand { get; set; }

        public virtual HashSet<Cars> Cars { get; set; }

        public virtual HashSet<CarModels> Models { get; set; }
    }
}