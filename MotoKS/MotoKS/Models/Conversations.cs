using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MotoKS.Models
{
    [Table("Conversations")]
    public class Conversations
    {
        public Conversations()
        {
            Messages = new HashSet<Messages>();
            Date = DateTime.Now;
            Count = 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public bool New { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public virtual Cars Car { get; set; }

        public virtual Users Buyer { get; set; }

        public virtual HashSet<Messages> Messages { get; set; }
    }
}