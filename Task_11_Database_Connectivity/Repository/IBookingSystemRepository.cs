using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Model;

namespace Task_9_11_Database_Connectivity.Repository
{
    internal interface IBookingSystemRepository
    {
        public Customer login(string email);
        public Event create_event(string event_name,DateTime date,TimeSpan time,int total_seats,decimal ticket_price,EventType eventType,Venue venue);

        public List<Event> getEventDetails();

        public Event getAvailableNoOfTickets(int event_id);

        public decimal calculate_booking_cost(int num_tickets, decimal ticket_price);

        public int book_tickets(Customer customer,Event event_obj,int num_tickets);

        public int cancel_booking(int booking_id,int event_id,int num_tickets);

        public Booking get_booking_details(int booking_id);


        public List<Venue> allVenues();
        List<Booking> get_bookings_by_customer_id(Customer loggedInUser);
    }
}
