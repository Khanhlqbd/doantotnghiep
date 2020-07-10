using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.ViewModels
{
    public class OrderView
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public long Tour { get; set; }
        public string TourName { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// 0 Await | 1 Processing | 2 Accomplished | -1 Cancel
        /// </summary>
        public int Status { get; set; }
        public bool IsPayment { get; set; }
        public int Member { get; set; }
        public string MemberName { get; set; }
        [MaxLength(2000,ErrorMessage ="Đường dẫn không được dài quá 2000 ký tự")]
        public string FileParticipants { get; set; }
        public double Price { get; set; }
        public int Step { get; set; }
        public string StepName { get; set; }
        public double Reduce { get; set; }
        public double Amount { get; set; }
    }
}
