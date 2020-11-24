using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class AddressBook
    {
        public void AddContact()
        {
            Console.WriteLine("Enter the first name");
            String firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            String lastName = Console.ReadLine();
            Console.WriteLine("Enter the address");
            String address = Console.ReadLine();
            Console.WriteLine("Enter the city");
            String city = Console.ReadLine();
            Console.WriteLine("Enter the state");
            String state = Console.ReadLine();
            Console.WriteLine("Enter the zip code");
            long zip = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the phone number");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the email");
            String email = Console.ReadLine();

        }
    }
}
