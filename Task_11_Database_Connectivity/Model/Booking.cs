using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_11_Database_Connectivity.Model
{
    internal class Booking
    {

        
        // Attributes
        public int EventId { get; set; }

        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        
        public Event event_obj { get; set; }

        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }

        public DateTime BookingDate { get; set; }

        
        public Booking()
        {
            // Default constructor

        }

        public Booking(int id,int event_id, int customer_id,int numTickets)
        {
            
            BookingId = id;
            event_id = event_id;
            customer_id = customer_id;
            NumTickets = numTickets;
            
            BookingDate = DateTime.Now.Date;
        }

        

        

        public override string ToString()
        {
            return $"Booking Id : {BookingId} EventName : {event_obj.EventName}  NumOfTickets : {NumTickets} TotalCost : {TotalCost} BookingDate {BookingDate}";
        }
    }

}
