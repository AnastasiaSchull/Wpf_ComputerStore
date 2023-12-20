using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class OrderCart
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public virtual List<ComputerDetail> ComputerDetails { get; set; }
        public virtual List<Peripherals> Peripherals { get; set; }
        public virtual List<Computer> Computers { get; set; }
    }
}
