using Task_9_11_Database_Connectivity.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Exceptions;
using Task_9_11_Database_Connectivity.Model;

namespace Task_9_11_Database_Connectivity.Repository
{
    internal class BookingSystemRepositoryImpl : IBookingSystemRepository
    {
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public BookingSystemRepositoryImpl()
        {
            
            sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            
        }

        

        //List<Venue> allEventsInDb = allVenues();
        public int book_tickets(Customer customer, Event event_obj, int num_tickets)
        {
            try
            {
                
                decimal booking_cost = calculate_booking_cost(num_tickets, event_obj.TicketPrice);
                DateTime booking_date = DateTime.Now.Date;
                Booking booking_obj = new Booking();
                booking_obj.CustomerId = customer.CustomerId;
                booking_obj.EventId = event_obj.EventId;
                booking_obj.event_obj = event_obj;
                booking_obj.NumTickets = num_tickets;
                booking_obj.TotalCost = booking_cost;
                booking_obj.BookingDate = booking_date;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into booking(customer_id,event_id,num_tickets,total_cost,booking_date) values(@customerid,@eventId,@numTickets,@totalCost,@bookingDate);select SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("customerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("eventId", event_obj.EventId);
                cmd.Parameters.AddWithValue("numTickets", num_tickets);
                cmd.Parameters.AddWithValue("totalCost", booking_cost);
                cmd.Parameters.AddWithValue("bookingDate", booking_date);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int id_generated = Convert.ToInt32(cmd.ExecuteScalar());

                sqlconnection.Close();
                booking_obj.BookingId = id_generated;


                if (id_generated > 0)
                {
                    cmd.CommandText = "update Event set available_seats = available_Seats-@numTickets where event_id = @eventId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("numTickets", num_tickets);
                    cmd.Parameters.AddWithValue("eventId", event_obj.EventId);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int updatestatus = (int)cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                    return 1;
                    if (updatestatus == 0)
                    {
                        throw new EventNotFoundException("Event Not Found");
                    }
                }
                return 0;
            }catch(SqlException e) { Console.WriteLine(e.Message); return 0; }
            finally
            {
                cmd.Parameters.Clear();
            }
            





        }

        public decimal calculate_booking_cost(int num_tickets, decimal ticket_price)
        {
            return num_tickets * ticket_price;
        }

        public int cancel_booking(int booking_id, int event_id,int num_tickets)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "delete from booking where booking_id = @bookingId";
                cmd.Parameters.AddWithValue("bookingId", booking_id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int deleteStatus = (int)cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (deleteStatus > 0)
                {

                    cmd.CommandText = "update event set available_seats=available_seats+@numTickets where event_id = @eventId";
                    cmd.Parameters.AddWithValue("numTickets", num_tickets);
                    cmd.Parameters.AddWithValue("eventId", event_id);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int updatestatus = cmd.ExecuteNonQuery();
                    if (updatestatus > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new EventNotFoundException("No Such Event Present");
                    }

                }
                else{
                    throw new InvalidBookingIDException("Invalid Booking Id");
                }

                
            }
            catch (SqlException e){ Console.WriteLine(e.Message); return 0; }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        public Event create_event(string event_name, DateTime date, TimeSpan time, int total_seats, decimal ticket_price, EventType eventType, Venue venue)
        {
            try
            {
                cmd.CommandText = "insert into event(event_name,event_date,event_time,venue_id,total_seats,available_seats,ticket_price,event_type) values(@event_name,@date,@time,@venue_id,@total_seats,@total_seats,@ticket_price,@event_type);select SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("event_name", event_name);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("time", time);
                cmd.Parameters.AddWithValue("venue_id", venue.VenueId);
                cmd.Parameters.AddWithValue("total_seats", total_seats);
                cmd.Parameters.AddWithValue("available_seats", total_seats);
                cmd.Parameters.AddWithValue("ticket_price", ticket_price);
                cmd.Parameters.AddWithValue("event_type", eventType.ToString());

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int new_event_id = Convert.ToInt32(cmd.ExecuteScalar());
                Event event_obj = new Event(new_event_id, event_name, date, time, venue.VenueId, total_seats, ticket_price, eventType);
                sqlconnection.Close();
                if (new_event_id > 0)
                {
                    return event_obj;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); return null; }
            finally { cmd.Parameters.Clear(); }

        }

        public Event getAvailableNoOfTickets(int event_id)
        {
            try
            {
                cmd.CommandText = "Select * from Event where event_id = @event_id";
                cmd.Parameters.AddWithValue("event_id", event_id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Event event_obj = new Event();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        event_obj.EventId = Convert.ToInt32(reader["event_id"]);
                        event_obj.EventName = (string)reader["event_name"];
                        event_obj.EventDate = (DateTime)reader["event_date"];
                        event_obj.EventTime = (TimeSpan)reader["event_time"];
                        event_obj.VenueId = (int)reader["venue_id"];
                        event_obj.TotalSeats = (int)reader["total_seats"];
                        event_obj.AvailableSeats = (int)reader["available_seats"];
                        event_obj.TicketPrice = (decimal)reader["ticket_price"];
                        if (reader["event_type"] == "Movie")
                        {
                            event_obj.EventType = EventType.Movie;
                        }
                        else if (reader["event_type"] == "Concert")
                        {
                            event_obj.EventType = EventType.Concert;
                        }
                        else if (reader["event_type"] == "Sports")
                        {
                            event_obj.EventType = EventType.Sports;
                        }
                    }
                    sqlconnection.Close();
                    return event_obj;
                }
                else
                {
                    throw new EventNotFoundException("No Such Event Id present");
                }
            }catch(SqlException e) { Console.WriteLine(e.Message);return null; }
            finally { cmd.Parameters.Clear(); }
        }

