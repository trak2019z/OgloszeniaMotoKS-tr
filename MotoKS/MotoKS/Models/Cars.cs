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
            Photos = new HashSet<Photos>();
            DateAdded = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int ProdDate { get; set; }

        [Required]
        public int Mileage { get; set; }

        public bool Netto { get; set; }

        public bool Negotiable { get; set; }

        public bool Damaged { get; set; }

        public bool OC { get; set; }

        public bool Registered { get; set; }

        public string Country { get; set; }

        public bool VAT { get; set; }

        public bool Leasing { get; set; }

        [Required]
        public string Engine { get; set; }

        [Required]
        public int bHP { get; set; }

        public string Color { get; set; }

        public string Desc { get; set; }

        public bool FirstOwner { get; set; }

        public bool ASO { get; set; }

        public bool NoAcc { get; set; }

        public string MainPhoto { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public int Favs { get; set; }
        
        public int Views { get; set; }

        public Drive Drive { get; set; }

        [Required]
        public Fuel Fuel { get; set; }

        [Required]
        public Gearbox Gearbox { get; set; }

        [Required]
        public State State { get; set; }

        public Type Type { get; set; }

        public virtual Users User { get; set; }

        public virtual Brands Brand { get; set; }

        public virtual CarModels CarModel { get; set; }

        public virtual HashSet<Conversations> Conversations { get; set; }

        public virtual HashSet<Photos> Photos { get; set; } 
    }
}