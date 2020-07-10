using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.Models
{
    [Table("Orders")]
   public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(16)]
        public string Code { get; set; }
        public long Tour { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// 0 Await | 1 Processing | 2 Accomplished | -1 Cancel
        /// </summary>
        public int Status { get; set; }
        public bool IsPayment { get; set; }
        public int Member { get; set; }
        [MaxLength(2000)]
        public string FileParticipants { get; set; }
        public int Step { get; set; }
        public double Price { get; set; }
        public double Reduce { get; set; }
        public double Amount { get; set; }
    }

}
