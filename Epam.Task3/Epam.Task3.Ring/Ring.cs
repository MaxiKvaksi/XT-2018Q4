using System;

namespace Epam.Task3.Ring
{
    public class Ring : Figure
    {
        private double innerRadius;
        private double outerRadius;

        public Ring(double x, double y, double outerRadius, double innerRadius) 
            : base(x, y)
        {
            if (innerRadius < 0 || innerRadius < 0 || innerRadius > outerRadius)
            {
                throw new Exception("Inner radius more than outer radius!");
            }

            this.innerRadius = innerRadius;
            this.outerRadius = outerRadius;
        }

        public double InnerRadius
        {
            get => this.innerRadius;
            set
            {
                if (value >= 0 && value < this.outerRadius)
                {
                    this.innerRadius = value;
                }
                else
                {
                    throw new Exception("Invalid 'innerRadius' value!");
                }
            }
        }

        public double OuterRadius
        {
            get => this.outerRadius;
            set
            {
                if (value >= 0 && value > this.innerRadius)
                {
                    this.outerRadius = value;
                }
                else
                {
                    throw new Exception("Invalid 'outerRadius' value!");
                }
            }
        }

        public double RingArea
        {
            get => (Math.PI * Math.Pow(this.outerRadius, 2)) - (Math.PI * Math.Pow(this.innerRadius, 2));
        }

        public double SumInnerAndOuterLength
        {
            get => (2 * Math.PI * this.outerRadius) + (2 * Math.PI * this.innerRadius);
        }

        public override string ToString()
        {
            return $"Ring: x: {this.X} y: {this.Y} outer radius: {this.outerRadius} inner radius: {this.InnerRadius}" +
                $" ring area: {this.RingArea} sum inner and outer length: {this.SumInnerAndOuterLength}";
        }
    }
}
