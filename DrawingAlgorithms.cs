using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace SortingVisualizer
{
    class DrawingAlgorithms
    {

        public static int x = 10;
        public static int y = 10;

        public static ArrayList rectangles = new ArrayList();

        //Animation for BubbleSort
        public static void BubbleSortAnimation(object sender, PaintEventArgs e, int[] array)
        {
            var p = sender as Panel;

            SolidBrush brush = new SolidBrush(Color.Black);

            Graphics g = e.Graphics;

            //g.FillRectangle(brush, 10,10,30,80);

            for(int i = 0; i < array.Length; i++)
            {
                g.FillRectangle(brush, x , y, 30, (array[i])*1.5F);
                x += 50; 
            }

            x = 10;
            
        }
    }
}
