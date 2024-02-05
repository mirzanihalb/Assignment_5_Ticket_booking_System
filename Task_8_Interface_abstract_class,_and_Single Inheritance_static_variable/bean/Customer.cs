using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable

{
    internal class Customer
    {
        public string CustomerName { get; set; }
        public string Email {  get; set; }

        public string PhoneNumber { get; set; }

        public Customer()
        {
            
        }

        public Customer(string customer_name,string email,string phone_number)
        {
            CustomerName = customer_name;
            Email = email;
            PhoneNumber = phone_number;
        }
        public void display_customer_details()
        {
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Email        : {Email}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
        
        }
    }
}
