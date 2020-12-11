using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace addressBookProblem
{

    class AddressBook : AddressBookInterface
    {
        public string city;
        public string firstName;
        public string lastName;
        public string address;
        public string state;
        public string phoneNumber;
        public string zip;
        public string emailId;
        NLog nLog = new NLog();
        bool option = true;
        List<ContactDetails> cityData = new List<ContactDetails>();

        FileOperations ops = new FileOperations();

        public string cityFile = "City.txt";
        public string stateFile = "State.txt";

        // Creating a list to store the contacts 
        List<ContactDetails> contactList;

        //Creating a dictionary to store the addressbooks
       // Dictionary<String, List<ContactDetails>> sortedAddressBook = new Dictionary<String, List<ContactDetails>>();

        //Creating a dictionary to store the cities
        Dictionary<string, string> cityList = new Dictionary<string, string>();

        //Creating a dictionary to store the states
        Dictionary<string, string> stateList = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// </summary>
        public AddressBook()
        {
            contactList = new List<ContactDetails>();
        }

        String NAME = "^[a-zA-Z]{3,}$";
        String PHONENUMBER = "^[1-9]{1}[0-9]{9}$";
        String ZIP = "^[1-9]{1}[0-9]{5}$";

        //Validating the contact in addressbook
        public void ValidatingContact(String firstName, String lastName, String phoneNumber, String zip)
        {
            if ( Regex.IsMatch(firstName, NAME) && (Regex.IsMatch(lastName, NAME)) && (Regex.IsMatch(phoneNumber, PHONENUMBER)) && (Regex.IsMatch(zip, ZIP)))
            {
                contactList.Add(new ContactDetails(firstName, lastName, address, city, state, phoneNumber, zip, emailId));
                contactList.ForEach(Console.WriteLine);
                Console.WriteLine("Contact Added Successfully!!!!!");
                nLog.LogDebug("Debug successful: AddContact()");
                cityList.Add(firstName, city);
                stateList.Add(firstName, state);
            }
            else
            {
                Console.WriteLine("Enter a valid details");
                nLog.LogError("Invalid input");
                nLog.LogWarn("Give valid data");
            }
        }

        /// <summary>
        /// Adds the contact .
        /// </summary>
        public void AddContact(string filename)
        {
            contactList = ops.ReadTxt(filename);
            Console.WriteLine(contactList.Count);
            option = true;
            while (option)
            {
                try
                {   
                   Console.WriteLine("Enter the first name");
                   firstName = Console.ReadLine();
                   if (DuplicateValueCheck(firstName))
                   {
                       AddContact(filename);
                   }
                   else
                   {
                       Console.WriteLine("Enter the last name");
                       lastName = Console.ReadLine();
                       Console.WriteLine("Enter the address");
                       address = Console.ReadLine();
                       Console.WriteLine("Enter the city");
                       city = Console.ReadLine();
                       Console.WriteLine("Enter the state");
                       state = Console.ReadLine();
                       Console.WriteLine("Enter the zip code");
                       zip = Console.ReadLine();
                       Console.WriteLine("Enter the phone number");
                       phoneNumber = Console.ReadLine();
                       Console.WriteLine("Enter the email");
                       emailId = Console.ReadLine();
                       ValidatingContact(firstName, lastName, phoneNumber, zip);
                       ops.writeCsv(filename, contactList);
                       Console.WriteLine("\nIf you want to add more people in the addressbook press 1");
                       int choice = Convert.ToInt32(Console.ReadLine());
                       if (choice == 1)
                          AddContact(filename);
                       else
                           option = false;
                       }
                }
                catch (System.FormatException formatException)
                {
                    //Console.WriteLine(formatException.Message);
                    throw formatException;

                }
                catch (AddressBookException)
                {
                    throw new AddressBookException("Given input is not valid.Use an integer value");
                }
            }
                     
        }

        /// <summary>
        /// To view all the contacts.
        /// </summary>
        public void ViewContact(string filename)
        {
            contactList = ops.ReadTxt(filename);
            ///Checks for the length of List
            ///If it is empty then it wont display any elements
            if (contactList.Count != 0)
            {
                for (int index = 0; index < contactList.Count; index++)
                {
                    Console.WriteLine("/************************************************************/");
                    Console.WriteLine("First Name      :       " + contactList[index].firstName);
                    Console.WriteLine("Last Name       :       " + contactList[index].lastName);
                    Console.WriteLine("Address         :       " + contactList[index].address);
                    Console.WriteLine("City            :       " + contactList[index].city);
                    Console.WriteLine("State           :       " + contactList[index].state);
                    Console.WriteLine("Phone Number    :       " + contactList[index].phoneNumber);
                    Console.WriteLine("Zip             :       " + contactList[index].zip);
                    Console.WriteLine("Email           :       " + contactList[index].emailId);
                    Console.WriteLine("/************************************************************/");
                }
                nLog.LogDebug("Debug successful: ViewContact()");
            }
            else
            {
                Console.WriteLine("Address Book is empty . No contacts to display");
                nLog.LogError("Addressbook has null values");
                nLog.LogWarn("Addressbook should have value");
            }
        }

        //Gives the display menu
        public void DisplayingMenu()
        {
            
            Console.WriteLine("Enter your choice ! ");
            Console.WriteLine("To add contact                             : please press 1");
            Console.WriteLine("To edit contact                            : please press 2");
            Console.WriteLine("To delete contact                          : please press 3");
            Console.WriteLine("To view contact                            : please press 4");
            Console.WriteLine("To search contact                          : please press 5");
            Console.WriteLine("To view contact by city or state           : please press 6");
            Console.WriteLine("To get count of contacts by city or state  : please press 7");
            Console.WriteLine("To sort the contact by name                : please press 8");
            Console.WriteLine("To sort by state or city or zip            : please press 9");
            Console.WriteLine("To exit                                    : please press any number after 9");
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

        public void EditContact(string filename)
        {
            contactList = ops.ReadTxt(filename);
            Console.WriteLine("Enter the first name of the contact you want to edit");
            string userName = Console.ReadLine();

            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].firstName.Equals(userName))
                {
                    EditMenu();
                    EditContactList(contactList[index]);
                    ops.WriteText(filename, contactList);
                    ViewContact(filename);
                    nLog.LogDebug("Debug successful: EditContact()");
                }
                else
                {
                    Console.WriteLine("First Name does not exist");
                    nLog.LogError("First name is not existing");
                    nLog.LogWarn("First name should be correct");
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
            try
            {
                
                var choice = Convert.ToInt32(Console.ReadLine());
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
                        Console.WriteLine("Enter the address");
                        string address = Console.ReadLine();
                        contact.address = address;
                        break;
                    case 4:
                        Console.WriteLine("Enter the city");
                        string city = Console.ReadLine();
                        contact.city = city;
                        break;
                    case 5:
                        Console.WriteLine("Enter the state");
                        string state = Console.ReadLine();
                        contact.state = state;
                        break;
                    case 6:
                        Console.WriteLine("Enter the phone number");
                        string phoneNumber = Console.ReadLine();
                        contact.phoneNumber = phoneNumber;
                        break;
                    case 7:
                        Console.WriteLine("Enter the zip code");
                        string zipCode = Console.ReadLine();
                        contact.zip = zipCode;
                        break;
                    case 8:
                        Console.WriteLine("Enter the email");
                        string email = Console.ReadLine();
                        contact.emailId = email;
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        nLog.LogError("Invalid choice");
                        nLog.LogWarn("The input should be an integer and valid");
                        break;
                  

                }
                

                Console.WriteLine(contact);
            }
            catch (System.FormatException exception)
            {
                //Console.WriteLine(exception.Message);
                throw exception;
               
            }catch (AddressBookException)
            {
                throw new AddressBookException("Given input is not valid.Use an integer value");
            }
        }

        ////// <summary>
        /// Deletes the contact.
        /// </summary>
        public void DeleteContact(string filename)
        {
            contactList = ops.ReadTxt(filename);
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();

            for (int index = 0; index < contactList.Count; index++)
            {
                if ((contactList[index].firstName.Equals(firstName)) && (contactList[index].lastName.Equals(lastName)))
                {
                     contactList.RemoveAt(index);
                     Console.WriteLine("Contact deleted successfully!!!");
                     nLog.LogDebug("Debug successful: DeleteContact()");
                    
                }
                else
                {
                    Console.WriteLine("Contact not found");
                    nLog.LogError("Contact is not existing");
                    nLog.LogError("Give proper input");
                }
            }
        }

        //Displays the address book menu
        public void AddressBookMenu()
        {
            bool flag = true;
            Console.WriteLine("Showing list of files");
            ops.ShowFiles();
            Console.WriteLine("Enter your filename in which u want to perform operation");
            string filename = Console.ReadLine();
            while (flag)
            {

               
                DisplayingMenu();
                try
                {
                   
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddContact(filename);
                            break;
                        case 2:
                            EditContact(filename);
                            break;
                        case 3:
                            DeleteContact(filename);
                            break;
                        case 4:
                            ViewContact(filename);
                            break;
                        case 5:
                            SearchContact(filename);
                            break;
                        case 6:
                            ViewContactByCityOrState();
                            break;
                        case 7:
                            CountContacts(filename);
                            break;
                        case 8:
                            SortingByName(filename);
                            break;
                        case 9:
                            SortByCityStateOrZip(filename);
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (System.FormatException exception ) 
                {
                    //Console.WriteLine(exception.Message);
                    throw exception;
                    
                }
                catch (AddressBookException)
                {
                    throw new AddressBookException("Given input is not valid.Use an integer value");
                }
            }
        }

        /// <summary>
        /// Checks for duplicate value.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        public bool DuplicateValueCheck(string firstName)
        {
            bool result = false;
            foreach(ContactDetails contact in contactList)
            {
                if (contact.firstName.Equals(firstName))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Searches the contact.
        /// </summary>
        public void SearchContact(string filename)
        {
            contactList = ops.ReadTxt(filename);
            Console.WriteLine("To search from city  : please press 1 \nTo search from state : please press 2 ");
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter city name to search");
                        string searchingCity = Console.ReadLine();
                        foreach (ContactDetails contactDetails in contactList.FindAll(cityData => cityData.city.Equals(searchingCity)).ToList())
                        {
                            Console.WriteLine(contactDetails.ToString());
                            nLog.LogDebug("Debug successful : SearchContact()");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string searchingState = Console.ReadLine();
                        foreach (ContactDetails contactDetails in contactList.FindAll(stateData => stateData.state.Equals(searchingState)).ToList())
                        {
                            Console.WriteLine(contactDetails.ToString());
                            nLog.LogDebug("Debug successful : SearchContact()");
                        }
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
                //Console.WriteLine(formatException.Message);    
            }
            catch(AddressBookException)
            {
                throw new AddressBookException("Given input is not valid.Use an integer value");
            }
        }

        /// <summary>
        /// Viewing contact by city or by state
        /// </summary>
        public void ViewContactByCityOrState()
        {
            Console.WriteLine("To view by city  : please press 1 \nTo view by state : please press 2 ");
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter city name to view contacts");
                        string requestedCity = Console.ReadLine();
                        var viewCity = cityList.Where(cityData => cityData.Value.Equals(requestedCity));
                        foreach (var data in viewCity)
                            Console.WriteLine("Firstname:{0} , City:{1} ", data.Key, data.Value);
                        nLog.LogDebug("Debug successful : ViewContactByCityOrState()");
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to view contacts");
                        string requestedState = Console.ReadLine();
                        var viewState = stateList.Where(x => x.Value.Equals(requestedState));
                        foreach (var data in viewState)
                            Console.WriteLine("Firstname:{0} , State:{1}", data.Key, data.Value);
                        nLog.LogDebug("Debug successful : ViewContactByCityOrState()");
                        break;
                }
            }
            catch (System.FormatException exception)
            {
                //Console.WriteLine(exception.Message);
                throw exception;
               
            }
            catch(AddressBookException)
            {
                throw new AddressBookException("Given input is not valid.Use an integer value");
            }
        }

        /// <summary>
        /// Counts the number of contacts
        /// </summary>
        public void CountContacts(string filename)
        {
            contactList = ops.ReadTxt(filename);
            Console.WriteLine("To count by city  : please press 1 \nTo count by state : please press 2 ");
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Please enter the name of the city to count");
                        string requiredCity = Console.ReadLine();
                        int countUsingCity = contactList.FindAll(data => data.city.Equals(requiredCity)).Count;
                        Console.WriteLine("Contacts for the city " + requiredCity + " is : " + countUsingCity);
                        nLog.LogDebug("Debug successful : CountContacts() ");
                        break;
                    case 2:
                        Console.WriteLine("Please enter the name of the state to count");
                        string requiredState = Console.ReadLine();
                        int countUsingState = contactList.FindAll(data => data.state.Equals(requiredState)).Count;
                        Console.WriteLine("Contacts for the state of " + requiredState + " is : " + countUsingState);
                        nLog.LogDebug("Debug successful : CountContacts() ");
                        break;
                }
            }
            catch (System.FormatException exception)
            {
                throw exception;
                //Console.WriteLine(exception.Message);
                
            } catch
            {
                throw new AddressBookException("Given input is not valid.Use an integer value");
            }
        }

        /// <summary>
        /// Sorting the contacts by name in alphabetical order
        /// </summary>
        public void SortingByName(string filename)
        {
            contactList = ops.ReadTxt(filename);
            var result = contactList.OrderBy(name => name.firstName);
            foreach (var sortedName in result)
            {
                Console.WriteLine(sortedName.ToString());

            }
        }

        /// <summary>
        /// To sort contacts by city,state or zip
        /// </summary>
        public void SortByCityStateOrZip(string filename)
        {
            contactList = ops.ReadTxt(filename);
            Console.WriteLine("To sort by city    : press 1");
            Console.WriteLine("To sort by state   : press 2");
            Console.WriteLine("To sort by zip     : press 3");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var cityResult = contactList.OrderBy(data => data.city);
                    foreach (var sortByCity in cityResult)
                        Console.WriteLine(sortByCity.ToString());
                    break;
                case 2:
                    var stateResult = contactList.OrderBy(data => data.state);
                    foreach (var sortByState in stateResult)
                        Console.WriteLine(sortByState.ToString());
                    break;
                case 3:
                    var zipResult = contactList.OrderBy(data => data.zip);
                    foreach (var sortByZip in zipResult)
                        Console.WriteLine(sortByZip.ToString());
                    break;
                default:
                    Console.WriteLine("Please enter correct option");
                    break;
            }
        }
    }
}