        public List<Event> getEventDetails()
        {
            try
            {
                List<Event> all_events = new List<Event>();
                cmd.CommandText = "Select * from Event";
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event event_obj = new Event();

                    event_obj.EventId = Convert.ToInt32(reader["event_id"]);
                    event_obj.EventName = (string)reader["event_name"];
                    event_obj.EventDate = (DateTime)reader["event_date"];
                    event_obj.EventTime = (TimeSpan)reader["event_time"];
                    event_obj.VenueId = (int)reader["venue_id"];
                    event_obj.TotalSeats = (int)reader["total_seats"];
                    event_obj.AvailableSeats = (int)reader["available_seats"];
                    event_obj.TicketPrice = (decimal)reader["ticket_price"];
                    if (reader["event_type"] == "Movie")
                    {
                        event_obj.EventType = EventType.Movie;
                    }
                    else if (reader["event_type"] == "Concert")
                    {
                        event_obj.EventType = EventType.Concert;
                    }
                    else if (reader["event_type"] == "Sports")
                    {
                        event_obj.EventType = EventType.Sports;
                    }
                    all_events.Add(event_obj);


                }
                sqlconnection.Close();
                return all_events;
            }catch (Exception e) { Console.WriteLine(e.Message); return null; }
        }

        public Booking get_booking_details(int booking_id)
        {
            throw new NotImplementedException();
        }



        public  List<Venue> allVenues()
        {
            try
            {
                List<Venue> all_venues = new List<Venue>();
                cmd.CommandText = "Select * from Venue";
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venue venue_obj = new Venue();

                    venue_obj.VenueId = (int)reader["venue_id"];
                    venue_obj.VenueName = (string)reader["venue_name"];
                    venue_obj.Address = (string)reader["venue_address"];
                    all_venues.Add(venue_obj);
                }
                sqlconnection.Close();
                return all_venues;
            }
            catch (Exception e) { Console.WriteLine(e.Message);return null; }
        }

        public Customer login(string email)
        {
            try
            {
                cmd.CommandText = "select * from Customer where email=@email";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = sqlconnection;
                //we have to keep in the try and catch block
                sqlconnection.Open();
                //to read the data we have another class SqlDataReader
                SqlDataReader reader = cmd.ExecuteReader();
                Customer customerObj = new Customer();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //reader["id"] will  be a object
                        customerObj.CustomerId = (int)reader["customer_id"];
                        customerObj.CustomerName = (string)reader["customer_name"];
                        customerObj.Email = (string)reader["email"];
                        customerObj.password = (string)reader["password"];



                    }

                    sqlconnection.Close();

                    return customerObj;
                    
                    

                }
                
                return null;
            }catch (Exception e) { Console.WriteLine(e.Message);return null; }
        }

        public List<Booking> get_bookings_by_customer_id(Customer loggedInUser)
        {
            try
            {
                List<Booking> bookings = new List<Booking>();
                List<Event> all_events = getEventDetails();
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from booking where customer_id = @customerId";
                cmd.Parameters.AddWithValue("customerId", loggedInUser.CustomerId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read())
                    {
                        Booking bookingObj = new Booking();
                        bookingObj.BookingId = (int)reader["booking_id"];
                        bookingObj.CustomerId = (int)reader["customer_id"];
                        bookingObj.EventId = (int)reader["event_id"];
                        Event eventObj = all_events.Find(x => x.EventId == bookingObj.EventId);
                        bookingObj.event_obj = eventObj;
                        bookingObj.NumTickets = (int)reader["num_tickets"];
                        bookingObj.TotalCost = (decimal)reader["total_cost"];
                        bookingObj.BookingDate = (DateTime)reader["booking_date"];
                        bookings.Add(bookingObj);
                    }
                    
                    return bookings; }
                return null;
            }catch(Exception e) { Console.WriteLine(e.Message);return null; }
            finally { sqlconnection.Close(); }
        }
    }
}
