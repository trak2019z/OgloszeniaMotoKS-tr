using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Favs")]
    public class Favs
    {
        public Users User { get; set; }

        public Cars Car { get; set; }

        public DateTime Date { get; set; }
    }
}