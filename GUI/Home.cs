using BookBiz.BLL;
using BookBiz.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookBiz.DAL
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EmployeeInfo employee = new EmployeeInfo();
            employee.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookInfo BOOK = new BookInfo();
            BOOK.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuthorInfo author = new AuthorInfo();
            author.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderInfo order = new OrderInfo();
            order.Show();
            this.Hide();
        }
    }
}
