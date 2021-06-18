using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift5.Classes;

namespace Uppgift5.Classes
{
    class CustomerRegister
    {
        static public CustomerRegister GCR = new CustomerRegister();
        Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();

        public CustomerRegister()
        {

        }

        static public void UpdateCustomer(Customer customer)
        {
            if (CustomerRegister.GCR.Customers.ContainsKey(customer.CustomerNumber) == true)
            {
                CustomerRegister.GCR.Customers[customer.CustomerNumber] = customer;
            }
        }

        static public bool AddCustomer(Customer customer)
        {
            if (CustomerRegister.GCR.Customers.ContainsKey(customer.CustomerNumber) == false)
            {
                CustomerRegister.GCR.Customers.Add(customer.CustomerNumber, customer);
                return true;
            }

            return false;
        }

        static public Customer GetCustomer(int customerNumber)
        {
            if (CustomerRegister.GCR.Customers.ContainsKey(customerNumber) == true)
            {
                return CustomerRegister.GCR.Customers[customerNumber];
            }

            return null;
        }

        static public List<Customer> GetCustomers()
        {
            return CustomerRegister.GCR.Customers.Values.ToList();
        }

        static public bool DoesCustomerExist(int customerNumber)
        {
            if (CustomerRegister.GCR.Customers.Count > 0)
            {
                return CustomerRegister.GCR.Customers.ContainsKey(customerNumber);
            }
            else
                return false;
        }
    }
}
