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

        public Ring() : base()
        {
            this.outerRadius = 2;
            this.innerRadius = 1;
        }

        public Ring(double x, double y, double outerRadius, double innerRadius, Color borderColor, Color fiilColor)
            : base(x: x, y: y, borderColor: borderColor, fiilColor: fiilColor)
        {
            this.InnerRadius = innerRadius;
            this.OuterRadius = outerRadius;
        }

        public double InnerRadius
        {
            get => this.innerRadius;
            set
            {
                if (value < 0 || value > this.outerRadius)
                {
                    throw new ArgumentException("Invalid 'inner radius' parameter!");
                }
                else
                {
                    this.innerRadius = value;
                }
            }
        }

        public double OuterRadius
        {
            get => this.outerRadius;
            set
            {
                if (value < 0 || value < this.innerRadius)
                {
                    throw new ArgumentException("Invalid 'outer radius' parameter!");
                }
                else
                {
                    this.outerRadius = value;
                }
            }
        }

        public override void Draw()
        {
            Console.WriteLine($"The ring drawed:{Environment.NewLine}{this.ToString()}");
        }

        public override void Fill(bool isFill)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Ring: {base.ToString()} outer radius: {this.outerRadius}; inner radius: {this.innerRadius};";
        }
    }
}
