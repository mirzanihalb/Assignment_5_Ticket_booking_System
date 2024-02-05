using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model
{
    internal class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }

        public Venue(int id ,string venue_name, string address)
        {
            VenueId = id;
            VenueName = venue_name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Id: {VenueId} | Venue Name : {VenueName} | Address : {Address}";
        }

    }
}
