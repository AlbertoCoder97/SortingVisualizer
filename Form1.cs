using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Let's reorder the array
            bubble = true;
            //Redraw panel
            this.Refresh();
            bubble = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //I have to initialize the array here cause otherwise I cannot edit the GUI.
            if (!initialized)
            {
                InitializeArray(array);
                initialized = true;
            }
            if(bubble)
                DrawingAlgorithms.BubbleSortAnimation(sender, e, array);
            else if(insertion)
                DrawingAlgorithms.InsertionSortAnimation(sender, e, array);
            else
                DrawingAlgorithms.ArrayInitializer(sender, e, array);
        }
    }
}
