using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* Patrick McKee - CIS123 - OOP - May 05, 2022          *
* Chapter 6 Murach Practice Assignments                 *
* Exercise 6-3 - Enhance the Invoice Total application  */

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customerType = txtCustomerType.Text;
            decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
            decimal discountPercent = .0m;

            discountPercent = GetInvoiceAmounts(customerType, subtotal, discountPercent);

            decimal discountAmount = subtotal * discountPercent;
            decimal invoiceTotal = subtotal - discountAmount;

            txtDiscountPercent.Text = discountPercent.ToString("p1");
            txtDiscountAmount.Text = discountAmount.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            txtCustomerType.Focus();
        }

        private static decimal GetInvoiceAmounts(string customerType, decimal subtotal, decimal discountPercent)
        {
            if (customerType == "R")
            {
                if (subtotal < 100)
                    discountPercent = .0m;
                else if (subtotal >= 100 && subtotal < 250)
                    discountPercent = .1m;
                else if (subtotal >= 250)
                    discountPercent = .25m;
            }
            else if (customerType == "C")
            {
                if (subtotal < 250)
                    discountPercent = .2m;
                else
                    discountPercent = .3m;
            }
            else
            {
                discountPercent = .4m;
            }

            return discountPercent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
