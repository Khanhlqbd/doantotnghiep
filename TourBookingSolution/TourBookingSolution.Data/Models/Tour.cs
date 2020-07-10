using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.Models
{
    [Table("Tours")]
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(350)]
        public string Avatar { get; set; }
        [MaxLength(350)]
        public string Title { get; set; }
        [MaxLength(850)]
        public string Desc { get; set; }
        [MaxLength(350)]
        public string PlaceStart { get; set; }
        [MaxLength(350)]
        public string PlaceEnd { get; set; }
        public string Content { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Description for time with string
        /// </summary>
        [MaxLength(250)]
        public string DescTime { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
    }
}
