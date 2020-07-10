using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.ViewModels
{
   public class PaymentParam
    {
        public int TourID { get; set; }
        public int TypePay { get; set; }
        public string PCode { get; set; }
    }
    public class PaymentResult
    {
        public int Status { get; set; }
        public string Uri { get; set; }
    }
}
