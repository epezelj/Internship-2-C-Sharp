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
                    if (choice == 1)
                    {
                        Users.UsersMenu();
                    }
                    if (choice == 2)
                    {
                        Trips.TripMenu();

                    }
                    if (choice == 0)
                    {
                        Console.WriteLine("\nIzlaz iz aplikacije");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nNeodgovarajući tip unosa!\n");
                }
            }
        }
    }
}