using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Round
{
    public class Round
    {
        private double x;
        private double y;
        private double radius;

        public Round(double x, double y, double radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public double X { get => this.x; set => this.x = value; }

        public double Y { get => this.y; set => this.y = value; }

        public double Radius
        {
            get => this.radius;
            set
            {
                if (value >= 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new Exception("Negative radius!");
                }
            }
        }

        public double Area
        {
            get => Math.PI * Math.Pow(this.radius, 2);
        }

        public double Length
        {
            get => 2 * Math.PI * this.radius;
        }

        public override string ToString()
        {
            return $"Round: x: {this.x} y: {this.y} radius: {this.radius} area: {this.Area} length: {this.Length}";
        }
    }
}
