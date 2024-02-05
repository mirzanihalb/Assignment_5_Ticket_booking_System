using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Model;
using Task_9_11_Database_Connectivity.service;



namespace Task_9_11_Database_Connectivity.app
{
    internal class TicketBookingSystem
    {
        public void run()
        {
            Customer loggedInUser = null;
            IEventServiceProvider service = new EventServiceProviderImpl();

            IBookingSystemServiceProvider repobooking = new BookingSystemServiceProviderImpl();

            loggedInUser = repobooking.login();

            while (loggedInUser!=null)
            {
                Console.WriteLine("Enter a command ('create_event', 'book_tickets','get_booking_details', 'cancel_tickets', 'get_available_seats', 'display_events', 'exit'):");
                string choice = Console.ReadLine();



                switch (choice)
                {
                    case "create_event":

                        service.create_event();
                        


                        break;

                    case "book_tickets":
                        repobooking.book_tickets();
                        break;

                    case "cancel_tickets":
                        repobooking.cancel_booking();
                        break;

                    case "get_available_seats":
                        service.getAvailableNoOfTickets();
                        break;

                    case "display_events":
                        service.getEventDetails();
                        break;

                    case "get_booking_details":
                        repobooking.get_booking_details();
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the ticket booking system.");
                        loggedInUser = null;
                        return;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
    }
}
