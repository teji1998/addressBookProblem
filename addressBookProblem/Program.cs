using System;

namespace addressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the address book problem !");
            Console.WriteLine("Add the contact details here !");
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact();

        }
    }
}
