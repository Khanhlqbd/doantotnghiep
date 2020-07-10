using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.ViewModels
{
    public class TourView
    {
        public long ID { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string Avatar { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string Title { get; set; }
        [MaxLength(850, ErrorMessage = "Chỉ có thể nhập tối đa 850 ký tự")]
        public string Desc { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string PlaceStart { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string PlaceEnd { get; set; }
        public string DateStart { get; set; }
        public string EndDate { get; set; }
        /// <summary>
        /// Description for time with string
        /// </summary>
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string DescTime { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
    }
}
