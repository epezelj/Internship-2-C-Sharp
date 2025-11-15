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

        public static void PrintUsers()
        {
            foreach (var user in usersList)
            {
                Console.WriteLine(
                    $"{user["userId"]} - " +
                    $"{user["userName"]} - " +
                    $"{user["userSurname"]} - " +
                    $"{user["userBirthDate"]} - " +
                    $"{user["tripId"]}"
                );
            }

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
            while (!DateTime.TryParse(userBirthDateString, out userBirthDate))
            {
                Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                userBirthDateString = Console.ReadLine();
            }
            while (userBirthDate.Year > 2025 && userBirthDate.Month > 12 && userBirthDate.Day > 31)
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
        }

        public static void DeleteUser()
        {
            string deleteUser, deleteByFullName, userId, userFullName, sure;
            bool matchById = false, matchByFullName = false;

            Console.WriteLine("Unesite id ili ime i prezime korisnika");
            deleteUser = Console.ReadLine();

            for (int counter = 0; counter < usersList.Count; counter++)
            {
                var user = usersList[counter];

                userId = user["userId"];
                userFullName = user["userName"] + " " + user["userSurname"];

                matchById = deleteUser.Equals(userId);
                matchByFullName = deleteUser.Equals(userFullName);

                if (matchById || matchByFullName)
                {
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
                else
                {
                    Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u ili imenu i prezimenu");
                }
            }
        }
        public static void EditUser()
        {
            bool matchById = false;
            string userId, sure, editUser, newUserName, newUserSurname, newUserBirthDate, newTripId;

            Console.WriteLine("Unesite id  korisnika");
            editUser = Console.ReadLine();


            foreach (var user in usersList)
            {
                userId = user["userId"];
                matchById = editUser.Equals(userId);

                if (matchById)
                {
                    Console.WriteLine($"Ime: {user["userName"]}");
                    Console.WriteLine($"Prezime: {user["userSurname"]}");
                    Console.WriteLine($"Datum rođenja: {user["userBirthDate"]}");
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
                        newUserBirthDate = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newUserBirthDate))
                        {
                            user["birthDate"] = newUserBirthDate;
                        }

                        Console.Write("Novi ID putovanja: ");
                        newTripId = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newTripId))
                        {
                            user["tripId"] = newTripId;
                        }

                        Console.WriteLine("\nUpješne izmjene!\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Izmjene prekinute!");
                    }
                }
                else
                {
                    Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u");
                }
            }
        }

        public static void ViewUsers()
        {
            List<string> usersSurnamesList = new List<string>();
            DateTime userBirthDate, minusUserBirthDate, nowDateTime = DateTime.Now;
            Console.WriteLine("ID - Ime - Prezime - Datum rođenja - ID putovanja");

            usersList.Sort((usersDict1, usersDict2) => usersDict1["userSurname"].CompareTo(usersDict2["userSurname"]));
            Console.WriteLine("Sortirani korisnici: ");

            foreach (var user in usersList)
            {
                PrintUsers();
            }
            foreach (var user in usersList)
            {
                if (DateTime.TryParse(user["userBirthDate"], out userBirthDate))
                {
                    minusUserBirthDate = nowDateTime.AddYears(-20);
                    if (userBirthDate <= minusUserBirthDate)
                    {
                        PrintUsers();

                    }  
                } 
            }
        }

        public static void ConnectWithTrip(string findUserIdNameSurname, string tripIdString)
        {

            string findUserId, findUserFullName, sure;
            bool matchById = false, matchByFullName = false;


            foreach(var user in usersList)
            {
                findUserId = user["userId"];
                findUserFullName = user["userName"] + " " + user["userSurname"];

                matchById = findUserIdNameSurname.Equals(findUserId);
                matchByFullName = findUserIdNameSurname.Equals(findUserFullName);

                if (matchById || matchByFullName)
                {
                    user["tripId"] = tripIdString;
                }
                else
                {
                    Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u ili imenu i prezimenu");
                }
            }
        }

        public static void UserAnalysis(string findUserIdNameSurname)
        { 
            string findUserId, findUserFullName, sure;
            bool matchById = false, matchByFullName = false;
            int totalPrice = 0, totalFuel = 0, totalKm = 0, maxTripFuel = 0, found  = 0;
            string choiceDate;

            while (string.IsNullOrWhiteSpace(findUserIdNameSurname))
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesi ime: ");
                findUserIdNameSurname = Console.ReadLine();
            }

            Console.WriteLine("Unesite datum: ");
            choiceDate = Console.ReadLine();

            foreach (var user in usersList) {
            {
                findUserId = user["userId"];
                findUserFullName = user["userName"] + " " + user["userSurname"];

                matchById = findUserIdNameSurname.Equals(findUserId);
                matchByFullName = findUserIdNameSurname.Equals(findUserFullName);



                if (matchById || matchByFullName)
                {
                    foreach (var trip in Trips.tripsList)
                    {
                        if (trip["tripId"].Equals(user["tripId"]))
                        {
                            totalPrice = totalPrice + int.Parse(trip["totalTripPrice"]);
                            totalFuel = totalFuel + int.Parse(trip["tripFuel"]);
                            totalKm = totalKm + int.Parse(trip["tripKm"]);

                            if (int.Parse(trip["tripFuel"]) > maxTripFuel)
                            {
                                maxTripFuel = int.Parse(trip["tripFuel"]);
                            }
                            if (totalKm != 0)
                            {
                                Console.WriteLine($"ukupna potorošnja goriva je {totalFuel}, ukupni troškovi goriva {totalPrice}, prosječna  potrošnja goriva {totalFuel / totalKm * 100}, a putovanje s najvećom potrošnjom goriva {maxTripFuel}");
                            }
                        }


                    }
                    foreach (var trip in Trips.tripsList)
                    {
                        if (int.Parse(trip["tripFuel"]) == maxTripFuel)
                        {
                            Trips.PrintTrips();
                        }
                    }
                    foreach (var trip in Trips.tripsList)
                    {
                        if (int.Parse(trip["tripFuel"]) == maxTripFuel)
                        {
                            Trips.PrintTrips();
                        }
                    }

                    foreach (var trip in Trips.tripsList)
                    {
                        if (choiceDate.ToString() == trip["tripDate"])
                        {

                            Console.WriteLine(
                                $"{trip["tripId"]} - " +
                                $"{trip["tripDate"]} - " +
                                $"{trip["tripKm"]} - " +
                                $"{trip["tripFuel"]} - " +
                                $"{trip["tripFuelPriceLiter"]} - " +
                                $"{trip["totalTripPrice"]}");

                        }
                    }
                }
                    found++;
            }
              

            }
            if (found == 0)
                {
                    Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u ili imenu i prezimenu");
                }
            }
    }
}
    
