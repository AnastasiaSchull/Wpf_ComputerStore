using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderCart> OrderCarts { get; set; }
    }
}
