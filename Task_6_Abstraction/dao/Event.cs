using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Abstraction.dao
{
    public enum EventType
    {
        Movie,
        Sport,
        Concert
    }
    internal abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }

        public string VenueName { get; set; }

        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        public EventType EventType { get; set; }

        public Event()
        {
            //default construtor
        }
        public Event(string event_name, DateTime event_date, TimeSpan event_time, string venue_name, int total_seats, decimal ticket_price, EventType event_type)
        {
            EventName = event_name;
            EventDate = event_date;
            EventTime = event_time;
            VenueName = venue_name;
            TotalSeats = total_seats;
            AvailableSeats = total_seats;
            TicketPrice = ticket_price;
            EventType = event_type;
        }



        public abstract decimal calculate_total_revenue(int numOfTickets);

        public abstract decimal calculate_booking_cost(int numOfTickets);

        public abstract int getBookedNoOfTickets();
        public abstract int book_ticktes(int numOfTickets);
        public abstract void cancel_booking(int num_tickets);

        public abstract string display_event_details();
    }
}
