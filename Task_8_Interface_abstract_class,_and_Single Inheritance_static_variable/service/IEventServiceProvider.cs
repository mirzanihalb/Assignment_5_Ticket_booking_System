using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable;

namespace Task_8_Interface_abstract_class__and_Single_Inheritance_static_variable.service
{
    internal interface IEventServiceProvider
    {
        public Event create_event(string name,
                                  DateTime date,
                                  TimeSpan time,
                                  int total_seats,
                                  decimal ticket_price,
                                  EventType event_type,
                                  Venue venu);

        public List<Event> getEventDetails();

        public int getAvailableNoOfTickets(string event_name);
    }
}
