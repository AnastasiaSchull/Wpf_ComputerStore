using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class ComputerType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Computer> Computers { get; set; }
    }
}
