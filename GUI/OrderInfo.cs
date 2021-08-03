using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz.DAL;
using BookBiz.Validator;
using BookBiz.BLL;
using System.IO;
using BookBiz.GUI;

namespace BookBiz.GUI
{
    public partial class OrderInfo : Form
    {
        public OrderInfo()
        {
            InitializeComponent();
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home HOME = new Home();
            HOME.Show();
            this.Hide();
        }

        private void btn_AddToList_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_OrID)))
            {
                Order ord = new Order();


                ord.OrderID = Convert.ToInt32(txt_OrID.Text);
                ord.Title = txt_title.Text;
                ord.quentity = txt_que.Text;
                ord.phone = txt_phone.Text;
                OrderDA.Save(ord);

               

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            OrderDA.Delete(Convert.ToInt32(txt_input.Text));
            MessageBox.Show("Order Record data has beeen deleted", "DONE");
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Order cust = OrderDA.Search(Convert.ToInt32(txt_input.Text));
            if (cust != null)
            {
                txt_OrID.Text = (cust.OrderID).ToString();
                txt_title.Text = (cust.Title);
                txt_que.Text = cust.quentity;
                txt_phone.Text = cust.phone;
            }
            else
            {
                MessageBox.Show("Order not Found");
                txt_input.Clear();
                txt_input.Focus();
            }
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            drp_Search.SelectedIndex = -1;
            OrderDA.LstOrder(View_ord);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
