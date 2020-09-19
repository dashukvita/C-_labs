using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DShapeDemo
{
    class Parallelepipied: Body3D
    {
        protected double a, b, c;

        public Parallelepipied(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double Square()
        {
            return 2 * (a * b + b * c + a * c);
        }

        public override double Volume()
        {
            return a * b * c;
        }

        public override double SumOfLengths()
        {
            return 4 * (a + b + c);
        }

        public double Diagonal()
        {
            return Math.Sqrt(a * a + b * b + c * c);
        }

        public override string ToString()
        {
            return "Параллелепипед прямоугольный";
        }
    }


}
