using System.Numerics;

namespace Console_app
{
    internal class Trips
    {
        static List<Dictionary<string, string>> tripsList = new List<Dictionary<string,string>>();

        public static void TripsMenu()
        {

            Console.WriteLine("\nOdabrali ste opciju Putovanja!");

            while (true)
            {
                Console.WriteLine(
                    "\n1 - Unos novog putovanja\n" +
                    "2 - Brisanje putovanja\n" +
                    "3 - Uređivanje postojećeg putovanja\n" +
                    "4 - Pregled svih putovanja\n" +
                    "5 - Izvještaji i analize\n" +
                    "0 - Povratak na glavni izbornik\n"
                    );

                if (int.TryParse(Console.ReadLine(), out int choice))
                {

                    switch (choice)
                    {
                        case 1:
                            AddTrip();
                            break;
                        case 2:
                            //DeleteUser();
                            break;
                        case 3:
                            //EditUsers();
                            break;
                        case 4:
                            //ViewUsers();
                            break;
                        case 5:
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Neispravan odabir!");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Neispravan unos!");
                }
            }
        }

        public static void AddTrip()
        {
            DateTime tripDate;
            double tripKm, tripFuel, tripPricePerLiter, totalTripPrice;
            int tripIdInt = 0;
            string tripIdString, tripDateString, tripKmString, tripFuelString, tripPriceLiterString;
            Dictionary<string, string> tripDict = new Dictionary<string, string>();

            Console.WriteLine("\nUNOS NOVOG PUTOVANJA");

            tripIdString = tripIdInt.ToString();

            Console.Write("Unesi datum putovanja (npr. 2025-05-12): ");
            tripDateString = Console.ReadLine();

            while (!DateTime.TryParse(tripDateString, out tripDate))
            {
                Console.Write("Neispravan datum, pokušaj ponovno (npr. 2025-05-12): ");
                tripDateString = Console.ReadLine();
    
            }
            while (tripDate.Year > 2025 && tripDate.Month > 12 && tripDate.Day > 31)
            {
                Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                tripDateString = Console.ReadLine();
            }

                Console.Write("Unesi prijeđene kilometre: ");
            tripKmString = Console.ReadLine();
            while (!double.TryParse(tripKmString, out tripKm) || tripKm <= 0)
            {
                Console.Write("Neispravan unos! Unesi broj kilometara (> 0): ");
                tripKmString = Console.ReadLine();
            }

            Console.Write("Unesi potrošeno gorivo (u litrima): ");
            tripFuelString = Console.ReadLine();
            while (!double.TryParse(tripFuelString, out tripFuel) || tripFuel <= 0)
            {
                Console.Write("Neispravan unos! Unesi količinu goriva (> 0): ");
                tripFuelString = Console.ReadLine();
            }

            Console.Write("Unesi cijenu goriva po litri: ");
            tripPriceLiterString = Console.ReadLine();
            while (!double.TryParse(tripPriceLiterString, out tripPricePerLiter) || tripPricePerLiter <= 0)
            {
                Console.Write("Neispravan unos! Unesi cijenu po litri (> 0): ");
                tripPriceLiterString = Console.ReadLine();
            }

            totalTripPrice = tripFuel * tripPricePerLiter;

            tripDict.Add("tripId", tripIdString);
            tripDict.Add("tripDate", tripDateString);
            tripDict.Add("tripKm", tripKmString);
            tripDict.Add("tripFuel", tripFuelString);
            tripDict.Add("tripPricePerLiter", tripPriceLiterString);
            tripDict.Add("totalTripPrice", totalTripPrice.ToString());

            tripsList.Add(tripDict);

            Console.WriteLine("\nPutovanje je uspješno dodano!");
            tripIdInt++;

            
        }


    }

}