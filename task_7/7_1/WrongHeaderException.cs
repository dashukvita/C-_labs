using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Пример создания своего собственного класса исключения
    public class WrongHeaderExeption : Exception
    {
        public WrongHeaderExeption (string enteredValue)
        : base($"\nНеверный формат заголовка! \n {enteredValue}")
        {
            EnteredValue = enteredValue;
        }

        // расширяем базовый класс новым свойством.
        public string EnteredValue { get; } // Синтаксис C# 6 - readonly свойство
    }
}
