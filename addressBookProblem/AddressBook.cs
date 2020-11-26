﻿using System;
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
            String zip = Console.ReadLine(); // long.Parse is used to convert string into long
            Console.WriteLine("Enter the phone number");
            String phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the email");
            String emailId = Console.ReadLine();

            // Creates a reference of contact class
            ContactDetails contactDetails = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, emailId);
            contactList.Add(contactDetails);
            Console.WriteLine(contactDetails);

        }

        //Gives the display menu
        public void DisplayingMenu()
        {
            Console.WriteLine(" Enter your choice ! ");
            Console.WriteLine("For Adding contact : please press 1");
            Console.WriteLine("To Edit contact : please press 2");
            Console.WriteLine("To Delete : please press 3");
            Console.WriteLine("To exit : please press 4");
        }

        /// <summary>
        /// Gives the edit menu.
        /// </summary>
        public void EditMenu()
        {
            Console.WriteLine("Enter 1 to Edit FirstName");
            Console.WriteLine("Enter 2 to Edit LastName");
            Console.WriteLine("Enter 3 to Edit Address");
            Console.WriteLine("Enter 4 to Edit City");
            Console.WriteLine("Enter 5 to Edit State");
            Console.WriteLine("Enter 6 to Edit PhoneNumber");
            Console.WriteLine("Enter 7 to Edit ZipCode");
            Console.WriteLine("Enter 8 to Edit Email");
        }

        public void EditContact()
        {
            Console.WriteLine("Enter your first name of the contact you want to edit");
            string userName = Console.ReadLine();

            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].firstName.Equals(userName))
                {
                    EditMenu();
                    EditContactList(contactList[index]);
                }
                else
                {
                    Console.WriteLine("First Name does not exist");
                }
            }
        }

        /// <summary>
        /// Edits the contact list.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void EditContactList(ContactDetails contact)
        {
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the first name");
                    string name = Console.ReadLine();
                    contact.firstName = name;
                    break;
                case 2:
                    Console.WriteLine("Enter the last name");
                    string lastName = Console.ReadLine();
                    contact.lastName = lastName;
                    break;
                case 3:
                    Console.WriteLine("Enter address");
                    string address = Console.ReadLine();
                    contact.address = address;
                    break;
                case 4:
                    Console.WriteLine("Enter city");
                    string city = Console.ReadLine();
                    contact.city = city;
                    break;
                case 5:
                    Console.WriteLine("Enter state");
                    string state = Console.ReadLine();
                    contact.state = state;
                    break;
                case 6:
                    Console.WriteLine("Enter Phone Number");
                    string phoneNumber = Console.ReadLine();
                    contact.phoneNumber = phoneNumber;
                    break;
                case 7:
                    Console.WriteLine("Enter Zip code");
                    string zipCode = Console.ReadLine();
                    contact.zip = zipCode;
                    break;
                case 8:
                    Console.WriteLine("Enter Email");
                    string email = Console.ReadLine();
                    contact.emailId = email;
                    break;
                default:
                    Console.WriteLine("Enter valid choice");
                    break;

            }
            Console.WriteLine(contact);
        }

        ////// <summary>
        /// Deletes the contact.
        /// </summary>
        public void DeleteContact()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();

            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].firstName.Equals(firstName))
                {
                    if (contactList[index].lastName.Equals(lastName))
                    {
                        contactList.RemoveAt(index);
                        Console.WriteLine("Contact deleted successfully!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Contact not  found");
                }
            }
        }

        //Displays the address book menu
        public void AddressBookMenu()
        {
            bool flag = true;
            while (flag)
            {
                DisplayingMenu();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        EditContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
