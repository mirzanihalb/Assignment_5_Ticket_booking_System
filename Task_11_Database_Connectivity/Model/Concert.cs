using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model

{
    internal class Concert:Event
    {
        string Artist {  get; set; }
        string Type { get; set; }

        public Concert()
        {
            
        }
        public Concert(int event_id,string event_name, DateTime event_date, TimeSpan event_time, int venue_id, int total_seats, decimal ticket_price, string artist, string type) : base(event_id,event_name, event_date, event_time, venue_id, total_seats, ticket_price, EventType.Concert)
        {
            Artist = artist;
            Type = type;
        }

        
    }
}
