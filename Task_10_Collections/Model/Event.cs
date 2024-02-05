using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_Collections.Model
{
    public enum EventType
    {
        Movie,
        Sports,
        Concert
    }
    internal class Event:IComparable<Event>
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }

        public Venue VenueName { get; set; }

        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        public EventType EventType { get; set; }

        public Event()
        {
            //default construtor
        }
        public Event(string event_name, DateTime event_date, TimeSpan event_time, Venue venue_name, int total_seats, decimal ticket_price, EventType event_type)
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



        public decimal calculate_total_revenue(int numOfTickets)
        {
            return numOfTickets * TicketPrice;
        }

        public decimal calculate_booking_cost(int numOfTickets)
        {
            return numOfTickets * TicketPrice;
        }

        public int getBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }
        public void book_ticktes(int numOfTickets)
        {
            if (numOfTickets <= AvailableSeats)
            {
                AvailableSeats -= numOfTickets;
                Console.WriteLine($"{numOfTickets} are booked successfully for the Event: {EventName} at Date: {EventDate} and Time: {EventTime}");
            }
            else
            {
                Console.WriteLine($"Cannot book tickets for the Event:{EventName} , The No of Available Tickets are {AvailableSeats}");
            }
        }
        public void cancel_booking(int num_tickets)
        {
            AvailableSeats += num_tickets;
            Console.WriteLine($"Cancellation of {num_tickets} Tickets is Successfull for the Event: {EventName} at Date: {EventDate} and Time: {EventTime}");
        }

        public string display_event_details()
        {


            return $"Event Name: {EventName}\nEvent Date: {EventDate}\nEvent Time: {EventTime}\nVenue: {VenueName.VenueName}\nTotal Seats: {TotalSeats}\nAvailable Seats: {AvailableSeats}\nTicket Price: {TicketPrice}\nEvent Type: {EventType}";

        }
        public override string ToString()
        {
            return $"{EventName}";
        }

        public int CompareTo(Event other)
        {
            int nameComparision = string.Compare(this.EventName, other.EventName, StringComparison.Ordinal);
            if (nameComparision != 0)
            {
                return nameComparision;
            }
            return this.VenueName.Address.CompareTo(other.VenueName.Address);
        }
    }
}
