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
        //___4. Add Flight___
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int SeatsNum)
        {
            // ___If all validations pass, save the data___
            FlightCode[FlightCounter] = flightCode;
            FromCity[FlightCounter] = fromCity;
            ToCity[FlightCounter] = toCity;
            DepartureTime[FlightCounter] = departureTime;
            Duration[FlightCounter] = duration;
            SeatsNumber[FlightCounter] = SeatsNum;

        }
        //___5. Display All Flights______
        public static void DisplayAllFlights()
        {
            Console.WriteLine("All Available Flight Information ");
            //___check by using loop through all flights up to the current number of valiable flight__
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is avilable
                if (SeatReserved[i] < SeatsNumber[i])
                {
                    // ___Display all information of not avilable flight____
                    Console.WriteLine($"Avilable Flight {FlightCounter}: ");
                    Console.WriteLine($"Flight Code: {FlightCode[i]}");
                    Console.WriteLine($"From City: {FromCity[i]}");
                    Console.WriteLine($"To City: {ToCity[i]}");
                    Console.WriteLine($"Departure Time: {DepartureTime[i]}");
                    Console.WriteLine($"Duration : {Duration[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNumber[i]} Seats"); // ___Number of Avilabe seats on specific flight__
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved[i]} Seats"); // ____display how many number of seat are reserve in th flight__
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNumber[i] - SeatReserved[i]} Seats"); // __display how many of seats are remaine__
                    Console.WriteLine("-------------------------------------------------------------------------");
                }

            }
       
        }
        //____6. Find Flight By Code_____

        public static bool FindFlightByCode(string code)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (code == FlightCode[i])
                { // _____Find the information___ 
                    Console.WriteLine($"Flight Code: {FlightCode[i]}");
                    Console.WriteLine($"From City: {FromCity[i]}");
                    Console.WriteLine($"To City: {ToCity[i]}");
                    Console.WriteLine($"Departure Time: {DepartureTime[i]}");
                    Console.WriteLine($"Duration : {Duration[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNumber[i]} Seats"); 
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved[i]} Seats"); 
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNumber[i] - SeatReserved[i]} Seats"); 
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }

            return true;

        }

        // 18.  ____Start System____

        public static void StartSystem()
        {
            // ___calling Display Welcome Message function___ 
            DisplayWelcomeMessage();

            // ___wait for the user to press any button to continue._____
            Console.ReadLine();

            // ___use while to repate  show the menu in every one of the feature in the menu____
            while (true)
            {
                int option = ShowMainMenu();

                // ___Declare variables to store singe value of user input___ 
                string Flight_Code = null;
                string From_City = null;
                string To_City = null;
                DateTime Departure_Time;
                int Duration = 0;
                int Seats_Number = 0;
                char ChoiceChar = 'y' ;
                bool AddMore = true;
                int traies = 0;

                switch (option)
                { 
                    case 1:
                        while (AddMore && FlightCounter < Max_Flight)
                        {

                            Console.WriteLine($"Enter flight Counter {FlightCounter + 1} Information");

                           // __Use a do while loop to execute the input data equations for the first time before checking if the input data is valid or not__


                            do
                            {   // _______________________Flight Code_________________
                                // Ask the user to enter flight code data and store this data in the Flight_Code variable__
                                Console.WriteLine("Enter Flight Code :");
                                Flight_Code = Console.ReadLine();

                                // __Flight Code input validation___ 
                               
                                if (string.IsNullOrWhiteSpace(Flight_Code))
                                {
                                    Console.WriteLine("Flight code cannot be empty !");
                                    isValid = false;
                                    traies++;
                                }
                                else
                                {
                                    isValid = true;
                                    traies = 0;
                                }

                                // __Check if flight code already exists__
                                for (int i = 0; i < FlightCounter; i++)
                                {
                                    if (FlightCode[i] == Flight_Code)
                                    {
                                        Console.WriteLine("An error occurred..! a flight with this code already exists.");
                                        isValid = false;
                                        traies++;
                                    }
                                    else
                                    {
                                        isValid = true;
                                        traies = 0;
                                    }

                                }

                                if (traies > 3)
                                {
                                    Console.WriteLine("Failed to provide flight code..! You only have 3 attempts.");
                                    return;
                                }

                            } while (!isValid && traies <= 3); // __repeted ask the user if the input is not vlidate__  



                            // ______________________________From City____________________ 
                            // __Use a do while loop to execute the input data equations for the first time before checking if the input data is valid or not____ .
                            do
                            {
                                //__Ask the user to enter data from the city and temporarily store this data in the from_city data__
                                Console.WriteLine("Enter From City :");
                                From_City = Console.ReadLine();


                                // __from City input validation___ 
                                if (string.IsNullOrWhiteSpace(From_City))
                                {
                                    Console.WriteLine("error!!From city names cannot be empty..");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }
                            } while (!isValid); //__If the input is not verified, ask the user to repeat___ 

                            // _________________________________To City____________
                            // ___use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no__ 
                            do
                            {
                                Console.WriteLine("Enter To City :");
                                To_City = Console.ReadLine();

                                // fromCity input validation 
                                if (string.IsNullOrWhiteSpace(To_City))
                                {
                                    Console.WriteLine("error!!To city names cannot be empty...");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }

                            } while (!isValid); // ____If the input is not verified, ask the user to repeat__

                            // _____________________________Departure time_________
                            // ____Use a do while loop to execute the input data equations for the first time before checking if the input data is valid or not_____
                            do
                            {
                                Console.WriteLine("Enter the departure time (e.g., 2025-04-13 03:30):");
                                string input = Console.ReadLine();

                                if (DateTime.TryParse(input, out Departure_Time))
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid format! Please enter a correct date and time.");
                                    isValid = false;
                                }

                            } while (!isValid); // ____If the input is not verified, ask the user to repeat__

                            // _______________________Duration_________
                            // ____Use a do while loop to execute the input data equations for the first time before checking if the input data is valid or not_____
                            do
                            {
                                Console.WriteLine("Enter the  duration:");
                                string DurationInput = Console.ReadLine();

                                // Duration input validation 
                                if (int.TryParse(DurationInput, out Duration))
                                {
                                    if (Duration <= 0)
                                    {
                                        Console.WriteLine("Duration must be greater than zero..!");
                                        isValid = false;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid entry. Please enter a valid number..");
                                    isValid = false;
                                }
                            } while (!isValid); //____If the input is not verified, ask the user to repeat__


                            // _____________________Number of seats________ 
                            // __use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no___ .
                            do
                            {
                                Console.WriteLine("Enter the Number of seats:");
                                Seats_Number = int.Parse(Console.ReadLine());
                                //seatsNum input validation
                                if (Seats_Number <= 0)
                                {
                                    Console.WriteLine("Number of seats must be greater than zero.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }

                            } while (!isValid); //____If the input is not verified, ask the user to repeat

                            // ______Check whether all input data is correct or not____ 
                            if (isValid)
                            {
                                // store all inputs data in the array 
                                AddFlight(flightCode: Flight_Code, fromCity: From_City, toCity: To_City, departureTime: Departure_Time, duration: Duration, SeatsNum: Seats_Number);
                                Console.WriteLine("Flight added successfully!");
                                FlightCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Flight added faild!");
                                break;

                            }
                            //___ask user if want to add more flight information or no__ 
                            Console.WriteLine("Do you want to add more flight information? (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            // __Use an if statement to handle a ChoiceChar input if it is y or n____.
                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                // ___Use if instead to also check if Flight Counter equals Max_Flight or not___.
                                if (FlightCounter == Max_Flight)
                                {
                                    Console.WriteLine("Error..!Can Not Add More Flight Information");
                                    AddMore = false;
                                }
                                else
                                {
                                    AddMore = true; // ___Display "Add More" as "True" if the flight counter is not equal to Max_Flight and is able to add more flight information___.
                                }
                            }
                            else
                            {
                                AddMore = false; // __Show "Add More" as "false" if the user has not added more trip information__.
                            }
                            Console.ReadLine();
                        }

                        break;

                    case 2:
                        DisplayAllFlights();
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Enter the code of Flight : ");
                        string code = Console.ReadLine();
                        FindFlightByCode(code);
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case 4:

                        break;
                    case 5:

                        break;

                    case 0:
                        //calling ExitApplication() function
                        ExitApplication();
                        //using return to stop the whole method thus, stop whole program 
                        return;

                    default:
                        // // Display an message for invalid user input 
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }

        }

        //                    ======================= main method ==============================

        // 1. main method 
        static void Main(string[] args)
        {
            StartSystem();
        }



    }
}
