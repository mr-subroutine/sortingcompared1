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
            string[] unorderedArray = new string[500];

            for (int i = 0; i < unorderedArray.Length; i++)
            {
                // random number for storing
                myRandom = getRandom.Next(1, 1500);
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

            int arrayCounter = 0;

            // loops through unorderednumbers array and assigns the value to numVal...
            //then adds a 1 to the index in tempArray1 matching what values are there.
            string[] tempArray1 = new string[1500];
            string[] writeArray1 = new string[1500];
            for (int i = 0; i < unorderedNumbers.Length; i++)
            {
                int numValue = Convert.ToInt32(unorderedNumbers[i]);
                tempArray1[numValue] = tempArray1[numValue] + 1.ToString();
            }

            // loops through tempArray looking for indicies with the value of one, then the index value itself is placed in writeArray.
            // Remember the index is the number from the original unorderedNumbers array.
            for (int i = 0; i < tempArray1.Length; i++)
            {
                if (tempArray1[i] != null && Convert.ToInt32(tempArray1[i]) != 0)
                {
                    writeArray1[arrayCounter] = i.ToString();
                    textBox1.Text += writeArray1[arrayCounter];
                    textBox1.Text += Environment.NewLine;
                    arrayCounter++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            writeFile();
            button2.Enabled = false;

            // turn unordered values into ints
            int[] unorderedInts = new int[unorderedNumbers.Length];

            for (int i = 0; i < unorderedNumbers.Length; i++)
            {
                unorderedInts[i] = Convert.ToInt32(unorderedNumbers[i]);
            }

            int storageVar = 0;
            for (int j = 0; j <= unorderedInts.Length - 2; j++)
            {
                for (int i = 0; i <= unorderedInts.Length - 2; i++)
                {
                    if (unorderedInts[i] > unorderedInts[i + 1])
                    {
                        storageVar = unorderedInts[i + 1];
                        unorderedInts[i + 1] = unorderedInts[i];
                        unorderedInts[i] = storageVar;
                    }
                }
            }

            for (int i = 0; i < unorderedInts.Length; i++)
            {
                textBox2.Text += unorderedInts[i];
                textBox2.Text += Environment.NewLine;
            }
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


