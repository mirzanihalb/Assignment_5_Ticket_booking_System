using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6_Abstraction.dao;

namespace Task_6_Abstraction.Model
{
    internal class TicketBookingSystem:BookingSystem
    {
        private List<Event> events;

        public TicketBookingSystem()
        {
            events = new List<Event>();
        }
        public override void create_event(Event event_obj)
        {
            events.Add(event_obj);
            Console.WriteLine($"Event '{event_obj.EventName}' created successfully.");
            
        }

        public override decimal book_tickets(string eventName, int numTickets)
        {
            Event selectedEvent = FindEvent(eventName);
            if (selectedEvent != null)
            {
                return selectedEvent.book_ticktes(numTickets);
            }
            else
            {
                Console.WriteLine($"Event {eventName} not found.");
                return 0m;
            }
        }

        public override void cancel_tickets(string eventName, int numTickets)
        {
            Event selectedEvent = FindEvent(eventName);
            if (selectedEvent != null)
            {
                selectedEvent.cancel_booking(numTickets);
            }
            else
            {
                Console.WriteLine($"Event '{eventName}' not found.");
            }
        }

        public override int get_available_seats(string eventName)
        {
            Event selectedEvent = FindEvent(eventName);
            if (selectedEvent != null)
            {
                return selectedEvent.AvailableSeats;
            }
            else
            {
                Console.WriteLine($"Event '{eventName}' not found.");
                return -1; // Return a negative value to indicate an error
            }
        }

        public override string display_event_details(string eventName)
        {
            Event selectedEvent = FindEvent(eventName);
            if (selectedEvent != null)
            {
                return selectedEvent.display_event_details();
            }
            else
            {
                return $"Event '{eventName}' not found.";
            }
        }

        private Event FindEvent(string eventName)
        {
            return events.Find(e => e.EventName==eventName);
        }

        public void DisplayAvailableEvents()
        {
            Console.WriteLine("Available Events:");
            foreach (Event event_item in events)
            {
                Console.WriteLine($"{event_item.EventName}");
            }
        }
    }
}
