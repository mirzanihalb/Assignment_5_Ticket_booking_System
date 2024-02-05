using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_Has_a_ralation_association.Model
{
    internal class BookingSystem : Booking
    {
        public List<Event> all_events = new List<Event>();
        public List<Booking> all_booked = new List<Booking>();



        public Event create_event(string event_name, DateTime date, TimeSpan time, int total_seats, decimal ticket_price, EventType event_type, Venue venue)
        {

            Event event_obj = new Event(
                event_name, date, time, venue, total_seats, ticket_price, event_type);
            all_events.Add(event_obj);
            return event_obj;
        }

        public decimal calculate_booking_cost(Event event_obj, int num_tickets)
        {
            return event_obj.TicketPrice * num_tickets;
        }

        public void book_tickets(string event_name, int num_tickets, List<Customer> customers)
        {
            Event event_obj = all_events.Find(x => x.EventName == event_name);
            if (event_obj != null)
            {
                Booking booking_obj = new Booking(event_obj, customers, num_tickets);
                booking_obj.BookTickets();
                all_booked.Add(booking_obj);
                Console.WriteLine("Tickkets booked successfully");
            }
            else
            {
                Console.WriteLine("No Such event present");
            }
        }
        public void cancel_booking(int booking_id)
        {
            Booking booking_obj  = all_booked.Find(x=>x.BookingId == booking_id);
            if (booking_obj != null)
            {
                Event event_obj_booked = booking_obj.Event;
                event_obj_booked.cancel_booking(booking_obj.NumTickets);
                all_booked.Remove(booking_obj);
                Console.WriteLine("Cancellation of booking is successfull");
            }
            else
            {
                Console.WriteLine("No such booking Id is present to cancel the booking");
            }
        }

        public int getAvailableNoOfTickets(string event_name)
        {
            Event event_obj = all_events.Find(x=> x.EventName == event_name);
            if (event_obj != null)
            {
                return event_obj.AvailableSeats;
            }
            else
            {
                
                return 0;
            }
        }

        public string getEventDetails(string event_name)
        {
            Event event_obj = all_events.Find(x => x.EventName == event_name);
            if (event_obj != null)
            {
                return event_obj.display_event_details();
            }
            else
            {
                return "No Such Event To get the Number of Available Tickets";
                
            }
        }
    }
}
