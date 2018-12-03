using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Circle : FilledFigure
    {
        private double radius;

        public Circle() : base()
        {
            this.radius = 1;
        }

        public Circle(double x, double y, double radius, Color borderColor, Color fiilColor)
            : base(x: x, y: y, borderColor: borderColor, fiilColor: fiilColor)
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
            Console.WriteLine($"The circle drawed:{Environment.NewLine}{this.ToString()}");
        }

        public override void Fill(bool isFill)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Circle: {base.ToString()} radius: {this.radius};";
        }
    }
}
