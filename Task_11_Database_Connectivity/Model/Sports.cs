using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model
{
    internal class Sports : Event
    {
        string SportsName { get; set; }
        string TeamsName { get; set; }

        public Sports()
        {
            
        }
        public Sports(int event_id,string event_name, DateTime event_date, TimeSpan event_time, int venue_id, int total_seats, decimal ticket_price, string sports_name, string teams_name) : base(event_id,event_name, event_date, event_time, venue_id, total_seats, ticket_price, EventType.Sports)
        {
            SportsName = sports_name;
            TeamsName = teams_name;
        }

       
    }
}
