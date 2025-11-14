namespace Console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            while (true)
            {

                Console.WriteLine(
                    "1 - Korisnici\n" +
                    "2 - Putovanja\n" +
                    "0 - Izlaz iz aplikacije\n");

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {

                    switch (choice)
                    {
                        case 1:
                            Users.UsersMenu();
                            break;

                        case 2:
                            Trips.TripsMenu();
                            break;

                        case 0:
                            Console.WriteLine("\nIzlaz iz aplikacije");
                            return;

                        default:
                            Console.WriteLine("Neispravan unos!");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Neispravan unos!");
                }
            }
        }
    }
}