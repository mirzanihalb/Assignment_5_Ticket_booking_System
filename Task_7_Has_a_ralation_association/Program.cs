using Task_7_Has_a_ralation_association.Model;
namespace Task_7_Has_a_ralation_association
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookingSystem bookingSystem = new BookingSystem();
            
            while (true)
            {
                Console.WriteLine("Enter a command ('create_event', 'book_tickets', 'cancel_tickets', 'get_available_seats', 'display_events', 'exit'):");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "create_event":
                        Console.WriteLine("Enter event details:");
                        
                        Console.Write("Event Name: ");
                        string eventName = Console.ReadLine();
                        Console.Write("Event Date (yyyy-MM-dd): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Event Time (HH:mm:ss): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());
                        Console.Write("Venue Name: ");
                        string venueName = Console.ReadLine();
                        Console.Write("Venue Address: ");
                        string venueAddress = Console.ReadLine();
                        Venue venue_obj = new Venue(venueName, venueAddress);
                        Console.Write("Total Seats: ");
                        int totalSeats = int.Parse(Console.ReadLine());
                        Console.Write("Ticket Price: ");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());

                        
                        Console.Write("Event Type (Movie/Concert/Sport): ");
                        EventType eventType = Enum.Parse<EventType>(Console.ReadLine());

                        Event newEvent;

                        newEvent = bookingSystem.create_event(eventName,eventDate,eventTime,totalSeats,ticketPrice,eventType,venue_obj);
                        if (newEvent != null)
                        {
                            Console.WriteLine("Successfully created the Event");
                        }
                        
                        break;

                    case "book_tickets":
                        Console.WriteLine("Enter event name:");
                        string eventNameToBook = Console.ReadLine();
                        Console.WriteLine("Enter the number of tickets to book:");
                        int numTicketsToBook = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter all the Names Of Persons Attending the Event");
                        List<Customer> customerList = new List<Customer>();
                        for(int i = 0; i <= numTicketsToBook; i++)
                        {
                            Customer user_obj = new Customer();
                            user_obj.CustomerName = Console.ReadLine();
                            customerList.Add(user_obj);
                        }
                        bookingSystem.book_tickets(eventNameToBook, numTicketsToBook,customerList);
                        break;

                    case "cancel_tickets":
                        List<Booking> all_bookings = bookingSystem.all_booked;
                        int flag = 0;
                        foreach(var booking in all_bookings)
                        {
                            Console.WriteLine(booking);
                            flag = 1;
                        }
                        if (flag == 1)
                        {
                            Console.WriteLine("Enter booking id:");
                            int booking_id = int.Parse(Console.ReadLine());

                            bookingSystem.cancel_booking(booking_id);
                        }
                        else
                        {
                            Console.WriteLine("There are No bookings To cancel the Tickets");
                        }
                        break;

                    case "get_available_seats":
                        Console.WriteLine("Enter event name:");
                        string event_name = Console.ReadLine();
                        int availableSeats = bookingSystem.getAvailableNoOfTickets(event_name);
                        if (availableSeats >= 0)
                        {
                            Console.WriteLine($"Available seats for '{event_name}': {availableSeats}");
                        }
                        else
                        {
                            Console.WriteLine("No Such Event To get the Number of Available Tickets");
                        }
                        break;

                    case "display_events":
                        List<Event> all_events = bookingSystem.all_events;
                        foreach(var ev in all_events)
                        {
                            Console.WriteLine(ev);
                        }
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the ticket booking system.");
                        return;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
    }
}
