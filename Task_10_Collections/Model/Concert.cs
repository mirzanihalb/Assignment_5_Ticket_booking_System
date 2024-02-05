using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_Collections.Model
{
    internal class Concert:Event
    {
        string Artist {  get; set; }
        string Type { get; set; }

        public Concert()
        {
            
        }
        public Concert(string event_name, DateTime event_date, TimeSpan event_time, Venue venue_name, int total_seats, decimal ticket_price, string artist, string type) : base(event_name, event_date, event_time, venue_name, total_seats, ticket_price, EventType.Concert)
        {
            Artist = artist;
            Type = type;
        }

        public string display_concert_details()
        {
            string base_event_details = base.display_event_details();
            string concert_event_details = $"\nArtist : {Artist}";
            return base_event_details + concert_event_details;
        }
    }
}
