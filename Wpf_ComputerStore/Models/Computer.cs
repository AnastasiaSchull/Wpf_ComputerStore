using Microsoft.EntityFrameworkCore;
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
    public class Computer: Item
    {
   
        public virtual ComputerType ComputerType { get; set; }      
        public virtual List< ComputerDetail> ComputerDetails { get; set; }
        [NotMapped]  // щоб не створювалась колонка в базі даних

        private ComputerDetail ram;
        [NotMapped]

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
            set { ram = value; }
        }
        [NotMapped]
        private ComputerDetail motherboard;
        [NotMapped]
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
            set { motherboard = value; }
        }
        [NotMapped]
        private ComputerDetail cpu;
        [NotMapped]
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
            set { cpu = value; }
        }
        [NotMapped]
        private ComputerDetail hardDrive;
        [NotMapped]
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
            set { hardDrive = value; }
        }
        [NotMapped]
        private ComputerDetail sdd;
        [NotMapped]
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
            set { sdd = value; }
        }
        [NotMapped]
        private ComputerDetail videoCard;
        [NotMapped]
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
            set { videoCard = value; }
        }
        [NotMapped]
        private ComputerDetail powerSupply;
        [NotMapped]
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
            set { powerSupply = value; }
        }

    }
}
