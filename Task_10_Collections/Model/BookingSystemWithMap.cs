using System;
using System.Collections.Generic;
using System.Linq;
using Task_10_Collections.Model;


namespace Task_10_Collections.Model
{
    internal class BookingSystemWithMap : Booking_with_Map
    {
        public int event_inc = 0;
        public int booking_inc = 0;
        public Dictionary<int,Event> all_events = new Dictionary<int,Event>();
        public Dictionary<int,Booking_with_set> all_booked = new Dictionary<int, Booking_with_set>();

        public Event create_event(string event_name, DateTime date, TimeSpan time, int total_seats, decimal ticket_price, EventType event_type, Venue venue)
        {
            Event event_obj = new Event(
                event_name, date, time, venue, total_seats, ticket_price, event_type);
            booking_inc += 1;
            all_events.Add(booking_inc,event_obj);
            return event_obj;
        }

        public decimal calculate_booking_cost(Event event_obj, int num_tickets)
        {
            return event_obj.TicketPrice * num_tickets;
        }

        public void book_tickets(string event_name, int num_tickets, SortedSet<Customer> customers)
        {
            var event_obj = all_events.FirstOrDefault(x => x.Value.EventName==event_name);
            if (event_obj.Value != null)
            {
                Booking_with_set booking_obj = new Booking_with_set(event_obj.Value, customers, num_tickets);
                booking_obj.BookTickets();
                booking_inc += 1;
                all_booked.Add(booking_inc, booking_obj);
                Console.WriteLine("Tickets booked successfully");
            }
            else
            {
                Console.WriteLine("No such event present");
            }
        }

        public void cancel_booking(int booking_id)
        {
            var booking_obj = all_booked.FirstOrDefault(x => x.Key == booking_id);
            if (booking_obj.Value != null)
            {
                Event event_obj_booked = booking_obj.Value.Event;
                event_obj_booked.cancel_booking(booking_obj.Value.NumTickets);
                all_booked.Remove(booking_obj.Key);
                Console.WriteLine("Cancellation of booking is successful");
            }
            else
            {
                Console.WriteLine("No such booking ID is present to cancel the booking");
            }
        }

        public int getAvailableNoOfTickets(string event_name)
        {
            var event_obj = all_events.FirstOrDefault(x => x.Value.EventName == event_name);
            if (event_obj.Value != null)
            {
                return event_obj.Value.AvailableSeats;
            }
            else
            {
                return 0;
            }
        }

        public string getEventDetails(string event_name)
        {
            var event_obj = all_events.FirstOrDefault(x => x.Value.EventName == event_name);
            if (event_obj.Value.EventName != null)
            {
                return event_obj.Value.display_event_details();
            }
            else
            {
                return "No such event to get the number of available tickets";
            }
        }
        public void get_booking_details(int id)
        {
            var booking_obj = all_booked.FirstOrDefault(x => x.Key == id);
            if (booking_obj.Value != null)
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
