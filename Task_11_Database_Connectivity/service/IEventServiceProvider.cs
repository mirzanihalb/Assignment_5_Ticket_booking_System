using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_9_11_Database_Connectivity.Model;


namespace Task_9_11_Database_Connectivity.service
{
    internal interface IEventServiceProvider
    {
        
       
        public void create_event();

        public void getEventDetails();

        public void getAvailableNoOfTickets();
    }
}
