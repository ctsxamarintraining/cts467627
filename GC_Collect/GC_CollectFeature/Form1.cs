using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GC_CollectFeature
{
    public partial class Form1 : Form
    {
        public const int garbageValue = 1000;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Put some objects in memory.
            Form1.MakeGarbage();

            // Memory used before collection
            label3.Text = GC.GetTotalMemory(false).ToString();

            // Collect all generations of memory.
            GC.Collect();

            // Memory used after full collection
            label4.Text = GC.GetTotalMemory(true).ToString();

            // Display collection counts.
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                int count = GC.CollectionCount(i);
                Console.WriteLine(count);
            }

            // Display collection counts.
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                int count = GC.CollectionCount(i);
                label6.Text = count.ToString();
            }

        }
        static void MakeGarbage()
        {
            Employee emp;

            // Create objects and release them to fill up memory with unused objects.
            for (int j = 0; j < garbageValue; j++)
            {
                emp = new Employee();
                emp.FirstName = "ABC";
                emp.LastName = "DEF";
            }
        }
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
