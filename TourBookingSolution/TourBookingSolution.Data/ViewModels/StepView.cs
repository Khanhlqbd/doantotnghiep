using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.ViewModels
{
   public class StepView
    {
        public long ID { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string Place { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Name { get; set; }
        public string GuideName { get; set; }
        [MaxLength(800, ErrorMessage = "Chỉ có thể nhập tối đa 800 ký tự")]
        public string Desc { get; set; }
        public int Rank { get; set; }
        public long Tour { get; set; }
        public string TourName { get; set; }

    }
}
