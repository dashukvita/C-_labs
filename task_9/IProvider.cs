using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBase
{
    public interface IProvider<T>
    {
        void Save(T valueToSave);
        T Load();
    }
}
