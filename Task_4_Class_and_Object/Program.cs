using Microsoft.VisualBasic;
using System.Threading.Channels;
using Task_4_Class_and_Object.Model;
namespace Task_4_Class_and_Object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Event movieEvent = new Event("Movie Night", DateTime.Now.Date, new TimeSpan(18, 30, 0), "Cinema Hall", 100, 12.5m, EventType.Movie);

            //calculate_booking_cost(num_tickets): Calculate and set the total cost of the booking.
           Console.WriteLine(movieEvent.calculate_booking_cost(5));

            //book_tickets(num_tickets): Book a specified number of tickets for an event
            movieEvent.book_ticktes(5);

            //cancel_booking(num_tickets): Cancel the booking and update the available seats.
            movieEvent.cancel_booking(5);

            //getAvailableNoOfTickets(): return the total available tickets
           
            Console.WriteLine(movieEvent.AvailableSeats);

            // getEventDetails(): return event details from the event class
            Console.WriteLine(movieEvent.display_event_details());




        }
    }
}
