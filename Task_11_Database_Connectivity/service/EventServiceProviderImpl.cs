using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Exceptions;
using Task_9_11_Database_Connectivity.Model;
using Task_9_11_Database_Connectivity.Repository;
using Task_9_11_Database_Connectivity.service;


namespace Task_9_11_Database_Connectivity.service
{
    internal class EventServiceProviderImpl : IEventServiceProvider
    {
        
        IBookingSystemRepository repository = new BookingSystemRepositoryImpl();




        

        public void create_event()
        {
            try
            {
                Console.WriteLine("Enter event details:");

                Console.Write("Event Name: ");
                string eventName = Console.ReadLine();
                Console.Write("Event Date (yyyy-MM-dd): ");
                DateTime eventDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Event Time (HH:mm:ss): ");
                TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());


                //iterate through the venue and display all the venues
                Console.WriteLine("Select the Id of the Venue Where the Events Take place from below : ");
                List<Venue> venue_list = repository.allVenues();
                foreach (var venue in venue_list)
                {
                    Console.WriteLine(venue);
                }
                int venue_id = int.Parse(Console.ReadLine());
                Venue venue_obj = null;
                foreach (var venue in venue_list)
                {
                    venue_obj = venue_list.Find(x => x.VenueId == venue_id);
                }
                if (venue_obj == null)
                {
                    throw new NullPointerException("No Such Venue Present");
                }


                Console.Write("Total Seats: ");
                int totalSeats = int.Parse(Console.ReadLine());
                Console.Write("Ticket Price: ");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());


                Console.Write("Event Type (Movie/Concert/Sport): ");
                EventType eventType = Enum.Parse<EventType>(Console.ReadLine());

                Event event_obj = repository.create_event(eventName, eventDate, eventTime, totalSeats, ticketPrice, eventType, venue_obj);

                if (event_obj != null)
                {
                    Console.WriteLine("Event Successfully Created");
                }
                else
                {
                    Console.WriteLine("Event could not be Created please try again");
                }
            }
            catch (EventNotFoundException e) { Console.WriteLine(e.Message); }
            catch (NullPointerException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }


        }
        public void getAvailableNoOfTickets()
        {
            try
            {
                getEventDetails();
                Console.WriteLine("Enter Event Id to get the Number of Available tickets");
                int user_input = int.Parse(Console.ReadLine());
                Event event_obj = repository.getAvailableNoOfTickets(user_input);

                Console.WriteLine($"No of Available Tickets are {event_obj.AvailableSeats}");
            }
            catch (EventNotFoundException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public void getEventDetails()
        {
            try
            {
                List<Event> event_list = new List<Event>();
                event_list = repository.getEventDetails();
                foreach (Event e in event_list)
                {
                    Console.WriteLine(e);
                }

            }catch(EventNotFoundException e) { Console.WriteLine(e.Message); } 
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
