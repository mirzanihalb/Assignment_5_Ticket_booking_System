using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_Interface_abstract_class_and_Single_Inheritance_static_variable;

namespace Task_8_Interface_abstract_class__and_Single_Inheritance_static_variable.service
{
    internal interface IBookingSystemServiceProvider
    {
        public decimal calculate_booking_cost(Event event_obj, int num_tickets);

        public void book_tickets(string event_name, int num_tickets, List<Customer> customers);

        public void cancel_booking(int booking_id);

        public Booking get_booking_details(int booking_id);
    }
}
