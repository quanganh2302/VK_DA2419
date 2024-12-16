using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA2419_Application_VS19.Component
{
    class InputValid : TextBox
    {
        private float minValue = -155.0f;
        private float maxValue = 155.0f;
        [Category("Custom props")]
        public float MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        [Category("Custom props")]
        public float MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public InputValid()
        {
            this.KeyPress += NumberTextBox_KeyPress;
            this.TextChanged += NumberTextBox_TextChanged;
            this.Leave += NumberTextBox_Leave;
        }

        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits, a single decimal point, and a negative sign
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one negative sign at the beginning
            if (e.KeyChar == '-' && (this.Text.Contains("-") || this.SelectionStart != 0))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && this.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            // Allow a single negative sign
            if (this.Text == "-")
            {
                return;
            }

            if (float.TryParse(this.Text, out float value))
            {
                if (value < minValue || value > maxValue)
                {
                    MessageBox.Show($"Please enter a number between {minValue} and {maxValue}.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Text = string.Empty;
                }
            }
            else if (!string.IsNullOrEmpty(this.Text))
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Text = string.Empty;
            }
        }

        private void NumberTextBox_Leave(object sender, EventArgs e)
        {
            if (float.TryParse(this.Text, out float value))
            {
                this.Text = value.ToString("0.00");
            }
        }
    }
}