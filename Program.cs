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
            //___check by using loop through all flights up to the current number of valiable flight__
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is avilable
                if (SeatReserved_A[i] < SeatsNum_A[i])
                {
                    // ___Display all information of not avilable flight____
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
        //____6. Find Flight By Code_____

        public static bool FindFlightByCode(string code)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (code == FlightCode_A[i])
                { // _____Find the information___ 
                    Console.WriteLine($"Flight Code: {FlightCode_A[i]}");
                    Console.WriteLine($"From City: {FromCity_A[i]}");
                    Console.WriteLine($"To City: {ToCity_A[i]}");
                    Console.WriteLine($"Departure Time: {DepartureTime_A[i]}");
                    Console.WriteLine($"Duration : {Duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats"); 
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats"); 
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats"); 
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

            // use while to repate  show the menu in every one of the feature in the menu____
            while (true)
            {
                int option = ShowMainMenu();

                // Declare variables to store singe value of user input 
                string Flight_Code = null;
                string From_City = null;
                string To_City = null;
                DateTime Departure_Time;
                int Duration_1 = 0;
                int Seats_Num = 0;
                char ChoiceChar = 'y' ;
                bool AddMore = true;
                int traies = 0;

                switch (option)
                {
                    case 1:
                        while (AddMore && FlightCounter < Max_Flight)
                        {

                            Console.WriteLine($"Enter Counter flight {FlightCounter + 1} Information");

                            // Flight Code Input..
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                // ask user to input Flight Code data and store this data in flight_Code variable 
                                Console.WriteLine("Enter Flight Code :");
                                flight_Code = Console.ReadLine();

                                // flightCode input validation 
                                // check if the input flight code is not null and display the message to the user to enter the valid valis code input
                                if (string.IsNullOrWhiteSpace(flight_Code))
                                {
                                    Console.WriteLine("Flight code cannot be empty.");
                                    isValid = false;
                                    traies++;
                                }
                                else
                                {
                                    isValid = true;
                                    traies = 0;
                                }

                                // (Optional) Check if flight code already exists
                                for (int i = 0; i < FlightCounter; i++)
                                {
                                    if (flightCode_A[i] == flight_Code)
                                    {
                                        Console.WriteLine("A flight with this code already exists.");
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
                                    Console.WriteLine("Failed to provide a valid flight code after 3 tries.");
                                    return;
                                }

                            } while (!isValid && traies <= 3); // if the input is not vlidate repet ask the user 



                            // From City Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                //Ask user to input the from city data and temprorly store this data in from_city data
                                Console.WriteLine("Enter From City :");
                                from_City = Console.ReadLine();


                                // fromCity input validation 
                                if (string.IsNullOrWhiteSpace(from_City))
                                {
                                    Console.WriteLine("From city names cannot be empty.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }
                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // To City Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter To City :");
                                to_City = Console.ReadLine();

                                // fromCity input validation 
                                if (string.IsNullOrWhiteSpace(to_City))
                                {
                                    Console.WriteLine("Trom city names cannot be empty.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }

                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // Departure time input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter the departure time (e.g., 2025-04-12 14:30):");
                                string input = Console.ReadLine();

                                if (DateTime.TryParse(input, out departure_Time))
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid format! Please enter a valid date and time.");
                                    isValid = false;
                                }

                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // Duration Input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter duration:");
                                string DurationInput = Console.ReadLine();

                                // Duration input validation 
                                if (int.TryParse(DurationInput, out duration_1))
                                {
                                    if (duration_1 <= 0)
                                    {
                                        Console.WriteLine("Duration must be greater than zero.");
                                        isValid = false;
                                    }
                                    else
                                    {
                                        isValid = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                    isValid = false;
                                }
                            } while (!isValid); // if the input is not vlidate repet ask the user 


                            // Number of seats input
                            // use do while loop to excute the quations of input data for first time befor check the input data if it is valide or no .
                            do
                            {
                                Console.WriteLine("Enter the Number of seats:");
                                Seats_Num = int.Parse(Console.ReadLine());
                                //seatsNum input validation
                                if (Seats_Num <= 0)
                                {
                                    Console.WriteLine("Number of seats must be greater than zero.");
                                    isValid = false;
                                }
                                else
                                {
                                    isValid = true;
                                }

                            } while (!isValid); // if the input is not vlidate repet ask the user 

                            // check is all inputs data is valid or not 
                            if (isValid)
                            {
                                // store all inputs data in the array 
                                AddFlight(flightCode: flight_Code, fromCity: from_City, toCity: to_City, departureTime: departure_Time, duration: duration_1, SeatsNum: Seats_Num);
                                Console.WriteLine("Flight added successfully!");
                                FlightCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Flight added faild!");
                                break;

                            }
                            //ask user if want to add more flight information 
                            Console.WriteLine("Do you want to add more flight information?! (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            // use if statement to deal with ChoiceChar input if y or n
                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                // use if instead to check also if FlightCounter is equal or not the Max_Flight
                                if (FlightCounter == Max_Flight)
                                {
                                    Console.WriteLine("Can Not Add More Flight Information");
                                    AddMore = false;
                                }
                                else
                                {
                                    AddMore = true; // display AddMore as true if FlightCounter does not equal Max_Flight and it is aable to add more flight information.
                                }
                            }
                            else
                            {
                                AddMore = false; // display AddMore as false is user do not add more flight information 
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
