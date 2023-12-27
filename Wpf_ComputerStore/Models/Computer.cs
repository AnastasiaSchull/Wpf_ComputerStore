using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_ComputerStore.Models;


namespace Wpf_ComputerStore.Models
{
    public class Computer
    {
        public int ID { get; set; }
        public string Name { get; set; }     
        public virtual ComputerType ComputerType { get; set; }      
        public virtual List< ComputerDetail> ComputerDetails { get; set; }
        [NotMapped]  // щоб не створювалась колонка в базі даних
        public ComputerDetail RAM
        { 
            get 
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("RAM"))
                    { computerDetail = item; break; }
                }
               // MessageBox.Show(computerDetail.Name);
                return computerDetail;
            }
           
        }

        public ComputerDetail Motherboard
        {
            get
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("Motherboard"))
                    { computerDetail = item; break; }
                }          
                return computerDetail;
            }

        }

        public ComputerDetail CPU
        {
            get
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("CPU"))
                    { computerDetail = item; break; }
                }
                return computerDetail;
            }

        }

        public ComputerDetail HardDrive
        {
            get
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("HardDrive"))
                    { computerDetail = item; break; }
                }
                return computerDetail;
            }

        }

        public ComputerDetail SDD
        {
            get
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("SDD"))
                    { computerDetail = item; break; }
                }
                return computerDetail;
            }

        }

        public ComputerDetail VideoCard
        {
            get
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("VideoCard"))
                    { computerDetail = item; break; }
                }
                return computerDetail;
            }

        }

        public ComputerDetail PowerSupply
        {
            get
            {
                ComputerDetail computerDetail = null;
                foreach (var item in ComputerDetails)
                {
                    if (item.Category.Name.Equals("PowerSupply"))
                    { computerDetail = item; break; }
                }
                return computerDetail;
            }

        }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
