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


    }
}
