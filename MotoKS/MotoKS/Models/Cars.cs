using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Cars")]
    public class Cars
    {
        public Cars()
        {
            Conversations = new HashSet<Conversations>();
            DateAdded = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime DateAdded { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

        public int ProdDate { get; set; }

        public int Mileage { get; set; }

        public bool Netto { get; set; }

        public bool Negotiable { get; set; }

        public bool Damaged { get; set; }

        public bool OC { get; set; }

        public bool Registered { get; set; }

        public virtual Users User { get; set; }

        public virtual HashSet<Conversations> Conversations { get; set; }
    }
}