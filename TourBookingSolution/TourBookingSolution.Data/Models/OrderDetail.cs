using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public long OrderID { get; set; }
        [Key]
        [Column(Order = 1)]
        public long StepID { get; set; }
        public int Rank { get; set; }
        public bool IsLastStep { get; set; }
        public bool IsAccomplish { get; set; }
        public string StepName { get; set; }
    }
}
