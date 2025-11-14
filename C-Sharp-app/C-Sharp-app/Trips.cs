namespace Console_app
{
    internal class Trips
    {
       
        public static void TripsMenu()
        {

            Console.WriteLine("\nOdabrali ste opciju Putovanja!");
            Console.WriteLine(
                "\n1 - Unos novog putovanja\n" +
                "2 - Brisanje putovanja\n" +
                "3 - Uređivanje postojećeg putovanja\n" +
                "4 - Pregled svih putovanja\n" +
                "5 - Izvještaji i analize\n" +
                "0 - Povratak na glavni izbornik\n"
                );
        }
    }
}
