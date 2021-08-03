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
    class AuthorDA
    {
        private static string filePathAU = Application.StartupPath + @"\Author.dat";
        private static string fileTempAU = Application.StartupPath + @"\TempAuthor.dat";

        public static Author AddToLst(int stdID)
        {
            Author Auth = new Author();

            StreamReader sReader = new StreamReader(filePathAU);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                if (stdID == Convert.ToInt32(fields[0]))    //  Comparing value
                {
                    Auth.AuthorID = Convert.ToInt32(fields[0]);    //  Assigning the data in First column of view
                    Auth.FirstName = fields[1];    //  Assigning the data in second column of view
                    Auth.LastName = fields[2];    //  Assigning the data in third column of view
                    Auth.Email = fields[3];    //  Assigning the data in fourth column of view
                    sReader.Close();
                    return Auth;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();    //closing the file
            return null;
        }

        public static void Save(Author auth)
        {


            StreamWriter sWriter = new StreamWriter(filePathAU, true);    //create object to write data to the path
            sWriter.WriteLine(auth.AuthorID + "," + auth.FirstName + "," + auth.LastName + "," + auth.Email);    // store data with saperator
            sWriter.Close();
            MessageBox.Show("Author Data has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static void LstAuthor(ListView AuthorView)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePathAU);
            AuthorView.Items.Clear();


            string line = sReader.ReadLine();   //  Read line by line
            while (line != null)        //  Read the file until teh end of the file
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);   //  Add data to the listView control
                item.SubItems.Add(fields[2]);   //  Add data to the listView control
                item.SubItems.Add(fields[3]);   //  Add data to the listView control
                AuthorView.Items.Add(item);    //  Add data to the listView control
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }

        public static Author Search(int custId)
        {
            Author cust = new Author();
            StreamReader sReader = new StreamReader(filePathAU);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (custId == Convert.ToInt32(fields[0]))
                {
                    cust.AuthorID = Convert.ToInt32(fields[0]);
                    cust.FirstName = fields[1];
                    cust.LastName = fields[2];
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
            StreamReader sReader = new StreamReader(filePathAU);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempAU, true);
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
            File.Delete(filePathAU); // Problem here : solved, see the Search method
            File.Move(fileTempAU, filePathAU);

        }
    }
}
