using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Model;


namespace Task_9_11_Database_Connectivity.service
{
    internal interface IBookingSystemServiceProvider
    {
        public Customer login();
        

        public void book_tickets();

        public void cancel_booking();

        public void get_booking_details();
    }
}
