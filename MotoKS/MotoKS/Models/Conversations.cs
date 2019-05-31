using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Conversations")]
    public class Conversations
    {
        public Conversations()
        {
            Messages = new HashSet<Messages>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public virtual Cars Car { get; set; }

        public virtual Users Seller { get; set; }

        public virtual Users Buyer { get; set; }

        public virtual HashSet<Messages> Messages { get; set; }
    }
}