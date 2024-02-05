﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6_Abstraction.dao;

namespace Task_6_Abstraction.Model
{
    internal class Sport:Event
    {
        string SportsName { get; set; }
        string TeamsName { get; set; }

        public Sport()
        {

        }
        public Sport(string event_name, DateTime event_date, TimeSpan event_time, string venue_name, int total_seats, decimal ticket_price, string sports_name, string teams_name) : base(event_name, event_date, event_time, venue_name, total_seats, ticket_price, EventType.Sport)
        {
            SportsName = sports_name;
            TeamsName = teams_name;
        }
        public override decimal calculate_total_revenue(int numOfTickets)
        {
            return numOfTickets * TicketPrice;
        }

        public override decimal calculate_booking_cost(int numOfTickets)
        {
            return numOfTickets * TicketPrice;
        }

        public override int getBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }
        public override int book_ticktes(int numOfTickets)
        {
            if (numOfTickets <= AvailableSeats)
            {
                AvailableSeats -= numOfTickets;
                Console.WriteLine($"{numOfTickets} are booked successfully for the Event: {EventName} at Date: {EventDate} and Time: {EventTime}");
                return 1;
            }
            else
            {
                Console.WriteLine($"Cannot book tickets for the Event:{EventName} , The No of Available Tickets are {AvailableSeats}");
                return 0;
            }
        }
        public override void cancel_booking(int num_tickets)
        {
            AvailableSeats += num_tickets;
            Console.WriteLine($"Cancellation of {num_tickets} Tickets is Successfull for the Event: {EventName} at Date: {EventDate} and Time: {EventTime}");
        }

        public override string display_event_details()
        {


            return $"Event Name: {EventName}\nEvent Date: {EventDate}\nEvent Time: {EventTime}\nVenue: {VenueName}\nTotal Seats: {TotalSeats}\nAvailable Seats: {AvailableSeats}\nTicket Price: {TicketPrice}\nEvent Type: {EventType}\n";

        }
        public string display_sport_details()
        {
            string base_event_details = display_event_details();
            string sport_event_details = $"\nSportName : {SportsName} \nTeams Name : {TeamsName}";
            return base_event_details + sport_event_details;
        }
    }
}
