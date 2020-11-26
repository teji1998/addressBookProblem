using System;

namespace addressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome message
            Console.WriteLine("Welcome to the address book problem !");

            //To add contact into addressbook
            Console.WriteLine("Add the contact detailsin addressbook !");
            AddressBook addressBook = new AddressBook();
            addressBook.AddressBookMenu();

        }
    }
}
