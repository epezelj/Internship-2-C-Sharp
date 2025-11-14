using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app
{
    internal class Users
    {
        public static void UsersMenu()
        {
            Console.WriteLine("\nOdabrali ste opciju Korisnici!");
            Console.WriteLine(
                "\n1 - Unos novog korisnika\n" +
                "2 - Brisanje korisnika\n" +
                "3 - Uređivanje korisnika\n" +
                "4 - Pregled svih korisnika\n" +
                "0 - Povratak na glavni izbornik\n"
            );
        
        }
    }
}
