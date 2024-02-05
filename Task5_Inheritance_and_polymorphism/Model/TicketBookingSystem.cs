using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Inheritance_and_polymorphism.Model
{
    internal class TicketBookingSystem
    {
        public Event create_event(string event_name,DateTime date,TimeSpan time,int total_seats,decimal ticket_price,EventType event_type,string venue_name)
        {
            Event event_obj = new Event(event_name,date,time,venue_name,total_seats,ticket_price,event_type);
            return event_obj;
        }

        public string display_event_details(Event event_obj){
            return event_obj.display_event_details();
        }

        public decimal book_tickets(Event event_obj, int num_ticktes)
        {
            decimal total_cost = 0.0m;
            int flag = event_obj.book_ticktes(num_ticktes);
            if (flag == 1)
            {
                event_obj.AvailableSeats -= num_ticktes;
                total_cost = event_obj.TicketPrice*num_ticktes;
                return total_cost;
            }
            return total_cost;
        }

        public void cancel_tickets(Event event_obj, int num_tickets){
            event_obj.AvailableSeats += num_tickets;
            Console.WriteLine($"Cancellation of {num_tickets} Tickets is Successfull for the Event: {event_obj.EventName} at Date: {event_obj.EventDate} and Time: {event_obj.EventTime}");
        }


    }
}
