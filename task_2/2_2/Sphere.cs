using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DShapeDemo
{
    class Sphere: Body3D
    {
         protected double r;

        public Sphere(double r)
        {
            this.r = r;
        }

        public override double Square()
        {
            return 4 * r * r * Math.PI;
        }

        public override double Volume()
        {
            return (4 * r * r * r * Math.PI)/3;
        }

        public override double SumOfLengths()
        {
            return 0;
        }

        public override string ToString()
        {
            return "Сфера";
        }
    }
}
