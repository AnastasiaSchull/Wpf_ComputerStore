using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
     class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<ComputerDetail> ComputerDetails { get; set; }
    }
}
