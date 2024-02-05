using Task_6_Abstraction.dao;
using Task_6_Abstraction.Model;

namespace Task_6_Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();
            int flag = 1;
            while (flag==1)
            {
                Console.WriteLine("Enter a command ('create_event', 'book_tickets', 'cancel_tickets', 'get_available_seats', 'display_events', 'exit'):");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "create_event":
                        Console.WriteLine("Enter event details:");
                        // Get common event details
                        Console.Write("Event Name: ");
                        string eventName = Console.ReadLine();
                        Console.Write("Event Date (yyyy-MM-dd): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Event Time (HH:mm:ss): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());
                        Console.Write("Venue Name: ");
                        string venueName = Console.ReadLine();
                        Console.Write("Total Seats: ");
                        int totalSeats = int.Parse(Console.ReadLine());
                        Console.Write("Ticket Price: ");
                        decimal ticketPrice = decimal.Parse(Console.ReadLine());

                        // Get additional details based on the event type
                        Console.Write("Event Type (Movie/Concert/Sport): ");
                        EventType eventType = Enum.Parse<EventType>(Console.ReadLine(), true); // Case-insensitive parse

                        Event newEvent;

                        switch (eventType)
                        {
                            case EventType.Movie:
                                Console.Write("Genre: ");
                                string genre = Console.ReadLine();
                                Console.Write("Actor Name: ");
                                string actorName = Console.ReadLine();
                                Console.Write("Actress Name: ");
                                string actressName = Console.ReadLine();

                                newEvent = new Movie(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, genre, actorName, actressName);
                                break;

                            case EventType.Concert:
                                Console.Write("Band Name: ");
                                string bandName = Console.ReadLine();
                                Console.Write("Music Genre: ");
                                string musicGenre = Console.ReadLine();

                                newEvent = new Concert(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, bandName, musicGenre);
                                break;

                            case EventType.Sport:
                                Console.Write("Sport Type: ");
                                string sportType = Console.ReadLine();
                                Console.Write("Team 1: ");
                                string teams = Console.ReadLine();
                                

                                newEvent = new Sport(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, sportType, teams);
                                break;

                            default:
                                Console.WriteLine("Invalid event type.");
                                return;
                        }

                        ticketBookingSystem.create_event(newEvent);
                        break;

                    case "book_tickets":
                        Console.WriteLine("Enter event name:");
                        string eventNameToBook = Console.ReadLine();
                        Console.WriteLine("Enter the number of tickets to book:");
                        int numTicketsToBook = int.Parse(Console.ReadLine());
                        ticketBookingSystem.book_tickets(eventNameToBook, numTicketsToBook);
                        break;

                    case "cancel_tickets":
                        Console.WriteLine("Enter event name:");
                        string eventNameToCancel = Console.ReadLine();
                        Console.WriteLine("Enter the number of tickets to cancel:");
                        int numTicketsToCancel = int.Parse(Console.ReadLine());
                        ticketBookingSystem.cancel_tickets(eventNameToCancel, numTicketsToCancel);
                        break;

                    case "get_available_seats":
                        Console.WriteLine("Enter event name:");
                        string eventNameToCheck = Console.ReadLine();
                        int availableSeats = ticketBookingSystem.get_available_seats(eventNameToCheck);
                        if (availableSeats >= 0)
                        {
                            Console.WriteLine($"Available seats for '{eventNameToCheck}': {availableSeats}");
                        }
                        break;

                    case "display_events":
                        ticketBookingSystem.DisplayAvailableEvents();
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
