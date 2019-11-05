using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderData;
using System.Windows.Forms;
using System.Data.SqlClient;
/*
 Application to view and manage order and order details.
    - Allows retrieval of order and order details information from database by order id.
    - Allows setting/updating shipped date
   
  Authored by: Abhilash Paul
  Date: 15th July 2019
 */
namespace OrderManager
{
    public partial class OrderManagerForm : Form
    {
        public OrderManagerForm()
        {
            InitializeComponent();
        }

        private Order order;                                                    //current order
        List<OrderItem> orderItems;                                             //list of items in the order
        

        /// <summary>
        /// This event handler retrieves the order information and order details of the user specified order id and display it on the form
        /// </summary>
        private void btnGetOrder_Click(object sender, EventArgs e)              //when 'Get Order' button is clicked
        {
            if (Validator.IsPresent(txtOrderID) &&                              //check if order id is present                                    
                Validator.IsInt32(txtOrderID))                                  //chech if it is a positive integer
            {
                int orderID = Convert.ToInt32(txtOrderID.Text);                 //get the order ID

                this.GetOrder(orderID);                                         //ge the order details

                if (order == null)                                              //if no order record returned
                {
                    this.ClearControls();                                       //clear the textboxes
                    MessageBox.Show("No Order record found with this ID. " +    //show order not found message
                         "Please try again.", "Order Not Found");
                    txtOrderID.Select(0, txtOrderID.Text.Length);
                    txtOrderID.Focus();
                }
                else
                {
                    this.DisplayOrder();                                        //display order details
                    this.GetOrderDetails(order.OrderID);
                }
                                                 
            }
        }

        /// <summary>
        /// Function to retrieve the order information of the user specified order id from the Orders table
        /// </summary>
        /// <param name="orderID"> user sepcified order id</param>
        private void GetOrder(int orderID)
        {
            try
            {
                order = OrderDB.GetOrder(orderID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Displays order info on the form
        /// </summary>
        private void DisplayOrder()
        {
            txtCustomerID.Text = order.CustomerID;                                              //display customer ID on the text box

            if (order.OrderDate == null)                                                        //display an empty string id the order dat is 'null'
            {
                txtOrderDate.Text = " ";
            }
            else
            {
                txtOrderDate.Text = ((DateTime)order.OrderDate).ToString("d");                  //display the order date
            }

            if (order.RequiredDate == null)                                                     //display an empty string id the order date is 'null'
            {
                txtRequiredDate.Text = " ";
            }
            else
            {
                txtRequiredDate.Text = ((DateTime)order.RequiredDate).ToString("d");            //display the required date
            }

            if (order.ShippedDate == null)                                                      //display an empty string id the required date is 'null'
            {
                dtpShippedDate.CustomFormat = " ";
                dtpShippedDate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpShippedDate.Format = DateTimePickerFormat.Short;                             //display shipped date
                dtpShippedDate.Value = (DateTime)order.ShippedDate;
            }

        }

        /// <summary>
        /// Function to retrieve the order derails of the user specified order id from the Order Details table
        /// </summary>
        /// <param name="orderID">user sepcified order id</param>
        private void GetOrderDetails(int orderID)
        {
            orderItems = new List<OrderItem>();                                                
            try
            {
                orderItems = OrderItemDB.GetOrderItems(order.OrderID);                          // get the orde rdetails for the specified order id
                dataGridViewOrderItems.DataSource = orderItems;                                 // bind the order details data to the data grid view
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading order items data: " + ex.Message,
                    ex.GetType().ToString());
            }

            DisplayOrderTotal();
        }

        /// <summary>
        /// Calculates total order amount and displays it in the text box
        /// </summary>
        private void DisplayOrderTotal()
        {
            decimal Total = 0;
            foreach (OrderItem item in orderItems)
            {
                Total += item.OrderItemTotal(item.Quantity, item.UnitPrice, item.Discount);
            }
            txtTotal.Text = Total.ToString("c");
        }


       
        /// <summary>
        /// Updates the shipped date if the given date is no earlier than order date and no later than required date
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order();
            newOrder.CopyOrder(order);
            if(Validator.ValidateShippedDate(order, dtpShippedDate))                //checks if the given date is between order date and rquired date
            {
                newOrder.ShippedDate = dtpShippedDate.Value;                        
                try
                {
                    if (!OrderDB.UpdateShippedDate(order, newOrder))                // optimistic oncurrency violation
                    {
                        MessageBox.Show("Another user has updated or " +
                            "deleted that customer.", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else                                                            // successfully updated
                    {
                        order = newOrder;                                           //update the old order object
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

            }
        }


        /// <summary>
        /// This function clears all the controls
        /// </summary>
        private void ClearControls()
        {
            txtCustomerID.Text = "";
            txtOrderDate.Text = "";
            txtRequiredDate.Text = "";
            dtpShippedDate.Format = DateTimePickerFormat.Custom;
            btnUpdate.Enabled = false;
            txtCustomerID.Select();
            txtTotal.Text = "";
            dataGridViewOrderItems.DataSource = null;
        }

        /// <summary>
        /// This eventhandler enables the update shipped date button when the shipped date value is changed
        /// </summary>
        private void dtpShippedDate_ValueChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnNullShippedDate.Enabled = true;
        }

        /// <summary>
        /// This eventhandler switches the date format to 'short' on mouse down on the date picker.
        /// </summary>
        private void dtpShippedDate_MouseDown(object sender, MouseEventArgs e)
        {
            dtpShippedDate.Format = DateTimePickerFormat.Short;
        }

        /// <summary>
        /// exit button event handler 
        /// </summary>
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// This event handler handles assignment of null value to shipped date when button is clicked.
        /// </summary>
        private void btnNullShippedDate_Click(object sender, EventArgs e)
        {
            dtpShippedDate.Format = DateTimePickerFormat.Custom;
            Order newOrder = new Order();
            newOrder.CopyOrder(order);                                      //copy the order info to a new object
            newOrder.ShippedDate = null;                                    //set it's shipped date to null
            
            //update the order record in databse  
            try                                                                    
            {
                if (!OrderDB.UpdateShippedDate(order, newOrder))            // optimistic oncurrency violation
                {
                    MessageBox.Show("Another user has updated or " +
                        "deleted that customer.", "Database Error");
                    this.DialogResult = DialogResult.Retry;
                }
                else                                                        // successfully updated
                {
                    order = newOrder;                                       //update the old order object
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
    
}
