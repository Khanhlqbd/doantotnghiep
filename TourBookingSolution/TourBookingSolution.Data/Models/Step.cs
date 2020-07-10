using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.Models
{
    [Table("Steps")]
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string Place { get; set; }
        public string GuideName { get; set; }
        [MaxLength(800)]
        public string Desc { get; set; }
        public int Rank { get; set; }
        public long Tour { get; set; }
    }
}
