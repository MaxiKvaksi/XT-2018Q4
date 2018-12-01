using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            if (a + b < c
                || a + c < b
                || c + b < a)
            {
                throw new ArgumentException("One side more than sum of two other!");
            }

            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("One side is negative!");
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        private enum Side
        {
            A,
            B,
            C
        }

        public double A
        {
            get => this.a;
            set
            {
                if (value >= 0)
                {
                    if (value > this.c + this.b)
                    {
                        throw new ArgumentException("The 'a' side more than sum of two other!");
                    }
                    else
                    {
                        this.a = value;
                    }
                }
                else
                {
                    throw new ArgumentException("Negative value side!");
                }
            }
        }

        public double B
        {
            get => this.b;
            set
            {
                if (value >= 0)
                {
                    if (value > this.a + this.c)
                    {
                        throw new ArgumentException("The 'b' side more than sum of two other!");
                    }
                    else
                    {
                        this.b = value;
                    }
                }
                else
                {
                    throw new ArgumentException("Negative value side!");
                }
            }
        }

        public double C
        {
            get => this.c;
            set
            {
                if (value >= 0)
                {
                    if (value > this.a + this.b)
                    {
                        throw new ArgumentException("The 'c' side more than sum of two other!");
                    }
                    else
                    {
                        this.c = value;
                    }
                }
                else
                {
                    throw new ArgumentException("Negative value side!");
                }
            }
        }

        public double Perimetre
        {
            get => this.a + this.b + this.c;
        }

        public double Area
        {
            get => Math.Sqrt((this.Perimetre / 2) * ((this.Perimetre / 2) - this.a) *
                ((this.Perimetre / 2) - this.b) * ((this.Perimetre / 2) - this.c));
        }

        public override string ToString()
        {
            return $"Triangle: a: {this.a} a: {this.b} c: {this.c} area: {this.Area} perimetre: {this.Perimetre}";
        }
    }
}
