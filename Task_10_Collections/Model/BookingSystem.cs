using System;
using System.Collections.Generic;
using System.Linq;
using Task_10_Collections.Model;


namespace Task_10_Collections.Model
{
    internal class BookingSystem : Booking_with_set
    {
        public SortedSet<Event> all_events = new SortedSet<Event>();
        public HashSet<Booking_with_set> all_booked = new HashSet<Booking_with_set>();

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

        public void book_tickets(string event_name, int num_tickets, SortedSet<Customer> customers)
        {
            Event event_obj = all_events.FirstOrDefault(x => x.EventName == event_name);
            if (event_obj != null)
            {
                Booking_with_set booking_obj = new Booking_with_set(event_obj, customers, num_tickets);
                booking_obj.BookTickets();
                all_booked.Add(booking_obj);
                Console.WriteLine("Tickets booked successfully");
            }
            else
            {
                Console.WriteLine("No such event present");
            }
        }

        public void cancel_booking(int booking_id)
        {
            Booking_with_set booking_obj = all_booked.FirstOrDefault(x => x.BookingId == booking_id);
            if (booking_obj != null)
            {
                Event event_obj_booked = booking_obj.Event;
                event_obj_booked.cancel_booking(booking_obj.NumTickets);
                all_booked.Remove(booking_obj);
                Console.WriteLine("Cancellation of booking is successful");
            }
            else
            {
                Console.WriteLine("No such booking ID is present to cancel the booking");
            }
        }

        public int getAvailableNoOfTickets(string event_name)
        {
            Event event_obj = all_events.FirstOrDefault(x => x.EventName == event_name);
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
            Event event_obj = all_events.FirstOrDefault(x => x.EventName == event_name);
            if (event_obj != null)
            {
                return event_obj.display_event_details();
            }
            else
            {
                return "No such event to get the number of available tickets";
            }
        }
        public void get_booking_details(int id)
        {
            Booking_with_set booking_obj = all_booked.FirstOrDefault(x => x.BookingId == id);
            if (booking_obj != null)
            {
                Console.WriteLine(booking_obj);
            }
            else
            {
                Console.WriteLine("No details");
            }
        }
    }
}
