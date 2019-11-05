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
    ///Defines the data access class for an order
    /// </summary>
    public static class OrderDB
    {
        /// <summary>
        /// Retrieves order information for the specified order id
        /// </summary>
        /// <param name="orderID"> speciifed order id</param>
        /// <returns> the order object created using retrieved order information</returns>
        public static Order GetOrder(int orderID)
        {
            Order order = null;
            using (SqlConnection connection = NorthwindDB.GetConnection(Environment.MachineName))                      //initialize db connection                            
            {
                string selectQuery = "SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate " +
                                     "FROM Orders " +
                                     "WHERE OrderID = @OrderID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))                //initialize sqlcommand
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);                           // data bind order id                                              
                    connection.Open();                                                          //open connection
                    using (SqlDataReader reader = cmd.ExecuteReader())                          //initialize reader
                    {
                        if (reader.Read()) // we have  a customer
                        {
                            order = new Order();
                            order.OrderID = (int)reader["OrderID"];
                            order.CustomerID = reader["CustomerID"].ToString();

                            // for the columns that can be null, determine if returns null from data base and set the variables accordingly
                            if (Convert.IsDBNull(reader["OrderDate"]))                          // if reader contains DBNull in this column
                                order.OrderDate = null;                                         // make it null in the object
                            else                                                                // it is not null
                                order.OrderDate = (DateTime)reader["OrderDate"];

                            if (Convert.IsDBNull(reader["RequiredDate"]))                       // if reader contains DBNull in this column
                                order.RequiredDate = null;                                      // make it null in the object
                            else                                                                // it is not null
                                order.RequiredDate = (DateTime)reader["RequiredDate"];

                            if (Convert.IsDBNull(reader["ShippedDate"]))                        // if reader contains DBNull in this column
                                order.ShippedDate = null;                                       // make it null in the object
                            else                                                                // it is not null
                                order.ShippedDate = (DateTime)reader["ShippedDate"];
                        }
                    }
                }
            }

            return order;
        }

        /// <summary>
        /// Updates the shipped dtae of the order
        /// </summary>
        /// <param name="oldOrder"> old order object</param>
        /// <param name="newOrder"> new order object with new shipped date</param>
        /// <returns></returns>
        public static bool UpdateShippedDate(Order oldOrder, Order newOrder)
        {
            bool success = true;
            using (SqlConnection connection = NorthwindDB.GetConnection(Environment.MachineName))                          //initialize db connection 
            {
                string updateStatement = "UPDATE Orders SET " +
                                     "ShippedDate = @NewShippedDate " +
                                     "WHERE OrderID = @OldOrderID " +                               // to identify record to update
                                     "AND CustomerID = @OldCustomerID " +                           // remaining conditions for optimistic concurrency
                                     "AND OrderDate = @OldOrderDate " +
                                     "AND RequiredDate = @OldRequiredDate";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))                //initialize sqlcommand
                {

                    cmd.Parameters.AddWithValue("@OldOrderID", oldOrder.OrderID);
                    cmd.Parameters.AddWithValue("@OldCustomerID", oldOrder.CustomerID);

                    //set shipped date to DBNull shipped date is 'null'
                    if (newOrder.ShippedDate == null)
                    {
                        cmd.Parameters.AddWithValue("@NewShippedDate", DBNull.Value);               
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NewShippedDate", newOrder.ShippedDate);
                    }

                    //set shipped date to DBNull order date is 'null'
                    if (oldOrder.OrderDate == null)
                    {
                        cmd.Parameters.AddWithValue("@OldOrderDate", DBNull.Value);               
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OldOrderDate", oldOrder.OrderDate);
                    }

                    //set shipped date to DBNull required date is 'null'
                    if (oldOrder.RequiredDate == null)
                    {
                        cmd.Parameters.AddWithValue("@OldRequiredDate", DBNull.Value);               
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@OldRequiredDate", oldOrder.RequiredDate);
                    }

                    connection.Open();                                                              //open connection
                    int rowsUpdated = cmd.ExecuteNonQuery();                                        //number of rows affected
                    if (rowsUpdated == 0) success = false;                                          // did not update (another user updated or deleted)

                }
                return success;
            }
        }
    }
}
