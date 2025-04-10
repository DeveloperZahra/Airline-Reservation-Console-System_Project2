using System.Threading.Channels;

namespace Airline_Reservation_Console_System_Project2
{
    internal class Program
    {
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

        // _______welcome message_______

        public static void DisplayWelcomeMessage()
        {
            string[] message = { "1. Welcome to program menu" };

            string input = Console.ReadLine();
        }
        //________show Menu__________ 
        public static void ShowMainMenu(string input)
        {
            bool ProgramContinue = true; //addition the  function types  of the project...
            do
            {
                Console.WriteLine("  \n 2. Book Flight: \n 3. The Largest number is:  \n 4. View Flights: \n 5. Exit  ");
                int choice = int.Parse(Console.ReadLine());
                return;



                ExitApp(ref ProgramContinue);

            }
            while (ProgramContinue != false);
        }
    }
}
