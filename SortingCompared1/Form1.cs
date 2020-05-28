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
            string tempValue1;
            int tempValue2;
            bool duplicateFound = false;
            string[] unorderedArray = new string[7];

            for (int i = 0; i < unorderedArray.Length; i++)
            {
                // random number for storing
                myRandom = getRandom.Next(1, 1001);
                tempValue1 = myRandom.ToString();

                // checks to see if value is in the array if so it sends the array counter back one, if not it will be null and move to next
                tempValue2 = Array.IndexOf(unorderedArray, tempValue1, 0);
                if (tempValue2 != -1)
                {
                    duplicateFound = true;
                    i -= 1;
                }

                // if no matches found it stores into the array
                if (duplicateFound == false)
                {
                    unorderedArray[i] = myRandom.ToString();
                }

                // resets for next cycle through array 
                duplicateFound = false;
            }

            return unorderedArray;
        }

        public void writeFile()
        {
            // writes all numbers to a text file
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
            for (int i = 0; i < unorderedNumbers.Length; i++)
            {
                // takes value stored in unordered numbers i and placed into tempValue
                tempValue = Int32.Parse(unorderedNumbers[i]);
                // Array Counter
                // places the temp value in the numbered array and puts a 1 there.  So if tempValue is 3, it puts a 1 at index tempValue[3]
                tempArray1[tempValue] = tempArray1[tempValue] + 1;
            }

            int arrayTracker;
            for (int i = 0; i < tempArray1.Length; i++)
            {
                // cycles through entire array from 0 - full length, if a 1 is found at an index, it puts that index value into the...
                // array which is the actual number from the original unordered list.
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


