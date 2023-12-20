using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    class Peripherals
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public virtual PeripheralsType PeripheralsType { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
