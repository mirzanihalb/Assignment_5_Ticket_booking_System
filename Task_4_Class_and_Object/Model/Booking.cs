using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_Class_and_Object.Model
{
    internal class Booking
    {
        
        // Attributes
        public Event Event { get; set; }

        int BookingId { get; set; }
        int CustomerId { get; set; }
        

        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }

        public DateTime BookingDate { get; set; }

        
        public Booking()
        {
            // Default constructor

        }

        public Booking(Event event_obj, int customer_id,int numTickets)
        {
            
            Event = event_obj;
            CustomerId = customer_id;
            NumTickets = numTickets;
            TotalCost =  calculate_booking_cost(numTickets);
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
    }

}
