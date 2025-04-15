using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Airline_Reservation_Console_System_Project2
{
    internal class Program
    {  //___Create the array and add the required variables__
        static int Max_Flight = 3;
        static int FlightCounter = 0;
        static string[] FlightCode = new string[Max_Flight];
        static string[] FromCity = new string[Max_Flight];
        static string[] ToCity = new string[Max_Flight];
        static DateTime[] DepartureTime= new DateTime[Max_Flight];
        static int[] Duration = new int[Max_Flight];
        static int[] SeatsNumber = new int[Max_Flight];
        static int[] SeatReserved = new int[Max_Flight];
        static int[] price = new int[Max_Flight];
        // ___variables and arraies Passenger Booking Functions section_____
        static int BookingCounter = 0;
        static string[] PassengerName = new string[100];
        static string[] BookingFlightCode = new string[100];
        static string[] GenerateBookingID = new string[100];
        static int tickets = 0;

        // ____flag to validate the user input___ 
        static bool isValid = false;
        //____check if exist___
        static bool ISFound = true;

        // _______1. welcome message_______

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
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
                    isValid = false; // ___Keep isValid false to repeat the loop___
                }
            } while (!isValid); // __Continue looping until valid input is received__

            return option;
        }
        //___3. Exit application method____
        public static void ExitApplication()

        {
            Console.WriteLine("Thankyou.. Have a Nice Day!");
        }
    }
}
