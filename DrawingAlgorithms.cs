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


        public static SolidBrush black = new SolidBrush(Color.Black);
        public static SolidBrush red = new SolidBrush(Color.Red);

        public static ArrayList rectangles = new ArrayList();

        //Animation for BubbleSort
        public static void BubbleSortAnimation(object sender, PaintEventArgs e, int[] array)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;

            //Let's copy the array so that the original one can still be accessed and doesn't get modified.
            int[] sorted = array;
            int temp = 0;

            g.Clear(Color.White);
            RenderArray(e, rectangles);

            for (int i = 0; i < sorted.Length; i++)
            {

                for (int j = 0; j < sorted.Length - 1; j++)
                {
                    g.Clear(Color.White);

                    if (sorted[j] > sorted[j + 1])
                    {
                        temp = sorted[j + 1];
                        sorted[j + 1] = sorted[j];
                        sorted[j] = temp;


                        //ANIMATION PART

                        //Set elements in rectangle array
                        CustomRect current = (CustomRect)rectangles[j];
                        CustomRect next = (CustomRect)rectangles[j + 1];

                        //rectangles[j] = rectangles[j+1];

                        rectangles[j] = new CustomRect(current.x, current.y, current.width, next.height, red );
                        rectangles[j+1] = new CustomRect(next.x, next.y, next.width, current.height, red);

                        RenderArray(e, rectangles);
                        ResetColor((CustomRect) rectangles[j], (CustomRect) rectangles[j+1]);
                        RenderArray(e, rectangles);

                    }
                }
            }

            g.Clear(Color.White);
            RenderArray(e, rectangles);

        }

        internal static void QuickSortAnimation(object sender, PaintEventArgs e, int[] array)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;
            int top = -1;
            int[] stack = new int[array.Length];

            stack[++top] = startIndex;
            stack[++top] = endIndex;

            while (top >= 0)
            {
                endIndex = stack[top--];
                startIndex = stack[top--];

                int p = Partition(ref array, startIndex, endIndex, e);

                if (p - 1 > startIndex)
                {
                    stack[++top] = startIndex;
                    stack[++top] = p - 1;
                }

                if (p + 1 < endIndex)
                {
                    stack[++top] = p + 1;
                    stack[++top] = endIndex;
                }
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


                    //ANIMATION

                    //Set elements in rectangle array
                    CustomRect current = (CustomRect)rectangles[j];
                    CustomRect next = (CustomRect)rectangles[j + 1];

                    rectangles[j] = new CustomRect(current.x, current.y, current.width, next.height, red);

                    rectangles[j + 1] = new CustomRect(next.x, next.y, next.width, current.height, red);

                    g.Clear(Color.White);
                    RenderArray(e, rectangles);

                    ResetColor((CustomRect)rectangles[j], (CustomRect)rectangles[j + 1]);

                    RenderArray(e, rectangles);
                }

                array[j + 1] = value;

                g.Clear(Color.White);
                RenderArray(e, rectangles);
            }
        }

        public static void ArrayInitializer(object sender, PaintEventArgs e, int[] array)
        {
            Graphics g = e.Graphics;

            //Initialize Rect arrays
            for (int i = 0; i < array.Length; i++)
            {
                rectangles.Add(new CustomRect(x, y, w, (array[i]) * 2, black));
                x += distance;
            }

            //reset x
            x = (100 / Form1.SIZE) * 2;


            //Redraw the rectangles
            foreach (CustomRect rect in rectangles)
            {
                g.FillRectangle(rect.brush, rect.x, rect.y, rect.width, rect.height);
            }
        }

        public static void RenderArray(PaintEventArgs e, ArrayList list)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < list.Count; i++)
            {
                CustomRect temp = (CustomRect)list[i];
                g.FillRectangle(temp.brush, temp.x, temp.y, temp.width, temp.height);
            }
        }

        //THIS IS VERY UGLY BUT APPARENTLY NECESSARY
        public static void ResetColor(CustomRect customRect1, CustomRect customRect2)
        {
            customRect1.setBrush(black);
            customRect2.setBrush(black);
        }


        private static int Partition(ref int[] array, int left, int right, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            int x = array[right];
            int i = (left - 1);
            for (int j = left; j <= right - 1; ++j)
            {
                g.Clear(Color.White);
                if (array[j] <= x)
                {
                    ++i;
                    Swap(ref array[i], ref array[j]);

                    //ANIMATION PART
                    g.Clear(Color.White);
                    //Set elements in rectangle array
                    CustomRect current2 = (CustomRect)rectangles[i];
                    CustomRect next2 = (CustomRect)rectangles[j];

                    //rectangles[j] = rectangles[j+1];

                    rectangles[i] = new CustomRect(current2.x, current2.y, current2.width, next2.height, red);
                    rectangles[j] = new CustomRect(next2.x, next2.y, next2.width, current2.height, red);

                    RenderArray(e, rectangles);
                    ResetColor((CustomRect)rectangles[i], (CustomRect)rectangles[j]);
                    RenderArray(e, rectangles);
                }
            }

            Swap(ref array[i + 1], ref array[right]);

            //ANIMATION PART
            //Set elements in rectangle array
            CustomRect current = (CustomRect)rectangles[i + 1];
            CustomRect next = (CustomRect)rectangles[right];

            //rectangles[j] = rectangles[j+1];

            rectangles[i + 1] = new CustomRect(current.x, current.y, current.width, next.height, red);
            rectangles[right] = new CustomRect(next.x, next.y, next.width, current.height, red);

            RenderArray(e, rectangles);
            ResetColor((CustomRect)rectangles[i + 1], (CustomRect)rectangles[right]);
            RenderArray(e, rectangles);

            return (i + 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
