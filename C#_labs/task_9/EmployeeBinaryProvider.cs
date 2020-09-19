using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace EmployeeBase
{
    public class EmployeeBinaryProvider : IProvider<List<Employee>>
    {
        private readonly string _fileName;

        public EmployeeBinaryProvider(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(List<Employee> employee)
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, employee);
            }
        }

        public List<Employee> Load()
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Employee> result = (List<Employee>)formatter.Deserialize(stream);
                return result;
            }
        }
    }
}

