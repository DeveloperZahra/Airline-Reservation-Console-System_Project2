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

        
    }
}
