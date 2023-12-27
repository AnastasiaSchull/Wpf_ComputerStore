using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class ComputerDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
      
    }
}
