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
    public class Order
    {
        //
        public Order() { }

        public int OrderID { get; set; }                    //order id
        public string CustomerID { get; set; }              //customer id
        public DateTime? OrderDate { get; set; }            // nullable order date
        public DateTime? RequiredDate { get; set; }         // nullable required date
        public DateTime? ShippedDate { get; set; }          // nullable shipped date

        /// <summary>
        /// Creates a copy of the object
        /// </summary>
        /// <param name="OldOrder">objetc to be copied</param>
        public void CopyOrder(Order OldOrder)
        {
            this.OrderID = OldOrder.OrderID;
            this.CustomerID = OldOrder.CustomerID;
            this.OrderDate = OldOrder.OrderDate;
            this.RequiredDate = OldOrder.RequiredDate;
            this.ShippedDate = OldOrder.ShippedDate;
        }

    }
}
