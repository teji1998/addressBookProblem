using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class ContactDetails
    {
       
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public String firstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public String lastName { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public String address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public String city { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public String state { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        public String zip { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public String phoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>
        /// The email identifier.
        /// </value>
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

        public ContactDetails(string firstname, string city, string state)
        {
            this.firstName = firstName;
            this.city = city;
            this.state = state;
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
            return ("First Name : " + firstName + "\nLast Name : " + lastName + "\nAddress : " + address + "\nCity : " + city +
                "\nState : " + state + "\nZip : " + zip + "\nPhone No : " + phoneNumber + "\nEmail Id : " + emailId );
        }
    }
}
