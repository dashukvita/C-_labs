using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CurrentСalAccurEvent: EventArgs
    {
        public CurrentСalAccurEvent(double curResult, double calcAccuracy)
        {
            CurrentResult = curResult;
            Accuracy = calcAccuracy;
        }
        public double CurrentResult { get; private set; }

        public double Accuracy { get; private set; }
    }
}
