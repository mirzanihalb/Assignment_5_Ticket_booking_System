using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_Class_and_Object.Model
{
    internal class Venue
    {
        string VenueName { get; set; }
        string Address { get; set; }

        public Venue() { }

        public Venue(string venue_name,string address)
        {
            VenueName = venue_name;
            Address = address;
        }
        public void display_venue_details()
        {
            Console.WriteLine($"Venue Name: {VenueName}");
            Console.WriteLine($"Address: {Address}");
        }
    }
}
