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
        public static int w = 15;
        
        public static SolidBrush black = new SolidBrush(Color.Black);
        public static SolidBrush red = new SolidBrush(Color.Red);

        public static ArrayList rectangles = new ArrayList();

        //Animation for BubbleSort
        public static void BubbleSortAnimation(object sender, PaintEventArgs e, int[] array)
        {
            var p = sender as Panel;

            SolidBrush brush = new SolidBrush(Color.Black);

            Graphics g = e.Graphics;


            //Let's copy the array so that the original one can still be accessed and doesn't get modified.
            int[] sorted = array;
            int temp = 0;

            for (int write = 0; write < sorted.Length; write++)
            {
                for (int sort = 0; sort < sorted.Length - 1; sort++)
                {
                    if (sorted[sort] > sorted[sort + 1])
                    {
                        temp = sorted[sort + 1];
                        sorted[sort + 1] = sorted[sort];
                        sorted[sort] = temp;

                        //Set elements in rectangle array
                        rectangles[sort] = new CustomRect(x, y, w, sorted[sort] * 2, red);

                        x += 25; 

                        rectangles[sort + 1] = new CustomRect(x, y, w, sorted[sort + 1] * 2, red);

                        foreach (CustomRect rect in rectangles)
                        {
                            g.FillRectangle(rect.brush, rect.x, rect.y, rect.width, rect.height);
                        }

                        //refresh visuals
                        Program.main.Refresh();
                        Application.DoEvents();
                        // pause long enough to see it before the next one happens
                        System.Threading.Thread.Sleep(100);

                        rectangles[sort] = new CustomRect(x, y, w, sorted[sort] * 2, black);
                        rectangles[sort + 1] = new CustomRect(x, y, w, sorted[sort + 1] * 2, black);

                        foreach (CustomRect rect in rectangles)
                        {
                            g.FillRectangle(rect.brush, rect.x, rect.y, rect.width, rect.height);
                        }

                        Program.main.Refresh();
                        Application.DoEvents();
                        // pause long enough to see it before the next one happens
                        System.Threading.Thread.Sleep(100);

                    }
                }
            }

            x = 10;

            //This draws all the array
            /*
            for (int i = 0; i < array.Length; i++)
            {
                rectangles.Add(new CustomRect(x, y, w, (array[i]) * 2, black));
                x += 25;
            }

            foreach (CustomRect rect in rectangles)
            {
                g.FillRectangle(rect.brush, rect.x, rect.y, rect.width, rect.height);
            }

            x = 10;
            */

        }

        public static void ArrayInitializer(object sender, PaintEventArgs e, int[] array)
        {
            var p = sender as Panel;
            Graphics g = e.Graphics;

            //Initialize Rect arrays
            for(int i = 0; i < array.Length; i++)
            {
                rectangles.Add(new CustomRect(x, y, w, (array[i])*2, black));
                x += 25;
            }

            //reset x
            x = 10;

            foreach(CustomRect rect in rectangles)
            {
                g.FillRectangle(rect.brush, rect.x, rect.y, rect.width, rect.height);
            }
        }

        internal static void InsertionSortAnimation(object sender, PaintEventArgs e, int[] array)
        {
            throw new NotImplementedException();
        }
    }
}
