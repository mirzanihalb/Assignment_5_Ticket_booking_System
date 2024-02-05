using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable
{
    internal class Sports : Event
    {
        string SportsName { get; set; }
        string TeamsName { get; set; }

        public Sports()
        {
            
        }
        public Sports(string event_name, DateTime event_date, TimeSpan event_time, Venue venue_name, int total_seats, decimal ticket_price, string sports_name, string teams_name) : base(event_name, event_date, event_time, venue_name, total_seats, ticket_price, EventType.Sports)
        {
            SportsName = sports_name;
            TeamsName = teams_name;
        }

        public string display_sport_details()
        {
            string base_event_details = base.display_event_details();
            string sport_event_details = $"\nSportName : {SportsName} \nTeams Name : {TeamsName}";
            return base_event_details + sport_event_details;
        }
    }
}
