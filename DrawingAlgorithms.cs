using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace SortingVisualizer
{
    class DrawingAlgorithms
    {
        //Calculate automatically position based on elements in array
        public static int x = (100 / Form1.SIZE) * 2;
        public static int y = 10;
        //Calculate automatically width based on elements in array
        public static int w = (100 / Form1.SIZE) * 3;
        public static int distance = x * 2;

        public static int SPEED = (100 / Form1.SIZE) * 5;


        public static SolidBrush black = new SolidBrush(Color.Black);
        public static SolidBrush red = new SolidBrush(Color.Red);

        public static ArrayList rectangles = new ArrayList();

        //Animation for BubbleSort
        public static void BubbleSortAnimation(object sender, PaintEventArgs e, int[] array)
        {

            var p = sender as Panel;

            SolidBrush brush = new SolidBrush(Color.Black);

            Graphics g = e.Graphics;

            x = (100 / Form1.SIZE) * 2;
            distance = x * 2;

            //Let's copy the array so that the original one can still be accessed and doesn't get modified.
            int[] sorted = array;
            int temp = 0;

            g.Clear(Color.White);
            RenderArray(sender, e, rectangles);

            for (int i = 0; i < sorted.Length; i++)
            {
                //g.Clear(Color.White);

                for (int j = 0; j < sorted.Length - 1; j++)
                {
                    g.Clear(Color.White);

                    if (sorted[j] > sorted[j + 1])
                    {
                        temp = sorted[j + 1];
                        sorted[j + 1] = sorted[j];
                        sorted[j] = temp;

                        //Set elements in rectangle array
                        CustomRect current = (CustomRect)rectangles[j];
                        CustomRect next = (CustomRect)rectangles[j + 1];

                        //rectangles[j] = rectangles[j+1];

                        rectangles[j] = new CustomRect(current.x, current.y, current.width, next.height, red );

                        rectangles[j+1] = new CustomRect(next.x, next.y, next.width, current.height, red);

                        //g.Clear(Color.White);

                        RenderArray(sender, e, rectangles);

                        ResetColor((CustomRect) rectangles[j], (CustomRect) rectangles[j+1]);

                        RenderArray(sender, e, rectangles);

                    }
                }
            }
            
            g.Clear(Color.White);
            RenderArray(sender, e, rectangles);
            

        }

        public static void ResetColor(CustomRect customRect1, CustomRect customRect2)
        {
            customRect1.setBrush(black);
            customRect2.setBrush(black);
        }

        public static void ArrayInitializer(object sender, PaintEventArgs e, int[] array)
        {
            var p = sender as Panel;
            Graphics g = e.Graphics;

            x = (100 / Form1.SIZE) * 2;
            w = (100 / array.Length) * 3;
            distance = x * 2;

            //Initialize Rect arrays
            for (int i = 0; i < array.Length; i++)
            {
                rectangles.Add(new CustomRect(x, y, w, (array[i])*2, black));
                x += distance;
            }

            //reset x
            x = (100 / Form1.SIZE) * 2;

            foreach (CustomRect rect in rectangles)
            {
                g.FillRectangle(rect.brush, rect.x, rect.y, rect.width, rect.height);
            }
        }

        public static void RenderArray(object sender, PaintEventArgs e, ArrayList list)
        {
            var p = sender as Panel;
            //p.Invalidate();

            Graphics g = e.Graphics;

            //System.Threading.Thread.Sleep(SPEED);

            for (int i = 0; i < list.Count; i++)
            {
                CustomRect prova = (CustomRect)list[i];
                
                g.FillRectangle(prova.brush, prova.x, prova.y, prova.width, prova.height);
            }
        }

        internal static void InsertionSortAnimation(object sender, PaintEventArgs e, int[] array)
        {

            var p = sender as Panel;
            Graphics g = e.Graphics;
            int j;


            for(int i = 1; i < array.Length; i++)
            {
                int value = array[i];
                for(j = i-1;  j>=0 && array[j] > value; j--)
                {
                    int temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;

                    //Set elements in rectangle array
                    CustomRect current = (CustomRect)rectangles[j];
                    CustomRect next = (CustomRect)rectangles[j + 1];

                    rectangles[j] = new CustomRect(current.x, current.y, current.width, next.height, red);

                    rectangles[j + 1] = new CustomRect(next.x, next.y, next.width, current.height, red);

                    g.Clear(Color.White);
                    RenderArray(sender, e, rectangles);

                    ResetColor((CustomRect)rectangles[j], (CustomRect)rectangles[j + 1]);

                    RenderArray(sender, e, rectangles);
                }

                array[j + 1] = value;

                g.Clear(Color.White);
                RenderArray(sender, e, rectangles);
            }
        }
    }
}
