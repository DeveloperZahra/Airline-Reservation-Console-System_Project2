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
            Console.WriteLine("All Not Available Flight Information ");
            bool isFound = false; //___reset and use local variable___
                                  // ___Loop through all flights up to the current number of not valiable flight___
            for (int i = 0; i < FlightCounter; i++)
            {
                //___check if flight is not available____
                if (SeatReserved[i] >= SeatsNumber[i])
                {
                    isFound = true;
                    // _____display the information of not available flight______
                    Console.WriteLine($"Unavailable Flight {i + 1}: ");
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

            if (!isFound)
            {
                Console.WriteLine("No flight is fully booked..!");
            }


        }
        //____6. Find Flight By Code_____
        public static bool FindFlightByCode(string code)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (code == FlightCode[i])
                {
                    Console.WriteLine($"Flight Code: {FlightCode[i]}");
                    Console.WriteLine($"From City: {FromCity[i]}");
                    Console.WriteLine($"To City: {ToCity[i]}");
                    Console.WriteLine($"Departure Time: {DepartureTime[i]}");
                    Console.WriteLine($"Duration : {Duration[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNumber[i]} Seats"); // __Number of Avilabe seats on specific flight___
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved[i]} Seats"); // __display how many number of seat are reserve in th flight___
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNumber[i] - SeatReserved[i]} Seats"); // __display how many of seats are remaine___
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }

            return true;

        }
        //7.____Update Flight Departure_____
        public static DateTime UpdateFlightDeparture(ref DateTime departure)
        {
            int index = 0;
            Console.WriteLine("Enter the flight code: ");
            string flightCode = Console.ReadLine();
            for (int i = 0; i < FlightCounter; i++)
            {
                if (FlightCode[i] == flightCode)
                {
                    index = i;
                }

            }

            return DepartureTime[index] = departure;
        }

        // 8.____Cancel Flight Booking (out string passengerName)_____ 
        public static void CancelFlightBooking(out string passengerName)
        {
            int index = 0;
            passengerName = ""; //_____Initial assignment_____
            for (int i = 0; i < BookingCounter; i++)
            {
                if (PassengerName[i] == passengerName)
                {
                    index = i;
                }
            }
            bool res = ConfirmAction("Cancel Flight Booking");
            if (res)
            {

                for (int i = index; i < BookingCounter; i++)
                {

                    PassengerName[i] = PassengerName[i + 1];
                    GenerateBookingID[i] = GenerateBookingID[i + 1];
                }
                BookingCounter--;
                Console.WriteLine("Cancel successfully");
            }
            else
            {
                Console.WriteLine("Cancel unsuccessful!");
            }

        }
        //9.___Book Flight +  Generate Booking_ID____
        public static void BookFlight(string passengerName, string flightCode = "Default003")
        {
            int index = 0;
            string bookingID = GenerateBooking_ID(passengerName);
            PassengerName[BookingCounter] = passengerName;
            BookingFlightCode[BookingCounter] = flightCode;
            GenerateBookingID[BookingCounter] = bookingID;
            Console.WriteLine("How many tickets would you like to book?");
            int tickets = int.Parse(Console.ReadLine());

            for (int i = 0; i < FlightCounter; i++)
            {
                if (FlightCode[i] == flightCode)
                {
                    SeatReserved[i] = SeatReserved[i] + tickets; //___Resserved seat for every tickets____
                    break;
                }
            }


        }
        // 10._____Validate Flight Code_____
        public static bool ValidateFlightCode(string flightCode)
        {
            bool InExist = false;
            for (int i = 0; i < FlightCounter; i++)
            {
                if (FlightCode[i] == flightCode)
                {
                    Console.WriteLine("The flight code exist..!");
                    InExist = true;
                }
                else
                {
                    Console.WriteLine("Flight code not exist..!");
                    InExist = false;
                }
            }

            return InExist;
        }
        // 11.____________Generate Booking_ID_____
        public static string GenerateBooking_ID(string passengerName)
        {
            //______generate a random number_______
            Random random = new Random();
            string randomNumber = random.Next(1, 100).ToString();
            string BookingID = passengerName + randomNumber;
            return BookingID;
        }
        // 12._______Display Flight Details_______
        public static void DisplayFlightDetails(string code)
        {
            int PassengerNumber = 0;
            for (int i = 0; i < FlightCounter; i++)
            {
                if (FlightCode[i] == code)
                {
                    for (int j = 0; j < BookingCounter; j++)
                    {
                        if (BookingFlightCode[j] == code)
                        {
                            PassengerNumber++;
                        }
                    }

                    Console.WriteLine($"Flight Code: {FlightCode[i]}");
                    Console.WriteLine($"From City: {FromCity[i]}");
                    Console.WriteLine($"To City: {ToCity[i]}");
                    Console.WriteLine($"Duration: {Duration[i]}");
                    Console.WriteLine($"Departure Time: {DepartureTime[i]}");
                    Console.WriteLine($"Number of Passenger: {PassengerNumber} ");


                }
                else
                {
                    Console.WriteLine("Can not found this code");
                }
                Console.WriteLine("Passenger name with booking code: ");
                for (int k = 0; k < BookingCounter; k++)
                {
                    if (BookingFlightCode[k] == code)
                    {
                        Console.WriteLine($"Pasender Name: {PassengerName[k]}");
                        Console.WriteLine($"Pasender Code: {BookingFlightCode[k]}");

                    }
                }

            }

        }

        // 13._____Search Bookings By Destination____
        public static void SearchBookingsByDestination(string toCity)
        {
            int ToCityIndex = 0;
            for (int i = 0; i < FlightCounter; i++)
            {
                if (ToCity[i] == toCity)
                {
                    ToCityIndex = i;
                }
            }

            for (int i = 0; i < BookingCounter; i++)
            {
                if (FlightCode[ToCityIndex] == BookingFlightCode[i])
                {
                    Console.WriteLine(PassengerName[i]);
                    Console.WriteLine(GenerateBookingID[i]);
                    Console.WriteLine("----------------------------------------------");
                }

            }


        }
        //14.______Add Function (Overloaded)________
        //________to print int____
        public static int CalculateFare(int basePrice, int numTickets)
        {
            int TotalFarePrice = basePrice * numTickets;
            return TotalFarePrice;
        }
        //_____________to print double & int______
        public static double CalculateFare(double basePrice, int numTickets)
        {
            double TotalFarePrice = basePrice * numTickets;
            return TotalFarePrice;
        }
        //__________to print string_____
        public static double CalculateFare(int basePrice, int numTickets, int discount)
        {

            double discountAmount = (basePrice / 100) * discount;
            double TotalFarePrice = (basePrice * numTickets) - discount;
            return TotalFarePrice;
        }
        // 17.____Confirm Action______ 
        public static bool ConfirmAction(string action)
        {
            while (true)
            {
                Console.WriteLine($"{action} confirm (y/n):");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    char response = char.ToLower(input[0]);

                    if (response == 'y') return true;
                    if (response == 'n') return false;
                }

                Console.WriteLine("An error occurred.. Please enter 'y' or 'n'!");
            }
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
                int Fly_Price = 0;
                DateTime Departure_Time;
                int Duration = 0;
                int Seats_Number = 0;
                char ChoiceChar = 'y';
                bool AddMore = true;
                int traies = 0;

                bool BookingMore = true;

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
                    //______________________Display all Flight________
                    case 2:
                        DisplayAllFlights();
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    //___________________________Find Flight_______
                    case 3:

                        Console.WriteLine("Enter the code of Flight : ");
                        string code = Console.ReadLine();
                        FindFlightByCode(code);
                        Console.WriteLine("\nplease Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    //________Update Flight Departure________________
                    case 4:
                        Console.WriteLine($" Update Flight Departure of Flight: ");
                        DateTime departure = DateTime.Parse(Console.ReadLine());
                        UpdateFlightDeparture(ref departure);
                        Console.WriteLine("\nplease Press any key to return to the menu...");
                        Console.ReadKey();

                        break;
                    // CancelFlightBooking
                    case 5:
                        Console.WriteLine("Enter passenger Name: ");
                        string passengerName_Input0 = Console.ReadLine();
                        CancelFlightBooking(out passengerName_Input0);
                        Console.ReadLine();
                        break;
                    // ___Book Flight & GenerateBookingID____
                    case 6:
                        while (BookingMore)
                        {
                            int FlightIndex = 0;
                            Console.WriteLine("Enter passenger Name :");
                            string passengerName_Input = Console.ReadLine();

                            Console.WriteLine("Enter Flight Code: ");
                            string flightCode_Input = Console.ReadLine();
                            for (int i = 0; i < FlightCounter; i++)
                            {
                                if (FlightCode[i] == flightCode_Input)
                                {
                                    FlightIndex = i;
                                    break;
                                }
                            }

                            if (FlightCode[FlightIndex] == flightCode_Input)
                            {
                                if (BookingCounter < SeatsNumber[FlightIndex])
                                {
                                    BookFlight(passengerName: passengerName_Input, flightCode: flightCode_Input);
                                    Console.WriteLine("Flight booking successfully!");
                                    BookingCounter++;

                                }
                                else
                                {
                                    Console.WriteLine("Error..!No available seats on this flight.");
                                    BookingMore = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Flight code can not found it!");
                                BookingMore = false;
                            }
                            //____ask user if want to Booking more______  
                            Console.WriteLine("Do you want to bookimg more flight informatio؟ (y/n)");
                            ChoiceChar = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            if (ChoiceChar == 'Y' || ChoiceChar == 'y')
                            {
                                // __Check if any flights still have available seats or not___
                                bool hasAvailableSeats = false;
                                for (int i = 0; i < FlightCounter; i++)
                                {
                                    if (BookingCounter < SeatsNumber[i])
                                    {
                                        hasAvailableSeats = true;
                                        break;
                                    }
                                }

                                if (!hasAvailableSeats)
                                {
                                    Console.WriteLine("No more flights can be booked, they are all fully booked..");
                                    BookingMore = false;
                                }
                            }
                            else
                            {
                                BookingMore = false;
                            }
                            Console.ReadLine();
                        }

                        break;
                    // ___Validate Flight Code___
                    case 7:
                        Console.WriteLine("Enter the Flight code:");
                        string flightCodeInput = Console.ReadLine();
                        ValidateFlightCode(flightCodeInput);
                        Console.ReadKey();
                        break;
                    // ____Display Flight Details___
                    case 8:
                        Console.WriteLine("Enter the the Flight code: ");
                        string flightCode = Console.ReadLine();
                        DisplayFlightDetails(flightCode);
                        Console.WriteLine("\nplease Press any key to return to the menu...");
                        Console.ReadKey();


                        break;
                    // ___Search Bookings By Destination____
                    case 9:
                        Console.WriteLine("Enter the To City name:");
                        string ToCityInput = Console.ReadLine();
                        SearchBookingsByDestination(ToCityInput);
                        Console.WriteLine("\nplease Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    // ___Function Overloading____
                    case 10:
                        Console.Write("Enter Base Price: ");
                        string baseInput = Console.ReadLine();

                        Console.Write("Enter Number Of Tickets: ");
                        int numTickets = int.Parse(Console.ReadLine());

                        Console.Write("Do you want to add a discount? (yes/no): ");
                        string addDiscount = Console.ReadLine().ToLower();

                        if (addDiscount == "yes")
                        {
                            Console.Write("Enter discount percentage: ");
                            int discount = int.Parse(Console.ReadLine());


                            int basePriceInt = int.Parse(baseInput);
                            double total = CalculateFare(basePriceInt, numTickets, discount);
                            Console.WriteLine($"Total Fare with discount: {total}");
                            Console.ReadLine();
                        }
                        else
                        {
                            // ___Try parsing as double first to check if base price is decimal___
                            if (baseInput.Contains("."))
                            {
                                double basePriceDouble = double.Parse(baseInput);
                                double total = CalculateFare(basePriceDouble, numTickets);
                                Console.WriteLine($"Total Fare: {total}");
                                Console.ReadLine();

                            }
                            else
                            {
                                int basePriceInt = int.Parse(baseInput);
                                int total = CalculateFare(basePriceInt, numTickets);
                                Console.WriteLine($"Total Fare: {total}");
                                Console.ReadLine();

                            }
                        }
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



        // 1. ___main method___ 
        static void Main(string[] args)
        {
            StartSystem();
        }











    }
}
