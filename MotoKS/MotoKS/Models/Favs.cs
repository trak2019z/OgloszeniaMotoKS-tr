using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Favs")]
    public class Favs
    {
        public Favs()
        {
            Date = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public virtual Users User { get; set; }

        public virtual Cars Car { get; set; }

        public DateTime Date { get; set; }
    }
}