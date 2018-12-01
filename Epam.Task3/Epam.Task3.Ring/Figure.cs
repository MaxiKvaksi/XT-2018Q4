using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Ring
{
    public class Figure
    {
        private double x;
        private double y;

        public Figure(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get => this.x; set => this.x = value; }

        public double Y { get => this.y; set => this.y = value; }
    }
}
