using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
     class Computer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<ComputerDetail> ComputerDetails { get; set; }

        public virtual ComputerType ComputerType { get; set; }
    }
}
