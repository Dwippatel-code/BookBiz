using BookBiz.BLL;
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
using System.IO;
using BookBiz.GUI;

namespace BookBiz.GUI
{
    public partial class EmployeeInfo : Form
    {
        List<Employee> listE = new List<Employee>();

        public EmployeeInfo()
        {
            InitializeComponent();
            btn_AddToList.Enabled = true;

        }
        private void ClearAll()
        {
            txt_EmpID.Clear();
            txt_fName.Clear();
            txt_lName.Clear();
            txt_Position.Clear();
            txt_Email.Clear();
            txt_EmpID.Focus();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_AddToList_Click_1(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_EmpID)))
            {


                Employee Emp = new Employee();
                Emp.Emp_ID = Convert.ToInt32(txt_EmpID.Text);

                int choice = Convert.ToInt32(txt_EmpID.Text);

                if (Emp.Emp_ID == choice)
                {
                    MessageBox.Show("Employee ID Already Exists!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_EmpID.Clear();
                    txt_EmpID.Focus();
                }
                else
                {
                    Emp.Fname = txt_fName.Text;
                    Emp.Lname = txt_lName.Text;
                    Emp.Position = txt_Position.Text;
                    Emp.Email = txt_Email.Text;
                    //Add to the list
                    listE.Add(Emp);
                    //  MessageBox.Show("Customer Info has been added to the list.","Confirmation");
                    btn_AddToList.Enabled = true;
                    ClearAll();
                }
            }
        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            if ((Validation.IsValidID(txt_EmpID)))
            {
                Employee emp = new Employee();


                emp.Emp_ID = Convert.ToInt32(txt_EmpID.Text);
                emp.Fname = txt_fName.Text;
                emp.Lname = txt_lName.Text;
                emp.Position = txt_Position.Text;
                emp.Email = txt_Email.Text;
                EmployeeDA.Save(emp);

                ClearAll();

            }
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btn_List_Click_1(object sender, EventArgs e)
        {
            drp_Search.SelectedIndex = -1;
            EmployeeDA.LstEMP(View_Stud);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            {
                Employee cust = EmployeeDA.Search(Convert.ToInt32(txt_input.Text));
                if (cust != null)
                {
                    txt_EmpID.Text = (cust.Emp_ID).ToString();
                    txt_fName.Text = cust.Fname;
                    txt_lName.Text = cust.Lname;
                    txt_Email.Text = cust.Email;
                }

                else
                {
                    MessageBox.Show("Author not Found");
                    txt_input.Clear();
                    txt_input.Focus();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home HOME = new Home();
            HOME.Show();
            this.Hide();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            EmployeeDA.Delete(Convert.ToInt32(txt_input.Text));
            MessageBox.Show("Employee record has been removed", "Done");
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {

        }
    }

}
