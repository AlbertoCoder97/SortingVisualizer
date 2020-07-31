using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer
{
    class SortingAlgorithms
    {

        //C# simple implementation of BubbleSort
        public static int[] BubbleSort(int[] array)
        {
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
                    }
                }
            }

            //Return the sorted array
            return sorted;
        }


    }
}
