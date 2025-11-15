namespace Console_app
{
    internal class Users
    {
        public static List<Dictionary<string, string>> usersList = new List<Dictionary<string, string>>();

        public static void UsersMenu()
        {

            Console.WriteLine("\nOdabrali ste opciju Korisnici!");
            while (true)
            {
                Console.WriteLine(
                    "\n1 - Unos novog korisnika\n" +
                    "2 - Brisanje korisnika\n" +
                    "3 - Uređivanje korisnika\n" +
                    "4 - Pregled svih korisnika\n" +
                    "0 - Povratak na glavni izbornik\n"
                );
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            DeleteUser();
                            break;
                        case 3:
                            EditUser();
                            break;
                        case 4:
                            ViewUsers();
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
        public static void InitializeUsers()
        { 
            Users.usersList.Add(new Dictionary<string, string> {
            {"userId", "0"}, {"userName", "Ana"}, {"userSurname", "Anić"},
            {"userBirthDate", "2000-03-15"}, {"tripId", "1"}
            });

            Users.usersList.Add(new Dictionary<string, string> {
            {"userId", "1"}, {"userName", "Ante"}, {"userSurname", "Antić"},
            {"userBirthDate", "1998-10-04"}, {"tripId", "3"}
            });

            Users.usersList.Add(new Dictionary<string, string> {
            {"userId", "2"}, {"userName", "Stipe"}, {"userSurname", "Stipić"},
            {"userBirthDate", "2005-06-22"}, {"tripId", "2"}
            });

            Users.usersList.Add(new Dictionary<string, string> {
            {"userId", "3"}, {"userName", "Ivo"}, {"userSurname", "Ivić"},
            {"userBirthDate", "1999-12-30"}, {"tripId", "4"}
            });

            Users.usersList.Add(new Dictionary<string, string> {
            {"userId", "4"}, {"userName", "Petra"}, {"userSurname", "Petrić"},
            {"userBirthDate", "2002-08-05"}, {"tripId", "0"}
            });
            
            return;
        }

        public static void PrintUser(Dictionary<string, string>user)
        {
            Console.WriteLine(
            $"{user["userId"]} - " +
            $"{user["userName"]} - " +
            $"{user["userSurname"]} - " +
            $"{user["userBirthDate"]} - " +
            $"{user["tripId"]}"
            );

        }
        public static void AddUser()
        {
            DateTime userBirthDate;
            int userId = 0;
            string userIdString, userName, userSurname, userBirthDateString, tripId = "5";
            Dictionary<string,string> userDict = new Dictionary<string, string>();

            Console.WriteLine("\nUNOS NOVOG KORISNIKA");
            userIdString = userId.ToString();
            Console.Write("Unesi ime: ");
            userName = Console.ReadLine();

            while(string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesi ime: ");
                userName = Console.ReadLine();
            }

            Console.Write("Unesi prezime: ");
            userSurname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userSurname))
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesi ime: ");
                userSurname = Console.ReadLine();
            }

            Console.Write("Unesi datum rođenja (npr. 2000-05-12): ");
            userBirthDateString = Console.ReadLine();
            while (!DateTime.TryParse(userBirthDateString, out userBirthDate) ||
            userBirthDate.Year > 2025 && userBirthDate.Month > 12 && userBirthDate.Day > 31)
            {
                Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                userBirthDateString = Console.ReadLine();
            }

            userDict.Add("userId", userIdString);
            userDict.Add("userName", userName);
            userDict.Add("userSurname", userSurname);
            userDict.Add("userBirthDate", userBirthDateString);
            userDict.Add("tripId", tripId);

            userId++;

            usersList.Add(userDict);
            Console.WriteLine("\nKorisnik je uspješno dodan!\n");
        }

        public static void DeleteUser()
        {
            string deleteUser, deleteByFullName, userId, userFullName, sure;
            bool matchById = false, matchByFullName = false;
            int found = 0;

            Console.WriteLine("\nBRISANJE KORISNIKA");
            Console.WriteLine("Unesite ID ili ime i prezime korisnika:");
            deleteUser = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(deleteUser))
            {
                Console.WriteLine("Neispravan unos! Pokušajte ponovno.");
                Console.Write("Unesite ID ili ime i prezime korisnika: ");
                deleteUser = Console.ReadLine();
            }

            for (int counter = 0; counter < usersList.Count; counter++)
            {
                var user = usersList[counter];

                userId = user["userId"];
                userFullName = user["userName"] + " " + user["userSurname"];

                matchById = deleteUser.Equals(userId);
                matchByFullName = deleteUser.Equals(userFullName);

                if (matchById || matchByFullName)
                {
                    found++;
                    Console.WriteLine("Želite li sigurno izbrisati korisnika (DA ili NE)");
                    sure = Console.ReadLine();
        
                    if (sure == "DA")
                    {
                        usersList.RemoveAt(counter);
                        Console.WriteLine("Upješno brisanje!");
                    }
                    else
                    {
                        Console.WriteLine("Brisanje prekinuto!\n");
                    }
                    
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Nijedan korisnik ne odgovara unesenom ID-u ili imenu i prezimenu.");
            }
        }
        public static void EditUser()
        {
            bool matchById = false;
            string userId, sure, editUser, newUserName, newUserSurname, newUserBirthDateString, newTripId;
            DateTime newUserBirthDate;
            int found = 0;

            Console.WriteLine("\n UREĐIVANJE KORISNIKA");
            Console.Write("Unesite ID korisnika: ");
            editUser = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(editUser))
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesite ID korisnika: ");
                editUser = Console.ReadLine();
            }

            foreach (var user in usersList)
            {
                userId = user["userId"];
                matchById = editUser.Equals(userId);

                if (matchById)
                {
                    found++;

                    Console.WriteLine("\nTrenutni podaci korisnika:");
                    PrintUser(user);

                    Console.WriteLine($"ID putovanja: {user["tripId"]}");

                    Console.WriteLine("\nOstavite prazno polje za podatke koje NE želite mijenjati.\n");
                    Console.WriteLine("Želite li sigurno mijenjati podatke?: ");
                    sure = Console.ReadLine();

                    if (sure == "DA")
                    {
                        Console.Write("Novo ime: ");
                        newUserName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newUserName))
                        {
                            user["userName"] = newUserName;
                        }

                        Console.Write("Novo prezime: ");
                        newUserSurname = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newUserSurname))
                        {
                            user["userSurname"] = newUserSurname;
                        }

                        Console.Write("Novi datum rođenja (YYYY-MM-DD): ");
                        newUserBirthDateString = Console.ReadLine();
                        while (!DateTime.TryParse(newUserBirthDateString, out newUserBirthDate) ||
                        newUserBirthDate.Year > 2025 && newUserBirthDate.Month > 12 && newUserBirthDate.Day > 31)
                        {
                            Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                            newUserBirthDateString = Console.ReadLine();
                        }
                        
                         user["birthDate"] = newUserBirthDateString;

                        Console.Write("Novi ID putovanja: ");
                        newTripId = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newTripId))
                        {
                            user["tripId"] = newTripId;
                        }

                        Console.WriteLine("\nPodaci korisnika su uspješno ažurirani!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Izmjene prekinute!");
                        return;
                    }
                }
                
            }
            if (found == 0)
            {
                Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u");
            }
        }

        public static void ViewUsers()
        {
            List<string> usersSurnamesList = new List<string>();
            DateTime userBirthDate, minusUserBirthDate, nowDateTime = DateTime.Now;
            string[] userTripsList;
            int found = 0;

            Console.WriteLine("\nPREGLED SVIH KORISNIKA ");

            Console.WriteLine("\nKorisnici sortirani po prezimenu:\n");
            usersList.Sort((usersDict1, usersDict2) => usersDict1["userSurname"].CompareTo(usersDict2["userSurname"]));
            Console.WriteLine("Sortirani korisnici: ");

            foreach (var user in usersList)
            {
                PrintUser(user);
            }

            Console.WriteLine("\nKorisnici koji imaju više od 20 godina:\n");

            foreach (var user in usersList)
            {
                if (DateTime.TryParse(user["userBirthDate"], out userBirthDate))
                {
                    minusUserBirthDate = nowDateTime.AddYears(-20);
                    if (userBirthDate <= minusUserBirthDate)
                    {
                        found++;
                        PrintUser(user);

                    }  
                } 
            }
            if (found == 0)
            {
                found = 0;
                Console.WriteLine("Nema korisnika starijih od 20 godina.");
            }

            Console.WriteLine("\nKorisnici koji imaju barem 2 putovanja:\n");

            foreach (var user in usersList)
            {
                userTripsList = user["tripId"].Split(" ");
                if (userTripsList.Length >= 2)
                {
                    found++;
                    PrintUser(user);
                }  
            }
            if (found == 0)
            {
                Console.WriteLine("Nema korisnika s barem 2 putovanja.");
            }

        }
        public static void ConnectWithTrip(string findUserIdNameSurname, string tripIdString)
        {
            string findUserId, findUserFullName, sure;
            bool matchById = false, matchByFullName = false;
            int found = 0;

            Console.WriteLine("\nPOVEZIVANJE KORISNIKA S PUTOVANJEM");

            while (string.IsNullOrWhiteSpace(findUserIdNameSurname))
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesite ID ili ime i prezime korisnika: ");
                findUserIdNameSurname = Console.ReadLine();
            }

            if (string.IsNullOrWhiteSpace(tripIdString))
            {
                Console.WriteLine("Neispravan ID putovanja!");
                return;
            }

            while (found == 0)
            {
                foreach (var user in usersList)
                {
                    findUserId = user["userId"];
                    findUserFullName = user["userName"] + " " + user["userSurname"];

                    matchById = findUserIdNameSurname.Equals(findUserId);
                    matchByFullName = findUserIdNameSurname.Equals(findUserFullName);


                    if (matchById || matchByFullName)
                    {
                        user["tripId"] = user["tripId"] + " " + tripIdString;
                        Console.WriteLine($"\nKorisniku {findUserFullName} dodijeljeno je putovanje s ID-jem {tripIdString}.");

                        found++;
                    }
                }
                if (found == 0)
                {
                    Console.WriteLine("Nijedan korisnik ne odgovara unesenom ID-u ili imenu i prezimenu.");
                }

            }
        }
        public static void UserAnalysis(string findUserIdNameSurname)
        { 
            string findUserId, findUserFullName, sure, choiceDateString;
            bool matchById = false, matchByFullName = false;
            double totalPrice = 0, totalFuel = 0, totalKm = 0, maxTripFuel = 0;
            DateTime choiceDate;
            int foundTrip = 0, found = 0, foundDate = 0;
        

            Console.WriteLine("\nIZVJEŠTAJ I ANALIZA KORISNIKA");


            while (string.IsNullOrWhiteSpace(findUserIdNameSurname))
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesite ID ili ime i prezime korisnika: ");
                findUserIdNameSurname = Console.ReadLine();
            }

            Console.Write("Unesite datum za pregled putovanja (YYYY-MM-DD) ili ostavite prazno: ");
            choiceDateString = Console.ReadLine();
            while (!DateTime.TryParse(choiceDateString, out choiceDate) ||
            choiceDate.Year > 2025 && choiceDate.Month > 12 && choiceDate.Day > 31)
            {
                Console.WriteLine("Neispravan datum!");
                Console.Write("Unesite datum (YYYY-MM-DD) ili ostavite prazno: ");
                choiceDateString = Console.ReadLine();
            }

            foreach (var user in usersList) {
            {
                findUserId = user["userId"];
                findUserFullName = user["userName"] + " " + user["userSurname"];

                matchById = findUserIdNameSurname.Equals(findUserId);
                matchByFullName = findUserIdNameSurname.Equals(findUserFullName);

                if (matchById || matchByFullName)
                {
                    found++;
                    foreach (var trip in Trips.tripsList)
                    {
                        if (user["tripId"].Contains(trip["tripId"]))
                        {
                            foundTrip++;
                            totalPrice = totalPrice + double.Parse(trip["totalTripPrice"]);
                            totalFuel = totalFuel + double.Parse(trip["tripFuel"]);
                            totalKm = totalKm + double.Parse(trip["tripKm"]);

                            if (int.Parse(trip["tripFuel"]) > maxTripFuel)
                            {
                                maxTripFuel = double.Parse(trip["tripFuel"]);
                            }
                           
                        }
                    }
                    if (foundTrip == 0)
                    {
                        Console.WriteLine("Ovaj korisnik nema nijedno povezano putovanje.");
                        return;
                    }

                    Console.WriteLine($"\nUkupna potrošnja goriva: {totalFuel} L");
                    Console.WriteLine($"Ukupni troškovi goriva: {totalPrice}");
                    if (totalKm > 0)
                    {
                        double avgConsumption = totalFuel / totalKm * 100.0;
                        Console.WriteLine($"Prosječna potrošnja goriva: {avgConsumption:F2} L/100km");
                    }
                    else
                    {
                        Console.WriteLine("Prosječnu potrošnju nije moguće izračunati (ukupno km = 0).");
                    }

                    if (maxTripFuel != null)
                    {
                        Console.WriteLine("\nPutovanje s najvećom potrošnjom goriva:");
                        Trips.PrintTrip(user);
                    }
                    foreach (var trip in Trips.tripsList)
                    {
                        if (int.Parse(trip["tripFuel"]) == maxTripFuel)
                        {
                            Trips.PrintTrip(trip);
                        }
                    }
                    foreach (var trip in Trips.tripsList)
                    {
                        if (int.Parse(trip["tripFuel"]) == maxTripFuel)
                        {
                            Trips.PrintTrip(trip);
                    }
                    }

                    foreach (var trip in Trips.tripsList)
                    {
                        if (choiceDate.ToString() == trip["tripDate"])
                        {
                            foundDate++;
                                Trips.PrintTrip(trip);   

                        }
                    }
                    if (foundDate == 0)
                    {
                            Console.WriteLine("Nema putovanja na taj datum za ovog korisnika.");

                    }
                }    
            }

            }
            if (found == 0)
                {
                    Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u ili imenu i prezimenu");
                }
            }
    }
}
    
