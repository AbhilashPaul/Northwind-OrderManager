using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  OrderData class library defines order and order item classes and their data access classes used for  Order Manager Application.
   
  Authored by: Abhilash Paul
  Date: 15th July 2019
*/

namespace OrderData
{
    public class OrderItem
    {
        public OrderItem() { }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public decimal OrderItemTotal(int Quantity, decimal UnitPrice, decimal Discount)
        {
            return Quantity*UnitPrice*(1 - Discount);
        }
    }
}
