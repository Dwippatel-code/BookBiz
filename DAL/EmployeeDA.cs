using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz.BLL;
using System.Windows.Forms;
using System.IO;

namespace BookBiz.DAL
{
    class EmployeeDA
    {
        private static string filePathEMP = Application.StartupPath + @"\Employee.dat";
        private static string fileTempEMP = Application.StartupPath + @"\TempEmployee.dat";

        public static Employee AddToLst(int empID)
        {
            Employee Emp = new Employee();

            StreamReader sReader = new StreamReader(filePathEMP);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                if (empID == Convert.ToInt32(fields[0]))    //  Comparing value
                {
                    Emp.Emp_ID = Convert.ToInt32(fields[0]);    //  Assigning the data in First column of view
                    Emp.Fname = fields[1];    //  Assigning the data in second column of view
                    Emp.Lname = fields[2];    //  Assigning the data in third column of view
                    Emp.Position = fields[3];    //  Assigning the data in third column of view
                    Emp.Email = fields[4];    //  Assigning the data in fourth column of view
                    sReader.Close();
                    return Emp;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();    //closing the file
            return null;
        }

        public static void Save(Employee emp)
        {


            StreamWriter sWriter = new StreamWriter(filePathEMP, true);    //create object to write data to the path
            sWriter.WriteLine(emp.Emp_ID + "," + emp.Fname + "," + emp.Lname + "," + emp.Position + "," + emp.Email);    // store data with saperator
            sWriter.Close();
            MessageBox.Show("Employee Data has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static void LstEMP(ListView EmpView)
        {
            //step 1: Create an object of type StreamReader
       
            StreamReader sReader = new StreamReader(filePathEMP);
            EmpView.Items.Clear();


            string line = sReader.ReadLine();   //  Read line by line
            while (line != null)        //  Read the file until teh end of the file
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);   //  Add data to the listView control
                item.SubItems.Add(fields[2]);   //  Add data to the listView control
                item.SubItems.Add(fields[3]);   //  Add data to the listView control
                item.SubItems.Add(fields[4]);   //  Add data to the listView control
                EmpView.Items.Add(item);    //  Add data to the listView control
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }
        public static Employee Search(int custId)
        {
            Employee cust = new Employee();
            StreamReader sReader = new StreamReader(filePathEMP);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (custId == Convert.ToInt32(fields[0]))
                {
                    cust.Emp_ID = Convert.ToInt32(fields[0]);
                    cust.Fname = fields[1];
                    cust.Lname = fields[2];
                    cust.Email = fields[3];
                    sReader.Close();
                    return cust;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int custId)
        {
            StreamReader sReader = new StreamReader(filePathEMP);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempEMP, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((custId) != (Convert.ToInt32(fields[0])))

                {

                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);


                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();
            sWriter.Close();
            //Delete the old file : Customers.dat
            File.Delete(filePathEMP); // Problem here : solved, see the Search method
            File.Move(fileTempEMP, fileTempEMP);

        }
    }

}
