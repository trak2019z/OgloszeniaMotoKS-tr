using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Messages")]
    public class Messages
    {
        public Messages()
        {
            Date = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        public bool Who { get; set; }

        public virtual Conversations Conv { get; set; }
    }
}