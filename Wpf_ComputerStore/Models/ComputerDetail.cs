using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class ComputerDetail:Item
    {     
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
       
    }
}
