using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ComputerStore.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int? Discount { get; set; }
        public DateTime? DiscountDate { get; set; }

        public void ApplyDiscount(double discountPercentage, int days)
        {
            Discount = (int)discountPercentage;
            // дата окончания скидки
            DiscountDate = DateTime.Now.AddDays(days);
        }
    }
}
