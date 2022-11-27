using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Database.Models
{
    [Table("Supplier", Schema ="dbo")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Supplier Id")]
        public int SupplierId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
