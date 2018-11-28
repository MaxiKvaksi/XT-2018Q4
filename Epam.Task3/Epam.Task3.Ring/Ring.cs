using System;
using Epam.Task3.Round;

namespace Epam.Task3.Ring
{
    public class Ring : Round.Round
    {
        private double innerRadius;

        public Ring(double x, double y, double outerRadius, double innerRadius) 
            : base(x, y, outerRadius)
        {
            if (innerRadius > outerRadius)
            {
                throw new Exception("Inner radius more than outer radius!");
            }

            this.InnerRadius = innerRadius;
        }

        public double InnerRadius
        {
            get => this.innerRadius;
            set
            {
                if (value >= 0)
                {
                    this.innerRadius = value;
                }
                else
                {
                    throw new Exception("Invalid 'innerRadius' value!");
                }
            }
        }

        public double RingArea
        {
            get => this.Area - (Math.PI * Math.Pow(this.innerRadius, 2));
        }

        public double SumInnerAndOuterLength
        {
            get => this.Length + (2 * Math.PI * this.innerRadius);
        }

        public override string ToString()
        {
            return $"Ring: x: {this.X} y: {this.Y} outer radius: {this.Radius} inner radius: {this.InnerRadius}" +
                $" ring area: {this.RingArea} sum inner and outer length: {this.SumInnerAndOuterLength}";
        }
    }
}
