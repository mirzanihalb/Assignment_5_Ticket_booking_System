using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_Has_a_ralation_association.Model
{
    internal class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }

        public Venue(string venue_name, string address)
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
