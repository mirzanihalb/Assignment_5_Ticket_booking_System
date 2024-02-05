using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model

{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email {  get; set; }
        
        public string password { get; set; }

        public string PhoneNumber { get; set; }

        public Customer()
        {
            
        }

        public Customer(int id,string customer_name,string email,string phone_number)
        {
            CustomerId = id;
            CustomerName = customer_name;
            Email = email;
            PhoneNumber = phone_number;
        }

        public override string ToString()
        {
            return $"Customer Name : {CustomerName} CustomerEmail : {Email} PhoneNumber {PhoneNumber}";
        }
    }
}
