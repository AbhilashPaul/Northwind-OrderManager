using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// <summary>
    /// Defines the data access class for an order item
    /// </summary>
    public static class OrderItemDB
    {
        /// <summary>
        /// Retrieves order details for the specified order id from Order Details table
        /// </summary>
        /// <param name="orderID"> speciifed order id</param>
        /// <returns> the order item object created using retrieved order details</returns>
        public static List<OrderItem> GetOrderItems(int orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            OrderItem ordItem = null;
            using (SqlConnection connection = NorthwindDB.GetConnection(Environment.MachineName))
            {
                string selectQuery = "SELECT ProductID, UnitPrice, Quantity, Discount " +
                                     "FROM [Order Details] " +
                                     "WHERE OrderID = @OrderID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())                                                   // while there are order items
                        {
                            ordItem = new OrderItem();
                            ordItem.ProductID = Convert.ToInt32(reader["ProductID"]);
                            ordItem.UnitPrice = Math.Round(Convert.ToDecimal(reader["UnitPrice"]),2);
                            ordItem.Quantity = Convert.ToInt32(reader["Quantity"]);
                            ordItem.Discount = Math.Round(Convert.ToDecimal(reader["Discount"]),3);
                            orderItems.Add(ordItem);
                        }
                    }
                }
            }       
            return orderItems;
        }
    }
}
