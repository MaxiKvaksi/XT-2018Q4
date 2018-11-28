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

        public Round(double x, double y, double radius, Color borderColor) 
            : base(x: x, y: y, borderColor: borderColor)
        {
            this.Radius = radius;
        }

        public double Radius { get => this.radius; set => this.radius = value; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()} radius: {this.radius};";
        }
    }
}
