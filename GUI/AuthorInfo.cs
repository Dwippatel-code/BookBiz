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

namespace BookBiz
{
    public partial class AuthorInfo : Form
    {
        List<Author> listA = new List<Author>();

        public AuthorInfo()
        {
            InitializeComponent();
            btn_AddToList.Enabled = true;

        }
        private void ClearAll()
        {
            txt_AuID.Clear();
            txt_fName.Clear();
            txt_lName.Clear();
            txt_email.Clear();
            txt_AuID.Focus();

        }

        private void btn_AddToList_Click(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_AuID)))
            {

            
                Author aAuthor = new Author();
                aAuthor.AuthorID = Convert.ToInt32(txt_AuID.Text);

                int choice = Convert.ToInt32(txt_AuID.Text);

                if (aAuthor.AuthorID == choice)
                {
                    MessageBox.Show("Auther ID Already Exists!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_AuID.Clear();
                    txt_AuID.Focus();
                }
                else
                {
                    aAuthor.AuthorID = Convert.ToInt32(txt_AuID.Text);
                    aAuthor.FirstName = txt_fName.Text;
                    aAuthor.LastName = txt_lName.Text;
                    aAuthor.Email = txt_email.Text;
                    //Add to the list
                    listA.Add(aAuthor);
                    //  MessageBox.Show("Customer Info has been added to the list.","Confirmation");
                    btn_AddToList.Enabled = true;
                    ClearAll();
                }

            }
            
           

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_AuID)))
            {
                Author auth = new Author();


                auth.AuthorID = Convert.ToInt32(txt_AuID.Text);
                auth.FirstName = txt_fName.Text;
                auth.LastName = txt_lName.Text;
                auth.Email = txt_email.Text;
                AuthorDA.Save(auth);

                ClearAll();

            }
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            drp_Search.SelectedIndex = -1;
            AuthorDA.LstAuthor(View_Stud);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Menu_User_Click(object sender, EventArgs e)
        {
            EmployeeInfo user = new EmployeeInfo();
            user.Show();
            this.Hide();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            AuthorDA.Delete(Convert.ToInt32(txt_input.Text));
            MessageBox.Show("Student data has beeen deleted", "DONE");
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btn_ToHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Author cust = AuthorDA.Search(Convert.ToInt32(txt_input.Text));
            if (cust != null)
            {
                txt_AuID.Text = (cust.AuthorID).ToString();
                txt_fName.Text = (cust.FirstName);
                txt_lName.Text = cust.LastName;
                txt_email.Text = cust.Email;
            }
            else
            {
                MessageBox.Show("Author not Found");
                txt_input.Clear();
                txt_input.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home HOME = new Home();
            HOME.Show();
            this.Hide();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void View_Stud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void drp_Search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_lName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_fName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_AuID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
