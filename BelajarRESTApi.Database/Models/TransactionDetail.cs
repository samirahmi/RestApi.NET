using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BelajarRESTApi.Database.Models
{
    [Table("TransactionDetail", Schema = "dbo")]
    public class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Transaction Detail Id")]
        public int TransactionDetailId { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public int SubTotal { get; set; }

        public virtual Product Products { get; set; }
        public virtual Transaction Transactions { get; set; }
    }
}
