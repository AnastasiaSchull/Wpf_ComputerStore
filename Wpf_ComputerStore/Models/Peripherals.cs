using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class Peripherals:Item
    {
        public virtual PeripheralsType PeripheralsType { get; set; }
        public string? Description { get; set; }
    }
}
