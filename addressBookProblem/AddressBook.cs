using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    
    class AddressBook
    {
        // Creating a list to store the contacts 
        List<ContactDetails> contactList;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// </summary>
        public AddressBook()
        {
            contactList = new List<ContactDetails>();
        }

        /// <summary>
        /// Adds the contact .
        /// </summary>
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
            long zip = long.Parse(Console.ReadLine()); // long.Parse is used to convert string into long
            Console.WriteLine("Enter the phone number");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the email");
            String emailId = Console.ReadLine();

            // Creates a reference of contact class
            ContactDetails contactDetails = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, emailId);
            contactList.Add(contactDetails);
            Console.WriteLine(contactDetails);

        }

    }
}
