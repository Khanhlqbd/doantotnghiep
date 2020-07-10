using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Data.ViewModels
{
   public class OrderDetailView
    {
        public long OrderID { get; set; }
        public long StepID { get; set; }
        public int Rank { get; set; }
        public bool IsLastStep { get; set; }
        public bool IsAccomplish { get; set; }
        public string StepName { get; set; }
    }
}
