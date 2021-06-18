using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5.Classes
{
    public class Customer
    {
        public string Name { get; private set; } = "";
        public string LastName { get; private set; } = "";
        public string Adress { get; private set; } = "";
        public int CustomerNumber { get; private set; } = -1;

        public Customer(string name, string lastName, string adress, int customerNumber)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Adress = adress;
            this.CustomerNumber = customerNumber;
        }
    }
}
