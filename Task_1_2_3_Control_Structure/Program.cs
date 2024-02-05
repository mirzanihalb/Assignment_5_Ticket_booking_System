namespace Task_1_2_3_Control_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1 . Task1");
                Console.WriteLine("2 . Task2");
                Console.WriteLine("3 . Task3");
                Console.WriteLine("0 . Exit");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 0: return;
                }
            }
        }
        public static void Task1()
        {
            Console.Write("Enter the Number of Availble Tickets : ");
            int availableTicket = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Number of Tickets You want to book : ");
            int noOfBookingTicket = Convert.ToInt32(Console.ReadLine());
            if (noOfBookingTicket <= availableTicket)
            {
                Console.WriteLine("Your tickets have been booked succefully");
                availableTicket -= noOfBookingTicket;
            }
            else
            {
                Console.WriteLine($"No of Available Tickets for the show are {availableTicket}");
                Console.WriteLine($"Sorry we cannot order of {noOfBookingTicket}");
            }

        }

        public static void Task2()
        {
            Console.WriteLine("Ticket Options");
            Console.WriteLine("1.Silver  Cost:25");
            Console.WriteLine("2.Gold  Cost:50");
            Console.WriteLine("3.Diamond  Cost:100");
            Console.Write("For Which Ticket Type You want to Book Tickets : ");
            int categoryType = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please Enter Number of Tickets You want to Book : ");
            int noOfTickets = Convert.ToInt32(Console.ReadLine());
            int totalcost;
            if (categoryType == 1)
            {
                totalcost = noOfTickets * 25;
                Console.WriteLine($"Total Cost to pay for {noOfTickets} Tickets is : {totalcost}");
            }
            else if (categoryType == 2)
            {
                totalcost = noOfTickets * 50;
                Console.WriteLine($"Total Cost to pay for {noOfTickets} Tickets is : {totalcost}");
            }
            else if (categoryType == 3)
            {
                totalcost = noOfTickets * 100;
                Console.WriteLine($"Total Cost to pay for {noOfTickets} Tickets is : {totalcost}");
            }
            else
            {

                Console.WriteLine("Please Choose a Correct Category");

            }


        }
        public static void Task3()
        {
            while (true)
            {
                Task2();
                Console.WriteLine("Do you want to Book Tickets Again [Y/N] : ");
                string flag = Console.ReadLine();
                if (flag == "N" || flag == "n")
                {
                    Console.WriteLine("Thank You for your time!");
                    break;
                }

            }
        }
    }
}
