using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DShapeDemo
{
    class Tetrahedron: Body3D
    {
        protected double a;

        public Tetrahedron(double a)
        {
            this.a = a;
        }

        public override double Square()
        {
            return a * a * Math.Sqrt(3);
        }

        public override double Volume()
        {
            return (a * a * a * Math.Sqrt(2))/12;
        }

        public override double SumOfLengths()
        {
            return 6 * a;
        }

        public override string ToString()
        {
            return "Тетраэдр";
        }
    }
}
