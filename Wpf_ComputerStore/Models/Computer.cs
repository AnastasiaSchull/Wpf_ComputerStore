using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_ComputerStore.Models;

namespace Wpf_ComputerStore.Models
{
    public class Computer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ComputerType ComputerType { get; set; }
        public virtual ComputerDetail RAM { get; set; }
        public virtual ComputerDetail Motherboard { get; set; }
        public virtual ComputerDetail CPU { get; set; }      
        public virtual ComputerDetail HardDrive { get; set; }
        public virtual ComputerDetail SSD { get; set; }
        public virtual ComputerDetail VideoCard { get; set; }
        public virtual ComputerDetail PowerSupply { get; set; }      
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
