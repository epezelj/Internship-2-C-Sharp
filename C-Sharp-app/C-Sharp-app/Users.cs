using System.Security.Cryptography.X509Certificates;

namespace Console_app
{
    internal class Users
    {
        public static List<Dictionary<string, string>> usersList = new List<Dictionary<string, string>>();

        public static void UsersMenu()
        {

            int choice;

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


                if (int.TryParse(Console.ReadLine(), out choice))
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
                            ViewUsers();
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
        public static void AddUser()
        {
            DateTime userBirthDate;

            int userIdInt = 0;
            string userIdString, userName, userSurname, userBirthDateString, tripId;
            Dictionary<string,string> userDict = new Dictionary<string, string>();

            Console.WriteLine("\nUNOS NOVOG KORISNIKA");

            userIdString = userIdInt.ToString();

            Console.Write("Unesi ime: ");
            userName = Console.ReadLine();

            Console.Write("Unesi prezime: ");
            userSurname = Console.ReadLine();

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

            //Console.Write("Unesi ID putovanja: ");
            //tripId = Console.ReadLine();

            userDict.Add("userId", userIdString);
            userDict.Add("userName", userName);
            userDict.Add("userSurname", userSurname);
            userDict.Add("userBirthDate", userBirthDateString);
            //userDict.Add("tripId", tripId);

            userIdInt++;

            usersList.Add(userDict);


        }

        public static void DeleteUser()
        {
            string deleteUser;
            string deleteByFullName;
            bool matchById = false;
            bool matchByFullName = false;
            string userId;
            string userFullName;
            bool found = false;
            string sure;
         

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
                        found = true;


                        if (found)
                        {
                            Console.WriteLine("Korisnik  je obrisan.");
                        }
                        else
                        {
                            Console.WriteLine("Nijedan korisnik ne odgovara unesenom id-u ili imenu i prezimenu.");
                        }
                        found = false;

                    }

                }
                else
                {
                    Console.WriteLine("Korisnik nije izbrisan");
                }
            }


        }

        public static void ViewUsers()
        {
            Console.WriteLine("ID | Ime | Prezime | Datum rođenja | ID putovanja");

            foreach (var user in usersList)
            {
                Console.WriteLine(
                    $"{user["userId"]} | " +
                    $"{user["userName"]} | " +
                    $"{user["userSurname"]} | " +
                    $"{user["userBirthDate"]} | "
                );
            }




        }

    }
}
