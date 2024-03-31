using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class Category
    {       
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ComputerDetail> ComputerDetails { get; set; }
    }
}
