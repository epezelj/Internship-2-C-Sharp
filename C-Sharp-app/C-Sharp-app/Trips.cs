using System.Numerics;

namespace Console_app
{
    internal class Trips
    {
        static List<Dictionary<string, string>> tripsList = new List<Dictionary<string, string>>();

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
                            DeleteTrip();
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
            double tripKm, tripFuel, tripFuelPriceLiter, totalTripPrice;
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
            while (!double.TryParse(tripPriceLiterString, out tripFuelPriceLiter) || tripFuelPriceLiter <= 0)
            {
                Console.Write("Neispravan unos! Unesi cijenu po litri (> 0): ");
                tripPriceLiterString = Console.ReadLine();
            }

            totalTripPrice = tripFuel * tripFuelPriceLiter;

            tripDict.Add("tripId", tripIdString);
            tripDict.Add("tripDate", tripDateString);
            tripDict.Add("tripKm", tripKmString);
            tripDict.Add("tripFuel", tripFuelString);
            tripDict.Add("tripFuelPriceLiter", tripPriceLiterString);
            tripDict.Add("totalTripPrice", totalTripPrice.ToString());

            tripsList.Add(tripDict);

            Console.WriteLine("\nPutovanje je uspješno dodano!");
            tripIdInt++;


        }

        public static void DeleteTrip()
        {
            string deleteTripId, tripId, sure, minTripPriceString, minTripPrice,
             maxTripPriceString, maxTripPrice;

            Console.WriteLine("\nUnesite id putovanja koje želite izbrisati:\n");
            deleteTripId = Console.ReadLine();

            for (int counter = 0; counter < tripsList.Count; counter++)
            {
                var trip = tripsList[counter];

                tripId = trip["tripId"];

                if (deleteTripId.Equals(tripId))
                {
                    Console.WriteLine(
                        "Pronađeno putovanje:\n" +
                        $"ID: {trip["tripId"]}, Datum: {trip["tripDate"]}, Km: {trip["tripKm"]}, " +
                        $"Gorivo: {trip["tripFuel"]}, Cijena/L: {trip["tripPricePerLiter"]}"
                    );

                    Console.WriteLine("\nŽelite li sigurno izbrisati ovo putovanje? (DA ili NE)");
                    sure = Console.ReadLine();

                    if (sure == "DA")
                    {
                        tripsList.RemoveAt(counter);
                        Console.WriteLine("Uspješno brisanje putovanja!");
                    }
                    else
                    {
                        Console.WriteLine("Brisanje prekinuto!\n");
                    }

                }

                else
                {
                    Console.WriteLine("Nijedno putovanje ne odgovara unesenom id-u.");
                }
            }


            for (int counter = 0; counter < tripsList.Count; counter++)
            {
                var trip = tripsList[counter];

                minTripPriceString = Console.ReadLine();
                double.TryParse(minTripPriceString, out double tripPrice);

                if (double.Parse(trip["totalTripPrice"]) > tripPrice)
                {
                    Console.WriteLine(
                        "Pronađeno putovanje:\n" +
                        $"{trip["tripId"]} - {trip["tripDate"]} - {trip["tripKm"]} km - {trip["tripFuel"]} L - {trip["tripPricePerLiter"]} EUR/L - {trip["totalTripPrice"]} EUR"
                    );

                    Console.WriteLine("\nŽelite li sigurno izbrisati ovo putovanje? (DA ili NE)");
                    sure = Console.ReadLine();

                    if (sure == "DA")
                    {
                        tripsList.RemoveAt(counter);
                        Console.WriteLine("Uspješno brisanje putovanja!");
                    }
                    else
                    {
                        Console.WriteLine("Brisanje prekinuto!\n");
                    }

                }
                else
                {
                    Console.WriteLine("Nijedno putovanje nije skuplje od unesenog iznosa");
                }

            }

            for (int counter = 0; counter < tripsList.Count; counter++)
            {
                var trip = tripsList[counter];

                maxTripPriceString = Console.ReadLine();
                double.TryParse(maxTripPriceString, out double tripPrice);

                if (double.Parse(trip["totalTripPrice"]) < tripPrice)
                {
                    Console.WriteLine(
                        "Pronađeno putovanje:\n" +
                        $"ID: {trip["tripId"]}, Datum: {trip["tripDate"]}, Km: {trip["tripKm"]} - {trip["tripFuel"]}, Cijena/L: {trip["tripFuelPriceLiter"]} EUR - {trip["totalTripPrice"]}"
                    );

                    Console.WriteLine("\nŽelite li sigurno izbrisati ovo putovanje? (DA ili NE)");
                    sure = Console.ReadLine();

                    if (sure == "DA")
                    {
                        tripsList.RemoveAt(counter);
                        Console.WriteLine("Uspješno brisanje putovanja!");
                    }
                    else
                    {
                        Console.WriteLine("Brisanje prekinuto!\n");
                    }

                }
                else
                {
                    Console.WriteLine("Nijedno putovanje nije jeftinije od unesenog iznosa");
                }

            }



        }

