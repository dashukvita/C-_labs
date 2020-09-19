using System.IO;
using System.Reflection;
using System;
using System.Numerics;

namespace ReflectionDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "ComplexNumber.dll")))
            {
                // Загрузка сборки
                Assembly asm = Assembly.Load("ComplexNumber");

                // Получаем тип Complex
                Type complexType = asm.GetType("ComplexNumber.Complex");

                Console.WriteLine("Не используем dynamic");
                Console.WriteLine("------------------------------------");

                // Динамическое создание объекта
                object x = Activator.CreateInstance(complexType, 2, 3);

                // Объект "y" создадим с помощью статического метода
                MethodInfo createComplexByModAndArgMethod = complexType.GetMethod("CreateComplexByModAndArg");
                object y = createComplexByModAndArgMethod.Invoke(null, new object[] { 14, Math.PI / 4 });

                // Вывод в тригонометрическом виде
                PropertyInfo modProperty = complexType.GetProperty("Mod");
                PropertyInfo argProperty = complexType.GetProperty("Arg");

                Console.WriteLine($"x = {x}");
                Console.WriteLine($"y = {modProperty.GetValue(y)}(cos({argProperty.GetValue(y)}) + i*sin({argProperty.GetValue(y)})");

                Console.WriteLine("Вычислим z = ((x+y)^2)/27");

                MethodInfo operatorAdd = complexType.GetMethod("op_Addition");
                MethodInfo operatorMultiply = complexType.GetMethod("op_Multiply");
                MethodInfo operatorDivision = complexType.GetMethod("op_Division");

                object z = operatorAdd.Invoke(null, new[] { x, y });
                z = operatorMultiply.Invoke(null, new[] { z, z });
                z = operatorDivision.Invoke(null, new[] { z, Activator.CreateInstance(complexType, 27, 0) });

                Console.WriteLine("Обычный вид:");
                Console.WriteLine($"z = {z}");
                Console.WriteLine("Тригонометрический вид:");
                Console.WriteLine($"z = {modProperty.GetValue(z)}(cos({argProperty.GetValue(z)}) + i*sin({argProperty.GetValue(z)})");


                Console.WriteLine("\nИспользуем dynamic");
                Console.WriteLine("------------------------------------");

                dynamic a = Activator.CreateInstance(complexType, 4, 1);
                dynamic b = createComplexByModAndArgMethod.Invoke(null, new object[] { 2, Math.PI / 3 });

                Console.WriteLine($"a = {a}");
                Console.WriteLine($"b = {b.Mod}(cos({b.Arg}) + i*sin({b.Arg})");

                Console.WriteLine("Вычислим z = ((a^2+b^2)^2)/3*b");

                dynamic int3 = Activator.CreateInstance(complexType, 3, 0);
                dynamic c = ((a * a + b * b) * (a * a + b * b)) / (int3 * b);

                Console.WriteLine("Обычный вид:");
                Console.WriteLine($"c = {c}");
                Console.WriteLine("Тригонометрический вид:");
                Console.WriteLine($"c = {c.Mod}(cos({c.Arg}) + i*sin({c.Arg})");

            }
            else
            {
                Console.WriteLine("ComplexNumber.dll не найдена!");
                Console.WriteLine("Используем System.Numerics");

                Complex e = new Complex(1, 2);
                Complex f = Complex.FromPolarCoordinates(3, Math.PI / 8);

                Console.WriteLine($"e = {e}");
                Console.WriteLine($"f = {f.Magnitude}(cos({f.Phase}) + i*sin({f.Phase})");

                Console.WriteLine("Вычислим d = 34 + e^f");

                Complex d = 34 + Complex.Pow(e, f);

                Console.WriteLine("Обычный вид:");
                Console.WriteLine($"d = {d}");
                Console.WriteLine("Тригонометрический вид:");
                Console.WriteLine($"d = {d.Magnitude}(cos({d.Phase}) + i*sin({d.Phase})");

            }

            Console.WriteLine("\nНажмите Enter...");
            Console.Read();
        }
    }
}
