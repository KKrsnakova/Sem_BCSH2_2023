using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sem_BCSH2_2023.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer(int id, string name, string surname, string address, string city, long phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
        }

    }
}
