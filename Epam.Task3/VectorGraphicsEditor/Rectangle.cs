using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Rectangle : FilledFigure
    {
        private double a;
        private double b;

        public Rectangle(double x, double y, double a, double b, Color borderColor, Color fiilColor)
            : base(x: x, y: y, borderColor: borderColor, fiilColor: fiilColor)
        {
            this.A = a;
            this.B = b;
        }

        public double A { get => this.a; set => this.a = value; }

        public double B { get => this.b; set => this.b = value; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Fill(bool isFill)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()} a: {this.a}; b: {this.b};";
        }
    }
}
