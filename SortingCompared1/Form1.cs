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
        //int[] unorderedConvertedNum = convertArrayToInt(unorderedNumbers);

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < unorderedNumbers.Length; i++)
            {
                textBox5.Text += unorderedNumbers[i];
                textBox5.Text += Environment.NewLine;
            }
        }

        private static int[] convertArrayToInt(string[] unorderedNumbers)
        {
            int[] unorderedInts = new int[unorderedNumbers.Length];

            for (int i = 0; i < unorderedNumbers.Length; i++)
            {
                unorderedInts[i] = Convert.ToInt32(unorderedNumbers[i]);
            }
            return unorderedInts;
        }

        private static string[] getRandomNumbers()
        {
            int myRandom;
            string tempValue1;
            int tempValue2;
            bool duplicateFound = false;
            string[] unorderedArray = new string[1000];

            for (int i = 0; i < unorderedArray.Length; i++)
            {
                // random number for storing
                myRandom = getRandom.Next(1, 3000);
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

            // PERSONAL ALGORITHMIC SOLUTION
            // loops through unorderednumbers array and assigns the value to numVal...
            //then adds a 1 to the index in tempArray1 matching what values are there.
            string[] tempArray1 = new string[3000];
            string[] writeArray1 = new string[1000];
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
            int[] unorderedInts = convertArrayToInt(unorderedNumbers);
            int storageVar = 0;

            // BUBBLE SORT algorithm
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
            textBox6.Clear();
            textBox8.Clear();
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            writeFile();
            button4.Enabled = false;
            int[] unorderedIntArr = convertArrayToInt(unorderedNumbers);
            unorderedIntArr = quickSort(unorderedIntArr, 0, unorderedNumbers.Length - 1);

            for (int k = 0; k < unorderedIntArr.Length; k++)
            {
                textBox6.Text += unorderedIntArr[k];
                textBox6.Text += Environment.NewLine;
            }
        }

        // QUICK SORT algorithm
        private int[] quickSort(int[] unorderedArray, int left, int right)
        {
            int i = left;
            int j = right;

            var pivot = unorderedArray[(left + right) / 2];

            while (i <= j)
            {
                while (unorderedArray[i] < pivot)
                    i++;

                while (unorderedArray[j] > pivot)
                    j--;

                if (i <= j)
                {
                    var tmp = unorderedArray[i];
                    unorderedArray[i] = unorderedArray[j];
                    unorderedArray[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
                quickSort(unorderedArray, left, j);

            if (i < right)
                quickSort(unorderedArray, i, right);

            return unorderedArray;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MicrosoftSortMethod();
        }

        // Microsoft Array Sorting algorithm C# DOCS
        private void MicrosoftSortMethod()
        {
            textBox8.Clear();
            writeFile();
            button5.Enabled = false;

            int[] unorderedIntArr = convertArrayToInt(unorderedNumbers);

            Array.Sort(unorderedIntArr);
            for (int i = 0; i < unorderedIntArr.Length; i++)
            {
                textBox8.Text += unorderedIntArr[i].ToString();
                textBox8.Text += Environment.NewLine;
            }
        }
    }
}


