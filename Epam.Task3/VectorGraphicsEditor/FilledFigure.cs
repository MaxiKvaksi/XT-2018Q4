using System;
using System.Drawing;

namespace Epam.Task3.VectorGraphicsEditor
{
    public abstract class FilledFigure : Figure
    {
        private Color fiilColor;

        protected FilledFigure() : base()
        {
            this.fiilColor = Color.White;
        }

        protected FilledFigure(double x, double y, Color borderColor, Color fiilColor) : base(x: x, y: y, borderColor: borderColor)
        {
            this.FiilColor = fiilColor;
        }

        public Color FiilColor { get => this.fiilColor; set => this.fiilColor = value; }

        public abstract void Fill(bool isFill);

        public override string ToString()
        {
            return $"{base.ToString()} fill color: {this.fiilColor};";
        }
    }
}
