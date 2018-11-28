using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Ring : FilledFigure
    {
        private double outerRadius;
        private double innerRadius;

        public Ring(double x, double y, double outerRadius, double innerRadius, Color borderColor, Color fiilColor)
            : base(x: x, y: y, borderColor: borderColor, fiilColor: fiilColor)
        {
            this.InnerRadius = innerRadius;
            this.OuterRadius = outerRadius;
        }

        public double InnerRadius { get => this.innerRadius; set => this.innerRadius = value; }
        public double OuterRadius { get => outerRadius; set => outerRadius = value; }

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
            return $"{base.ToString()} outer radius: {this.outerRadius}; inner radius: {this.innerRadius};";
        }
    }
}
