using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_Interface_abstract_class__and_Single_Inheritance_static_variable.service;
using Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable;
using Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable.bean;

namespace Task_8_Interface_abstract_class__and_Single_Inheritance_static_variable.bean
{
    internal class BookingSystemServiceProviderImpl: EventServiceProviderImpl,IBookingSystemServiceProvider
    {
        public List<Event> all_events = EventServiceProviderImpl.all_events;
        public List<Booking> all_booked = new List<Booking>();
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
            Booking booking_obj = all_booked.Find(x => x.BookingId == booking_id);
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

        public Booking get_booking_details(int booking_id)
        {
            Booking booking_obj = all_booked.Find(x => x.BookingId == booking_id);
            if (booking_obj != null)
            {
                return booking_obj;
            }
            else
            {
                return null;
            }
        }
    }
}
