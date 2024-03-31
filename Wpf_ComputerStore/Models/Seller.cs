using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public string Name { get; set; }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                // Перевірка на коректність за допомогою регулярного виразу
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Неправильний формат електронної пошти");
                }
            }
        }
        public virtual ICollection<OrderCart> OrderCarts { get; set; }
    }
}
