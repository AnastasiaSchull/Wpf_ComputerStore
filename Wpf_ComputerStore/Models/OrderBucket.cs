using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    class OrderBucket
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public List<ComputerDetail> ComputerDetails { get; set; }
    }
}
