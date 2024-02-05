using Task_5_Inheritance_and_polymorphism.Model;
namespace Task_5_Inheritance_and_polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Event> all_events = new List<Event>();

            Movie dynasty = new Movie("Dynasty",DateTime.Now,new TimeSpan(19,30,0),"vijayawada",100,175.5m,"Action","Hero","Heroine");
            // Console.WriteLine(dynasty.display_event_details());


            Concert Brain = new Concert("Concert Brain", DateTime.Now, new TimeSpan(19, 30, 0), "vijayawada", 100, 175.5m, "Sumayyah", "Classical");
            //Console.WriteLine(dynasty.display_concert_details());

            Sports final_match = new Sports("World Cup Match", DateTime.Now, new TimeSpan(19, 30, 0), "vijayawada", 100, 175.5m, "Cricket", "Ind VS Pak");
            //Console.WriteLine(dynasty.display_sport_details());

            all_events.Add(dynasty);
            all_events.Add(Brain);
            all_events.Add(final_match);


            while (true)
            {
                Console.WriteLine("Ticket Booking System");
            Console.WriteLine("Events Menu");
            Console.WriteLine("1> Book Tickets for Movies/Concert/sports");
            Console.WriteLine("2> Display Event Details of an Event");
            Console.WriteLine("3> Book Tickets");
            Console.WriteLine("4> Cancel Tickets");
            Console.WriteLine("5> Exit");
            int menu_option = int.Parse(Console.ReadLine());
            
                switch (menu_option)
                {
                    case 1:
                        Console.WriteLine("Events Menu");
                        Console.WriteLine("1> Movies");
                        Console.WriteLine("2> Concert");
                        Console.WriteLine("3> sports");

                        int event_option = int.Parse(Console.ReadLine());
                        switch (event_option)
                        {
                            case 1:
                                foreach (var ev in all_events)
                                {
                                    if (ev.EventType == EventType.Movie)
                                    {
                                        Console.WriteLine(ev.EventName);
                                    }
                                }
                                break;

                            case 2:
                                foreach (var ev in all_events)
                                {
                                    if (ev.EventType == EventType.Concert)
                                    {
                                        Console.WriteLine(ev.EventName);
                                    }
                                }
                                break;
                            case 3:
                                foreach (var ev in all_events)
                                {
                                    if (ev.EventType == EventType.Concert)
                                    {
                                        Console.WriteLine(ev.EventName);
                                    }
                                }
                                break;
                            default: Console.WriteLine("Choose correct type"); break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the Event Name");
                        string input_event_name = Console.ReadLine();
                        Event event_obj = FindEvent(all_events, input_event_name);
                        if (event_obj != null)
                        {
                            Console.WriteLine(event_obj.display_event_details());
                        }
                        else
                        {
                            Console.WriteLine("Event Not Found/ or please type the event name correctly");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the Event Name");
                        string input_event = Console.ReadLine();
                        Console.WriteLine("Enter the No of Tickets :");
                        int noOfTickets = int.Parse(Console.ReadLine());
                        Event obj = FindEvent(all_events, input_event);
                        if (obj != null)
                        {
                            int status = obj.book_ticktes(noOfTickets);
                        }
                        else
                        {
                            Console.WriteLine("Event Not Found/ or please type the event name correctly");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the Event Name");
                        string inp = Console.ReadLine();
                        Console.WriteLine("Enter the No of Tickets :");
                        int noOfTicketsToCancel = int.Parse(Console.ReadLine());
                        Event obj_event_to_cancel = FindEvent(all_events, inp);
                        if (obj_event_to_cancel != null)
                        {
                            obj_event_to_cancel.cancel_booking(noOfTicketsToCancel);
                        }
                        else
                        {
                            Console.WriteLine("Event Not Found/ or please type the event name correctly");
                        }
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Choose the Correct Option the menu!");
                        break;
                }
            }
        }
        
            
        public static Event FindEvent(List<Event>all_events,string eventName)
        {
            Event event_obj = all_events.Find(x => x.EventName == eventName);
            return event_obj;
        }
            



        }
    }

