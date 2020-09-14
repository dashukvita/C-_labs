using System;

namespace EmployeeBase
{
    [Serializable]
    public class Employee
    {
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Employee(string id, string lastName, string firstName, string patronymic, string phoneNumber, string address)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override string ToString()
        {
            return $"{ID}\t{LastName}\t{FirstName}\t{Patronymic}\t{PhoneNumber}\t{Address}";
        }

    }
}
