using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_Has_a_ralation_association.Model
{
    internal class Movie:Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }

        public string ActresName { get; set; }

        public Movie():base()
        {
            
        }

        public Movie(string event_name,DateTime event_date,TimeSpan event_time,Venue venue_name,int total_seats,decimal ticket_price,string genre,string actor_name,string actres_name):base(event_name,event_date,event_time,venue_name,total_seats,ticket_price,EventType.Movie)
        {
            Genre = genre;
            ActorName = actor_name;
            ActresName = actres_name;
        }

        public new string display_event_details()
        {
            string base_event_details = base.display_event_details();
            string movie_event_details = $"\nGenre : {Genre}";
            return base_event_details+movie_event_details;
        }
    }
}
