using OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager
{
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Checks whether the user entered data into a text box or combo box.
        /// </summary>
        /// <param name="control">The control to be validated.</param>
        /// <returns>True if the user has entered data.</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")             // text box control type
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required input.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered an int value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered an int value.</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a postive whole number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if the new shipped date is after order date but before required date
        /// </summary>
        /// <param name="order"> Order which is to be updated</param>
        /// <param name="dtpShippedDate"> shipped date input control</param>
        /// <returns> returns true if new shipped date is after order date and before required date  </returns>
        public static bool ValidateShippedDate(Order order, DateTimePicker dtpShippedDate)
        {
            if (dtpShippedDate.Value >= order.OrderDate && dtpShippedDate.Value <= order.RequiredDate)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Shipped date shoul be neither earlier than 'Order Date' nor later than 'Required Date'", "Entry Error");
                return false;
            }
        }
    }
}
