using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class ContactDetails
    {
        //Variables
        //get and set method for variables
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zip { get; set; }
        public String phoneNumber { get; set; }
        public String emailId { get; set; }

        //Constructor
        public ContactDetails(String firstName, String lastName, String address, String city, String state, String zip, String phoneNumber, String emailId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.emailId = emailId;
        }
        
       

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        override
        public string ToString()
        {
            return (" First Name : " + firstName + "\nLast Name : " + lastName + "\nAddress : " + address + "\nCity : " + city +
                "\nState : " + state + "\nZip : " + zip + "\nPhone No : " + phoneNumber + "\nEmail Id : " + emailId );
        }
    }
}
