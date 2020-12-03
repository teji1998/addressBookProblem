using System;

namespace addressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome message
            Console.WriteLine("Welcome to the address book problem !");

            //To perform various operations in addressbook
            Console.WriteLine("Add the contact details in addressbook !");
            AddressBook addressBook = new AddressBook();
            addressBook.AddressBookMenu();

        }
    }
}
