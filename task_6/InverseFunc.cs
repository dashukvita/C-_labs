using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InverseFunc
    {
        public event EventHandler<CurrentСalAccurEvent> CalculationEvent;

        public delegate double Funcdelegate(double x);

        public double InverseFunction(Funcdelegate f, double a, double b, double eps, double y)
        {
            double c = 0;
            while (Math.Abs(b - a) > eps)
            {
                c = (a + b) / 2;
                if ((f(a) - y) * (f(c) - y) <= 0) b = c;
                else a = c;
                OnElementMoved(c, Math.Abs(b - a));
            }
            return (a + b) / 2;
        }

        private void OnElementMoved(double curResult, double calcAccuracy)
        {
            CalculationEvent?.Invoke(this, new CurrentСalAccurEvent(curResult, calcAccuracy));
        }

    }
}
