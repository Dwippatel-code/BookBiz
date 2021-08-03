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
    class OrderDA
    {


        private static string filePathOR = Application.StartupPath + @"\Order.dat";
        private static string fileTempOR = Application.StartupPath + @"\TempOrder.dat";

        public static Order AddToLst(int orderID)
        {
            Order ord = new Order();

            StreamReader sReader = new StreamReader(filePathOR);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                if (orderID == Convert.ToInt32(fields[0]))    //  Comparing value
                {
                    ord.OrderID = Convert.ToInt32(fields[0]);    //  Assigning the data in First column of view
                    ord.Title = fields[1];//  Assigning the data in second column of view
                    ord.quentity = (fields[2]);    //  Assigning the data in third column of view
                    ord.phone = fields[3];    //  Assigning the data in fourth column of view
                    sReader.Close();
                    return ord;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();    //closing the file
            return null;
        }

        public static void Save(Order ord)
        {


            StreamWriter sWriter = new StreamWriter(filePathOR, true);    //create object to write data to the path
            sWriter.WriteLine(ord.OrderID + "," + ord.Title + "," + ord.quentity + "," + ord.phone);    // store data with saperator
            sWriter.Close();
            MessageBox.Show(" Book Order Data has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void LstOrder(ListView orederview)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePathOR);
            orederview.Items.Clear();


            string line = sReader.ReadLine();   //  Read line by line
            while (line != null)        //  Read the file until teh end of the file
            {
                string[] fields = line.Split(',');  //  Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);   //  Add data to the listView control
                item.SubItems.Add(fields[2]);   //  Add data to the listView control
                item.SubItems.Add(fields[3]);   //  Add data to the listView control
                orederview.Items.Add(item);    //  Add data to the listView control
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }
        public static Order Search(int custId)
        {
            Order cust = new Order();
            StreamReader sReader = new StreamReader(filePathOR);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (custId == Convert.ToInt32(fields[0]))
                {
                    cust.OrderID = Convert.ToInt32(fields[0]);
                    cust.Title = fields[1];
                    cust.quentity=(fields[2]);
                    cust.phone = fields[3];
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
            StreamReader sReader = new StreamReader(filePathOR);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempOR, true);
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
            File.Delete(filePathOR); // Problem here : solved, see the Search method
            File.Move(fileTempOR, filePathOR);

        }
    }
}
