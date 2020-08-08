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



        public static int SIZE = 20;

        public static int[] getArray() { return array; }
        public static int[] array = new int[SIZE];

        public static bool bubble = false;
        public static bool insertion = false;
        public static bool initialized = false;



        public static void InitializeArray()
        {
            array = null;
            array = new int[SIZE];

            //Let's populate the array with random elements
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                //Let's limit element from 0 to 100
                //the array can contain duplicated elements
                array[i] = random.Next(5, 101);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //Let's reorder the array
            bubble = true;
            //Redraw panel
            this.Refresh();
            //Rest the boolean
            bubble = false;
        }

        //This method is called EVERY FRAME
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //I have to initialize the array here cause otherwise I cannot edit the GUI.
            if (!initialized)
            {
                InitializeArray();
                initialized = true;
            }
            if(bubble)
                DrawingAlgorithms.BubbleSortAnimation(sender, e, array);
            else if(insertion)
                DrawingAlgorithms.InsertionSortAnimation(sender, e, array);
            else
                DrawingAlgorithms.ArrayInitializer(sender, e, array);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Reset everything everytime we change array size
            this.Invalidate();
            DrawingAlgorithms.rectangles.Clear();

            //Randomize
            InitializeArray();
            this.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Reset everything everytime we change array size
            this.Invalidate();
            DrawingAlgorithms.rectangles.Clear();

            SIZE = trackBar1.Value;
            InitializeArray();
            this.Refresh();
        }
    }
}
