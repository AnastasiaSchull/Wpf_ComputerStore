using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class ItemForSale
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public virtual Item Item { get; set; }
        public virtual OrderCart OrderCart { get; set; }
    }
}
