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
                
                Book b = new Book(name, index);
                Books.Add(b);
            }
        }
        public void LinearSearch()
        {
            int searchValue = Convert.ToInt32(textBox1.Text); 
            foreach (Book b in Books)
            {
                if (b.index == searchValue)
                {
                    MessageBox.Show("Located");
                    outputLabel.Text = Convert.ToString(b.name);
                }

            }
        }
        public void BinarySearch()
        {
            int low = 0;
            int high = Books.Count - 1;
            int searchValueB = Convert.ToInt32(textBox1.Text);
            while (high >= low)
            {
                int middle = (low + high) / 2;

                if (Books[middle].index == searchValueB)
                {
                    label3.Text = "test";
                }
                else if (Books[middle].index < searchValueB)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinearSearch();
            
        }
      //  public void DisplayResults()
       // {
         //   outputLabel.Text = "";

        //    foreach (Book b in Books)
        //    {
        //        outputLabel.Text += b.name + " " + b.index + "\n";
         //   }
      //  }

    }
}
