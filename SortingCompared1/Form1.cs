using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace SortingCompared1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Random getRandom = new Random();
        string[] unorderedNumbers = getRandomNumbers();

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < unorderedNumbers.Length; i++)
            {
                textBox5.Text += unorderedNumbers[i];
                textBox5.Text += Environment.NewLine;
            }
        }

        private static string[] getRandomNumbers()
        {
            int myRandom;
            string[] unorderedArray = new string[1001];

            for (int i = 0; i < unorderedArray.Length; i++)
            {
                myRandom = getRandom.Next(1, 1001);
                foreach (string num in unorderedArray)
                {
                    if (num != Convert.ToString(myRandom))
                    {
                        unorderedArray[i] = myRandom.ToString();
                    }
                }
            }
            return unorderedArray;
        }

        public void writeFile()
        {
            string StartUpPath = Application.StartupPath;
            string filePath = StartUpPath + @"/numbers_for_sort.txt";
            System.IO.File.WriteAllLines(@filePath, unorderedNumbers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            writeFile();
            button1.Enabled = false;
            int[] tempArray1 = new int[1001];
            int tempValue;
            for (int i = 1; i < unorderedNumbers.Length; i++)
            {
                tempValue = Int32.Parse(unorderedNumbers[i]);
                tempArray1[tempValue] = tempArray1[tempValue] + 1;
            }

            int arrayTracker;
            for (int i = 1; i < tempArray1.Length; i++)
            {
                if (tempArray1[i] != 0)
                {
                    arrayTracker = i;
                    textBox1.Text += arrayTracker.ToString();
                    textBox1.Text += Environment.NewLine;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            writeFile();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}


