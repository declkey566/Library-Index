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
        List<int> codes = new List<int>();

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

                codes.Add(index);

                Book b = new Book(name, index);
                Books.Add(b);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox1.Text);
            LinearSearch( index);
            BinarySearch(codes, index);
            String found = BinarySearch(codes, index);
            if (found.Equals ("Found"))
            {
                label3.Text =Convert.ToString(b.name);
            }
            if (found.Equals("Not found"))
            {
                label3 .Text ="NOT LOCATED";
            }
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
        public String BinarySearch(List<int> searchList, int searchValue)
        {
            int low = 0;
            int high = searchList.Count - 1;

            while (high >= low)
            {
                int middle = (low + high) / 2;

                if (searchList[middle] == searchValue)
                {
                    return ("Found");
                    
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
            return ("Not found");
        }







    }
}
