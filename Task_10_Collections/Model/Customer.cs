﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_Collections.Model
{
    internal class Customer:IComparable<Customer>
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
        public int CompareTo(Customer other)
        {
            int nameComparision = string.Compare(this.CustomerName, other.CustomerName, StringComparison.Ordinal);
            
            return nameComparision;
            
            
        }
    }
}
