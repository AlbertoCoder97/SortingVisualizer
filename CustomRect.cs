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

        public Color color;

        public CustomRect(int x, int y, int width, int height, Color color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            this.color = color;
        }

        public void setColor(Color newColor) { this.color = newColor; }
    }
}
