using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_Interface_abstract_class__and_Single_Inheritance_static_variable.service;


namespace Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable.bean
{
    internal class EventServiceProviderImpl : IEventServiceProvider
    {
        public static List<Event> all_events = new List<Event>();
        


        public Event create_event(string event_name, DateTime date, TimeSpan time, int total_seats, decimal ticket_price, EventType event_type, Venue venue)
        {

            Event event_obj = new Event(
                event_name, date, time, venue, total_seats, ticket_price, event_type);
            all_events.Add(event_obj);
            return event_obj;
        }
        public int getAvailableNoOfTickets(string event_name)
        {
            Event event_obj = all_events.Find(x => x.EventName == event_name);
            if (event_obj != null)
            {
                return event_obj.AvailableSeats;
            }
            else
            {

                return 0;
            }
        }

        public List<Event> getEventDetails()
        {
            return all_events;
        }
    }
}
