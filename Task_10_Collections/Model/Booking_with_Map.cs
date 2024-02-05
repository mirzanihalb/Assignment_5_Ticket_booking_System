using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_Collections.Model
{
    internal class Booking_with_Map
    {

        public static int increment = 0;
        // Attributes
        public Event Event { get; set; }

        public int BookingId { get; set; }
        public Dictionary<int,Customer> Customers { get; set; }


        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }

        public DateTime BookingDate { get; set; }


        public Booking_with_Map()
        {
            // Default constructor

        }

        public Booking_with_Map(Event event_obj, Dictionary<int,Customer> customers, int numTickets)
        {
            BookingId = increment + 1;
            increment += 1;
            Event = event_obj;
            Customers = customers;
            NumTickets = numTickets;
            TotalCost = calculate_booking_cost(numTickets);
            BookingDate = DateTime.Now;
        }

        // Methods

        public decimal calculate_booking_cost(int NumTickets)
        {
            decimal TotalCostCalc = NumTickets * Event.TicketPrice;
            return TotalCostCalc;
        }

        public void BookTickets()
        {
            Event.book_ticktes(NumTickets);
        }

        public void CancelBooking()
        {
            Event.cancel_booking(NumTickets);
        }

        public int GetAvailableNoOfTickets()
        {
            return Event.AvailableSeats;
        }

        public string GetEventDetails()
        {
            return Event.display_event_details();
        }

        public override string ToString()
        {
            return $"{BookingId} {Event.EventName}";
        }
    }

}
