using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model
{
    internal class Movie:Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }

        public string ActresName { get; set; }

        public Movie():base()
        {
            
        }

        public Movie(int event_id,string event_name,DateTime event_date,TimeSpan event_time,int venue_id,int total_seats,decimal ticket_price,string genre,string actor_name,string actres_name):base(event_id,event_name,event_date,event_time,venue_id,total_seats,ticket_price,EventType.Movie)
        {
            Genre = genre;
            ActorName = actor_name;
            ActresName = actres_name;
        }

       
    }
}
