using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DShapeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Body3D[] bodies = { new Sphere(5), new Tetrahedron(2), new Parallelepipied(1, 2, 3), new Tetrahedron(8), new Sphere(12), new Parallelepipied(8, 9, 10) };
            foreach(Body3D body in bodies){
                Console.WriteLine(body.ToString() + ":");
                Console.WriteLine("Площадь поверхности: {0:0.0} ", body.Square());
                Console.WriteLine("Объем: {0:0.0}", body.Volume());
                Console.WriteLine("Сумма длин ребер: {0:0.0}", body.SumOfLengths());
                if (body is Parallelepipied)
                {
                    Parallelepipied bodyParallelepipied = (Parallelepipied)body;
                    Console.WriteLine("Диагональ: {0:0.0}", bodyParallelepipied.Diagonal());
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
