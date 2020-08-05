using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SortingVisualizer
{
    class CustomRect
    {

        public int x;
        public int y;
        public int width;
        public int height;

        public SolidBrush brush;

        public CustomRect(int x, int y, int width, int height, SolidBrush brush)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            this.brush = brush;
        }

        public void setBrush(SolidBrush newBrush) { this.brush = newBrush; }
    }
}
