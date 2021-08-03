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
    public partial class BookInfo : Form
    {
        List<Book> listB = new List<Book>();

        public BookInfo()
        {
            InitializeComponent();
            btn_AddToList.Enabled = true;

        }
        private void ClearAll()
        {
            txt_ISBN.Clear();
            txt_Title.Clear();
            txt_Price.Clear();
            txt_qty.Clear();

            txt_ISBN.Focus();

        }

        private void btn_List_Click(object sender, EventArgs e)
        {

            drp_Search.SelectedIndex = -1;
            BookDA.LstBok(View_Book);
           
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_ISBN)))
            {
                Book bk = new Book();


                bk.ISBN = Convert.ToInt32(txt_ISBN.Text);
                bk.Title = txt_Title.Text;
                bk.YearPublished = Convert.ToInt32(txt_Published.Text);
                bk.UnitPrice = Convert.ToDecimal(txt_Price.Text);
                bk.QOH = Convert.ToInt32(txt_qty.Text);

                BookDA.Save(bk);

                ClearAll();

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            BookDA.Delete(Convert.ToInt32(txt_input.Text));
            MessageBox.Show("Book record has been removed", "DONE");
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddToList_Click(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_ISBN)) && (Validation.IsValidYear(txt_Published)))
            {


                Book aBook = new Book();
                aBook.ISBN = Convert.ToInt32(txt_ISBN.Text);

                int choice = Convert.ToInt32(txt_ISBN.Text);

                if (aBook.ISBN == choice)
                {
                    MessageBox.Show("Book ID Already Exists!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_ISBN.Clear();
                    txt_ISBN.Focus();
                }
                else
                {
                    aBook.Title = txt_Title.Text;
                    aBook.YearPublished = int.Parse(txt_Published.Text);
                    aBook.UnitPrice = decimal.Parse(txt_Price.Text);
                    aBook.QOH = int.Parse(txt_qty.Text);

                    //Add to the list
                    listB.Add(aBook);
                    //  MessageBox.Show("Customer Info has been added to the list.","Confirmation");
                    btn_AddToList.Enabled = true;
                    ClearAll();
                }
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Home HOME = new Home();
            HOME.Show();
            this.Hide();
        }

       private void btn_Search_Click(object sender, EventArgs e)
        {
            {
                Book cust = BookDA.Search(Convert.ToInt32(txt_input.Text));
                if (cust != null)
                {
                    txt_ISBN.Text = (cust.ISBN).ToString();
                   
                    txt_Price.Text = (cust.UnitPrice).ToString();
                    txt_Published.Text = (cust.YearPublished).ToString();

                    txt_qty.Text = (cust.QOH).ToString();
                    txt_Title.Text = (cust.Title);
                }

                else
                {
                    MessageBox.Show("Author not Found");
                    txt_input.Clear();
                    txt_input.Focus();
                }

            }
        }
    }
}
