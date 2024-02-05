using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Exceptions;
using Task_9_11_Database_Connectivity.Model;
using Task_9_11_Database_Connectivity.Repository;



namespace Task_9_11_Database_Connectivity.service
{
    internal class BookingSystemServiceProviderImpl : IBookingSystemServiceProvider
    {
        //public List<Event> all_events = EventServiceProviderImpl.all_events;
        IBookingSystemRepository repository = new BookingSystemRepositoryImpl();

        public List<Booking> all_booked = new List<Booking>();

        Customer LoggedInUser = new Customer();

        public Customer login()
        {
            try
            {
                Console.WriteLine("Enter Email : ");
                string email = Console.ReadLine();

            
                Console.WriteLine("Enter Password : ");
                string password = Console.ReadLine();
                Customer customerObj = repository.login(email);

                //call the order repository get the user obj and set it to  loggedin user 
                if (customerObj == null)
                {
                    throw new NullPointerException("No Such email Exists");
                    
                }

                if (customerObj != null && customerObj.password != password)
                {
                    Console.WriteLine("The password you have entered is wrong please check");
                    return null;
                    
                }
                else if (customerObj != null)
                {
                    LoggedInUser = customerObj;
                    Console.WriteLine("Successfully Logged In");
                    return customerObj;

                }
                return null;

            }catch(NullPointerException e) { Console.WriteLine(e.Message);return null; }
            catch (Exception ex) { Console.WriteLine(ex.Message);return null; }
        }
        
        public void book_tickets()
        {
            try
            {
                List<Event> allevnts = repository.getEventDetails();
                foreach (Event e in allevnts)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Enter Event Name to book tickets");
                string event_name_user_input = Console.ReadLine();

                Event event_obj = null;
                
                foreach (Event e in allevnts)
                {
                    event_obj = allevnts.Find(x => x.EventName == event_name_user_input);

                }
                if (event_obj == null) { throw new EventNotFoundException("No Such Event"); }

                Console.WriteLine(event_obj);
                Console.WriteLine("Enter the number of Tickets You want to book");
                int Num_of_tickets = int.Parse(Console.ReadLine());

                int status = repository.book_tickets(LoggedInUser, event_obj, Num_of_tickets);
                if (status == 1)
                {
                    Console.WriteLine("Successfully booked Tickets");
                }
                else
                {
                    Console.WriteLine("try again");
                }
            }
            
            catch (EventNotFoundException e) { Console.WriteLine(e.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void cancel_booking()
        {
            try
            {
                List<Booking> customer_bookings = new List<Booking>();
                customer_bookings = repository.get_bookings_by_customer_id(LoggedInUser);
                if (customer_bookings == null)
                {
                    throw new NullPointerException("No bookings");
                }
                foreach (Booking booking in customer_bookings)
                {
                    Console.WriteLine(booking);
                }
                Console.WriteLine("Enter the Booking Id to cancel the booking");
                int bookingIdToCancel = int.Parse(Console.ReadLine());
                Booking booking_obj = null;
                foreach (Booking booking in customer_bookings)
                {
                    booking_obj = customer_bookings.Find(x => x.BookingId == bookingIdToCancel);
                }
                if (booking_obj == null)
                {
                    throw new NullPointerException("No such booking can be found");
                }
                
                int cancelStatus = repository.cancel_booking(bookingIdToCancel, booking_obj.EventId, booking_obj.NumTickets);
                
                if (cancelStatus == 1)
                {
                    Console.WriteLine($"Successfully cancelled the booking with id {bookingIdToCancel}");

                }
                else
                {
                    Console.WriteLine("try again to cancecl the booking");
                }
            }
            catch(NullPointerException e) { Console.WriteLine(e.Message); }
            catch(InvalidBookingIDException e) { Console.WriteLine(e.Message);}
            catch (EventNotFoundException e) { Console.WriteLine(e.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message);}
        }

        public void get_booking_details()
        {
            try
            {
                List<Booking> customer_bookings = repository.get_bookings_by_customer_id(LoggedInUser);
                foreach (Booking booking in customer_bookings)
                {
                    Console.WriteLine(booking);
                }
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        
    }
}
