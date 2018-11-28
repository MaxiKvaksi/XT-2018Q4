using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public abstract class Figure
    {
        private double x;
        private double y;
        private Color borderColor;

        protected Figure(double x, double y, Color borderColor)
        {
            this.X = x;
            this.Y = y;
            this.BorderColor = borderColor;
        }

        public double X { get => this.x; set => this.x = value; }

        public double Y { get => this.y; set => this.y = value; }

        public Color BorderColor { get => this.borderColor; set => this.borderColor = value; }

        public abstract void Draw();

        public override string ToString()
        {
            return $"x: {this.x};: {this.y}; border color: {this.borderColor.ToString()};";
        }
    }
}
