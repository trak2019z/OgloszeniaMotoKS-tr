using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Users")]
    public class Users
    {
        public Users()
        {
            Cars = new HashSet<Cars>();
            Conversations = new HashSet<Conversations>();
            Favs = new HashSet<Favs>();
            DateAdded = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }

        public string Salt { get; set; }

        [Required]
        public string FirstName { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public virtual HashSet<Cars> Cars { get; set; }

        public virtual HashSet<Conversations> Conversations { get; set; }

        public virtual HashSet<Favs> Favs { get; set; }
    }
}