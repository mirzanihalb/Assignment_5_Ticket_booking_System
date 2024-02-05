

using Task_9_11_Database_Connectivity.app;
using Task_9_11_Database_Connectivity.Repository;
using Task_9_11_Database_Connectivity.service;

namespace Task_9_11_Database_Connectivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();
            ticketBookingSystem.run();
        }
    }
}
