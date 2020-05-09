using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library_Index
{
    public partial class Form1 : Form
    {
        List<Book> Books = new List<Book>();
       // List<Bcode> Codes = new List<Bcode>();
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        public void Start()
        {
            List<string> nameList = File.ReadAllLines("Books.txt").ToList();
            for (int i = 0; i < nameList.Count; i += 2)
            {
                string name = nameList[i + 1];
                int index = Convert.ToInt32(nameList[i]);

               //Bcode a = new Bcode(index);
                //Codes.Add(a);
                
                Book b = new Book(name, index);
                Books.Add(b);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox1.Text);
           

            //outputLabel.Text = found + "";
            LinearSearch( index);
            BinarySearch(Books, index);
            //if (BinarySearch(Books, index) = false)
           // {
           //     MessageBox.Show("Not found");
            //}
           // else if (BinarySearch(Books, index)=true)
          //  {
           //     MessageBox.Show ("Found");
           // }
        }
        public void LinearSearch(int searchValue)
        {
            foreach (Book b in Books)
            {
                if (b.index == searchValue)
                {
                    MessageBox.Show("Located");
                    outputLabel.Text = Convert.ToString(b.name);
                }

            }
        }
        //  public void BinarySearch(int searchValue)
        // {
        //  int low = 0;
        //  int high = Books.Count - 1;
        //  while (high >= low)
        //  {
        //    int middle = (low + high) / 2;

        //    if (Books[middle].index == searchValue)
        //    {
        //        label3.Text = "test";
        //   }
        //   else if (Books[middle].index < searchValue)
        //  {
        //       low = middle + 1;
        //   }
        //   else
        ////    {
        //        high = middle - 1;

        //  }
        //  }
        // }
        public Boolean BinarySearch(List<int> searchList, int searchValue)
        {
            int low = 0;
            int high = searchList.Count - 1;

            while (high >= low)
            {
                int middle = (low + high) / 2;

                if (searchList[middle] == searchValue)
                {
                    return true;
                }
                else if (searchList[middle] < searchValue)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }
            return false;
        }







    }
}
