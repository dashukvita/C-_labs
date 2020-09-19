using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDemo
{
    class Complex
    {
        //Приватные переменные вещественной и мнимой части
        #region
        private double Re, Im;
        #endregion
        //Конструкторы комплексного числа, принимающие вещественную и мнимую части или только вещественную
        #region
        public Complex() { }
        public Complex(double re)
        {
            Re = re;
        }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        #endregion
        //Функция, создающая комплексное число по модулю и аргументу
        #region
        public static Complex Complex_ModuleAndArg(double Re, double Im)
        {
            if (Re < 0) return null;
            return new Complex(Re * Math.Cos(Im), Re * Math.Sin(Im));
        }
        #endregion
        //Свойства для получения вещественной и мнимой части
        #region
        public double re
        {
            get; set;
        }
        public double im
        {
            get; set;
        }
        #endregion
        //Вычислимые свойства, возвращение значения по модуля и аргумента
        #region
        public double Mod
        {
            get { return Math.Sqrt(Re * Re + Im * Im); }
        }

        public double Argument
        {
            get
            {
                if ((Re == 0) || (Im == 0)) return 0;
                if (Re < 0 && Im > 0) return (Math.PI + Math.Atan(Im / Re));
                if (Re < 0 && Im < 0) return (-Math.PI + Math.Atan(Im / Re));
                return Math.Atan(Im / Re);
            }
        }
        #endregion
        //Переопределение арифметическийх операций +, -, /, *
        #region
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex((a.Re * b.Re + a.Im * b.Im)/(b.Re * b.Re + b.Im * b.Im), 
                                (a.Im * b.Re - a.Re * b.Im)/(b.Re * b.Re + b.Im * b.Im));
        }
        #endregion
        //Перегрузка метода Equals
        #region
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex complex = (Complex) obj;
                return re == complex.Re && im == complex.Im;
            }
            else return  false;
        }
        public bool Equals(Complex obj)
        {
            if (obj == null) return false;

            return obj.Re == this.Re && obj.Im == this.Im;
        }
        #endregion
        //Перегрузка метода GetHashCode
        #region
        public override int GetHashCode()
        {
            return re.GetHashCode() ^ im.GetHashCode();
        }
        #endregion
        //Переопределение операций сравнения
        #region
        public static bool operator ==(Complex a, Complex b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            else return a.Equals(b);
        }
        public static bool operator !=(Complex a, Complex b) 
        {
            return !(a == b);
        }
        #endregion
        //Явное преобразование в вещественное число
        #region
        public static explicit operator double(Complex complex)
        {
            return (double)complex.Re;
        }
        #endregion
        //Неявное преобразование из вещественного числа
        #region
        public static implicit operator Complex(double num)
        {
            return new Complex(num);
        }
        #endregion
        //Перегрузка метода toString
        #region
        public override string ToString()
        {
            if (Re == 0 && Im == 0) return string.Format("(i)");
            else if (Re == 0 && Im == 1) return string.Format("(i)");
            else if (Re == 0 && Im == -1) return string.Format("(-i)");
            else if (Re == 0 && Im != 1) return string.Format("({0}i)", Im);
            else if (Im == 1) return string.Format("({0}+i)", Re);
            else if (Im == -1) return string.Format("({0}-i)", Re);
            else if (Im == 0) return string.Format("({0})", Re);
            else if (Im < 0) return string.Format("({0}{1}i)",Re, Im);
            else if (Im == 1) return string.Format("({0}+i)", Re);
            else 

            return string.Format("({0}+{1}i)", Re, Im);
        }
        #endregion
    }
}
