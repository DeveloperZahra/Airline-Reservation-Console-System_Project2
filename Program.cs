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
       

    }
}
