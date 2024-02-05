using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model
{
    public enum EventType
    {
        Movie,
        Sports,
        Concert
    }
    internal class Event
    {
        public int EventId {  get; set; } 
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }

        public int VenueId { get; set; }
        Venue venue { get; set; }

        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        public EventType EventType { get; set; }

        public Event()
        {
            //default construtor
        }
        public Event(int id,string event_name, DateTime event_date, TimeSpan event_time, int venue_id, int total_seats, decimal ticket_price, EventType event_type)
        {
            EventId = id;
            EventName = event_name;
            EventDate = event_date;
            EventTime = event_time;
            VenueId = venue_id;
            TotalSeats = total_seats;
            AvailableSeats = total_seats;
            TicketPrice = ticket_price;
            EventType = event_type;
        }



       
        public override string ToString()
        {
            return $"{EventId}{EventName}";
        }
    }
}
