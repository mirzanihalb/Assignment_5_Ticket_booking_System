using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Abstraction.dao
{
    internal abstract class BookingSystem
    {
        public abstract void create_event(Event event_obj);

        public abstract string display_event_details(string eventName);

        public abstract decimal book_tickets(string eventName, int num_ticktes);

        public abstract void cancel_tickets(string eventName, int num_tickets);

        public abstract int get_available_seats(string eventName);
    }
}
