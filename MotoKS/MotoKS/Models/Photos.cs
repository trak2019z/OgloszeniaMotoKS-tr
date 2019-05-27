using System.ComponentModel.DataAnnotations.Schema;

namespace MotoKS.Models
{
    [Table("Photos")]
    public class Photos
    {
        public string Name { get; set; }

        public virtual Cars Car { get; set; }
    }
}