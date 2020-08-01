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
            Form1.array = SortingAlgorithms.BubbleSort(array);

            //Redraw panel
            this.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawingAlgorithms.BubbleSortAnimation(sender, e, array);
        }
    }
}
