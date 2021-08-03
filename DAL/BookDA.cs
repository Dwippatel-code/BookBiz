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
    class BookDA
    {
        private static string filePathBK = Application.StartupPath + @"\BOOK.dat";
        private static string fileTempBK = Application.StartupPath + @"\TempBOOK.dat";

        public static Book AddToLst(int ISBN)
        {
            Book bk = new Book();

            StreamReader sReader = new StreamReader(filePathBK);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                if (ISBN == Convert.ToInt32(fields[0]))    //  Comparing value
                {
                    bk.ISBN = Convert.ToInt32(fields[0]);    //  Assigning the data in First column of view
                    bk.Title = fields[1];    //  Assigning the data in second column of view
                    bk.YearPublished = int.Parse(fields[2]);    //  Assigning the data in third column of view
                    bk.UnitPrice = decimal.Parse(fields[3]);    //  Assigning the data in fourth column of view
                    bk.QOH = int.Parse(fields[4]);    //  Assigning the data in fourth column of view
                    sReader.Close();
                    return bk;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();    //closing the file
            return null;
        }

        public static void Save(Book bk)
        {


            StreamWriter sWriter = new StreamWriter(filePathBK, true);    //create object to write data to the path
            sWriter.WriteLine(bk.ISBN + "," + bk.Title + "," + bk.YearPublished + "," + bk.UnitPrice + "," + bk.QOH);    // store data with saperator
            sWriter.Close();
            MessageBox.Show("Book Data has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static void Update(Book bk)
        {


            StreamWriter sWriter = new StreamWriter(filePathBK, true);    //create object to write data to the path
            sWriter.WriteLine( bk.QOH);    // store data with saperator
            sWriter.Close();
            MessageBox.Show("Book Stock has been Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static void LstBok(ListView BookView)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePathBK);
            BookView.Items.Clear();


            string line = sReader.ReadLine();   //  Read line by line
            while (line != null)        //  Read the file until teh end of the file
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);   //  Add data to the listView control
                item.SubItems.Add(fields[2]);   //  Add data to the listView control
                item.SubItems.Add(fields[3]);   //  Add data to the listView control
                item.SubItems.Add(fields[4]);   //  Add data to the listView control



                BookView.Items.Add(item);    //  Add data to the listView control
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }
        public static Book Search(int custId)
        {
            Book cust = new Book();
            StreamReader sReader = new StreamReader(filePathBK);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (custId == Convert.ToInt32(fields[0]))
                {
                    cust.ISBN = Convert.ToInt32(fields[0]);
                    cust.Title = fields[1];
                    cust.UnitPrice = Convert.ToInt32(fields[2]);
                    cust.YearPublished = Convert.ToInt32(fields[3]);
                    cust.QOH = Convert.ToInt32(fields[4]);
                    sReader.Close();
                    return cust;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static void LstBokStock(ListView BookView)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePathBK);
            BookView.Items.Clear();


            string line = sReader.ReadLine();   //  Read line by line
            while (line != null)        //  Read the file until teh end of the file
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);   //  Add data to the listView control
                item.SubItems.Add(fields[-1]);   //  Add data to the listView control
                item.SubItems.Add(fields[3]);   //  Add data to the listView control
                item.SubItems.Add(fields[4]);   //  Add data to the listView control



                BookView.Items.Add(item);    //  Add data to the listView control
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }
        public static void Delete(int custId)
        {
            StreamReader sReader = new StreamReader(filePathBK);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempBK, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((custId) != (Convert.ToInt32(fields[0])))

                {

                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] );


                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();
            sWriter.Close();
            //Delete the old file : Customers.dat
            File.Delete(filePathBK); // Problem here : solved, see the Search method
            File.Move(fileTempBK, fileTempBK);

        }
    }
}