        public static void EditTrips()
        {
            bool matchById = false;
            string tripId, sure, editTripId;
            string newTripDateString, newTripKm, newTripFuelString, newTripPriceLitreString;
            double newTotalTripPrice, newTripPriceLiter, newTripFuel;

            DateTime tripDate, newTripDate;
            double tripKm, tripFuel, tripFuelPriceLiter;

            Console.WriteLine("Unesite id putovanja");
            editTripId = Console.ReadLine();

            for (int counter = 0; counter < tripsList.Count; counter++)
            {
                var trip = tripsList[counter];

                tripId = trip["tripId"];

                matchById = editTripId.Equals(tripId);

                if (matchById)
                {
                    Console.WriteLine($"Datum putovanja: {trip["tripDate"]}");
                    Console.WriteLine($"Kilometri puta: {trip["tripKm"]}");
                    Console.WriteLine($"Količina potrošenog goriva (L): {trip["tripFuel"]}");
                    Console.WriteLine($"Cijena goriva po litri: {trip["tripPricePerLiter"]}");

                    Console.WriteLine("\nOstavite prazno polje za podatke koje NE želite mijenjati.\n");
                    Console.WriteLine("Želite li sigurno mijenjati podatke?: ");
                    sure = Console.ReadLine();

                    if (sure == "DA")
                    {
                        Console.Write("Novi datum putovanja (YYYY-MM-DD): ");
                        newTripDateString = Console.ReadLine();

                   
                        while (!DateTime.TryParse(newTripDateString, out newTripDate))
                        {
                            Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                            newTripDateString = Console.ReadLine();
                        }
                        while (newTripDate.Year > 2025 && newTripDate.Month > 12 && newTripDate.Day > 31)
                        {
                            Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                            newTripDateString = Console.ReadLine();
                        }

                        Console.Write("Nova kilometraža: ");
                        newTripKm = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newTripKm))
                        {
                            while (!double.TryParse(newTripKm, out tripKm) || tripKm <= 0)
                            {
                                Console.Write("Neispravan unos! Unesi broj kilometara (> 0): ");
                                newTripKm = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(newTripKm))
                                    break; 
                            }

                            if (!string.IsNullOrWhiteSpace(newTripKm))
                                trip["tripKm"] = newTripKm;
                        }

                        Console.Write("Nova količina goriva (L): ");
                        newTripFuelString = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newTripFuelString))
                        {
                            while (!double.TryParse(newTripFuelString, out newTripFuel) || newTripFuel <= 0)
                            {
                                Console.Write("Neispravan unos! Unesi količinu goriva (> 0): ");
                                newTripFuelString = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(newTripFuelString))
                                    break;
                            }

                            if (!string.IsNullOrWhiteSpace(newTripFuelString))
                                trip["tripFuel"] = newTripFuelString;

                        }

                        Console.Write("Nova cijena goriva po litri: ");
                        newTripPriceLitreString = Console.ReadLine();


                        if (!string.IsNullOrWhiteSpace(newTripPriceLitreString))
                        {
                            while (!double.TryParse(newTripPriceLitreString, out newTripPriceLiter) || newTripPriceLiter <= 0)
                            {
                                Console.Write("Neispravan unos! Unesi cijenu po litri (> 0): ");
                                newTripPriceLitreString = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(newTripPriceLitreString))
                                    break;
                            }

                            if (!string.IsNullOrWhiteSpace(newTripPriceLitreString))
                                trip["tripPricePerLiter"] = newTripPriceLitreString;
                        }

                        if (double.TryParse(trip["tripFuel"], out newTripFuel) && double.TryParse(trip["tripPricePerLiter"], out newTripPriceLiter))
                        {
                            newTotalTripPrice = newTripFuel * newTripPriceLiter;
                            trip["tripTotalPrice"] = newTotalTripPrice.ToString();
                        }

                        Console.WriteLine("\nUspješne izmjene!\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Izmjene prekinute!");
                        return;
                    }
                }
            }

            Console.WriteLine("Nijedno putovanje ne odgovara unesenom id-u");
        }



    }
}