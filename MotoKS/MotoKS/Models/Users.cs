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
            DateAdded = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string FirstName { get; set; }

        public DateTime DateAdded { get; set; }

        public string CityName { get; set; }

        public string Phone { get; set; }

        public virtual HashSet<Cars> Cars { get; set; }

        public virtual HashSet<Conversations> Conversations { get; set; }
    }
}