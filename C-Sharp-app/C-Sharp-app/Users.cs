using System.Security.Cryptography.X509Certificates;

namespace Console_app
{
    internal class Users
    {
        

        public static void UsersMenu()
        {

            int choice;

            Console.WriteLine("\nOdabrali ste opciju Korisnici!");
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
                        //Users.DeleteUser();
                        break;
                    case 3:
                        //Users.EditUser();
                        break;
                    case 4:
                        //Users.ViewUsers();
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
        public static void AddUser()
        {
            List<Dictionary<string, string>> usersList = new List<Dictionary<string, string>>();
            DateTime birthDate;

            int userIdInt = 0;
            string userIdString, name, surname, birthDateString, tripId;
            Dictionary<string,string> userDict = new Dictionary<string, string>();

            Console.WriteLine("\nUNOS NOVOG KORISNIKA");

            userIdString = userIdInt.ToString();

            Console.Write("Unesi ime: ");
            name = Console.ReadLine();

            Console.Write("Unesi prezime: ");
            surname = Console.ReadLine();

            Console.Write("Unesi datum rođenja (npr. 2000-05-12): ");
            birthDateString = Console.ReadLine();

            while (!DateTime.TryParse(birthDateString, out birthDate))
            {
                Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                birthDateString = Console.ReadLine();
            }
            while (birthDate.Year > 2025 && birthDate.Month > 12 && birthDate.Day > 31)
            {
                Console.Write("Neispravan datum, pokušaj ponovno (npr. 2000-05-12): ");
                birthDateString = Console.ReadLine();
            }

            //Console.Write("Unesi ID putovanja: ");
            //tripId = Console.ReadLine();

            userDict.Add("userId", userIdString);
            userDict.Add("name", name);
            userDict.Add("surname", surname);
            userDict.Add("birthDate", birthDateString);
            //userDict.Add("tripId", tripId);

            userIdInt++;

            usersList.Add(userDict);









        }



    }
}
