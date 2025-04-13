using System.Threading.Channels;

namespace Airline_Reservation_Console_System_Project2
{
    internal class Program
    {  //___Create the array and add the required variables__
        static int Max_Flight = 3;
        static int FlightCounter = 0;
        static string[] FlightCode_A = new string[Max_Flight];
        static string[] FromCity_A = new string[Max_Flight];
        static string[] ToCity_A = new string[Max_Flight];
        static DateTime[] DepartureTime_A = new DateTime[Max_Flight];
        static int[] Duration_A = new int[Max_Flight];
        static int[] SeatsNum_A = new int[Max_Flight];
        static int[] SeatReserved_A = new int[Max_Flight];

        // ____flag to validate the user input___ 
        static bool isValid = false;


        //______Add Function (Overloaded)________
        //________to print int_____
        public static void CalculateFare(int input)
        {
            Console.WriteLine("the result of this operation is: " + input);
        }
        //_____________to print double______
        public static void CalculateFare(double input)
        {
            Console.WriteLine("the result of this operation is: " + input);
        }
        //__________to print string_____
        public static void CalculateFare(string input)
        {
            Console.WriteLine("the result of this operation is: " + input);
        }

        // _______1. welcome message_______

        public static void DisplayWelcomeMessage()
        {
            string[] message = { "Welcome to Airline Reservation System" };

            string input = Console.ReadLine();
        }
        //________2. show Main Menu__________ 
        public static int ShowMainMenu()
        {
            int option = 0;
            do
            {
                //___addition the  function types  of the project____
                Console.Clear();
                Console.WriteLine("Airline Reservation System");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. Display All Flights");
                Console.WriteLine("3. Find Flight By Code");
                Console.WriteLine("4. Update Flight Departure");
                Console.WriteLine("5. Cancel Flight Booking");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter the option: ");
                string input = Console.ReadLine();
                try
                {
                    option = int.Parse(input);// ____Make an attempt to analyze the entries._____
                    isValid = true; // ___If parsing is successful, set isValid to true__
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    isValid = false; // Keep isValid false to repeat the loop
                }
            } while (!isValid); // Continue looping until valid input is received

            return option;
        }
        //___3. Exit application method____
        public static void ExitApplication()

        {
            Console.WriteLine("Thankypu.. Have a nice day!");
        }
        //___4. Add Flight___
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int SeatsNum)
        {
            // If all validations pass, save the data
            FlightCode_A[FlightCounter] = flightCode;
            FromCity_A[FlightCounter] = fromCity;
            ToCity_A[FlightCounter] = toCity;
            DepartureTime_A[FlightCounter] = departureTime;
            Duration_A[FlightCounter] = duration;
            SeatsNum_A[FlightCounter] = SeatsNum;

        }
        //___5. Display All Flights______
        public static void DisplayAllFlights()
        {
            Console.WriteLine("All Available Flight Information ");
            //check by___using loop through all flights up to the current number of valiable flight__
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is avilable
                if (SeatReserved_A[i] < SeatsNum_A[i])
                {
                    // ___Display all information of avilable flight____
                    Console.WriteLine($"Avilable Flight {FlightCounter}: ");
                    Console.WriteLine($"Flight Code: {FlightCode_A[i]}");
                    Console.WriteLine($"From City: {FromCity_A[i]}");
                    Console.WriteLine($"To City: {ToCity_A[i]}");
                    Console.WriteLine($"Departure Time: {DepartureTime_A[i]}");
                    Console.WriteLine($"Duration : {Duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats"); // ___Number of Avilabe seats on specific flight__
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats"); // ____display how many number of seat are reserve in th flight__
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats"); // __display how many of seats are remaine__
                    Console.WriteLine("-------------------------------------------------------------------------");
                }

            }
        }
}
