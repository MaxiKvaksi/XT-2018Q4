using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Line : Figure
    {
        private double x2;
        private double y2;

        public Line(double x, double y, double x2, double y2, Color borderColor) : base(x, y, borderColor)
        {
            this.X2 = x2;
            this.Y2 = y2;
        }

        public double X2 { get => this.x2; set => this.x2 = value; }

        public double Y2 { get => this.y2; set => this.y2 = value; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()} x2: {this.x2}; y2: {this.y2};";
        }
    }
}
