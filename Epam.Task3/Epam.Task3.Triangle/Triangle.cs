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
                throw new Exception("One side more than sum of two other!");
            }

            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double A
        {
            get => this.a;
            set
            {
                if (value >= 0)
                {
                    this.a = value;
                }
                else
                {
                    throw new Exception("Negative value side!");
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
                    this.b = value;
                }
                else
                {
                    throw new Exception("Negative value side!");
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
                    this.c = value;
                }
                else
                {
                    throw new Exception("Negative value side!");
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
