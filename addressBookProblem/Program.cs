﻿using System;

namespace addressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome message
            Console.WriteLine("Welcome to the address book problem !");

            //To adds the contact
            Console.WriteLine("Add the contact details here !");
            AddressBook addressBook = new AddressBook();
            addressBook.AddressBookMenu();

        }
    }
}
