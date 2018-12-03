using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Round : Figure
    {
        private double radius;

        public Round() : base()
        {
            this.radius = 1;
        }

        public Round(double x, double y, double radius, Color borderColor) 
            : base(x: x, y: y, borderColor: borderColor)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid 'radius' parameter!");
                }
                else
                {
                    this.radius = value;
                }
            }
        }

        public override void Draw()
        {
            Console.WriteLine($"The round drawed:{Environment.NewLine}{this.ToString()}");
        }

        public override string ToString()
        {
            return $"Round: {base.ToString()} radius: {this.radius};";
        }
    }
}
