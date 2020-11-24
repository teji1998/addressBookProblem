using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class ContactDetails
    {
        //Variables
        public String firstName;
        public String lastName;
        public String address;
        public String city;
        public String state;
        public long zip;
        public long phoneNumber;
        public String emailId;

        //Constructor
        public ContactDetails(String firstName, String lastName, String address, String city, String state, long zip, long phoneNumber, String emailId)
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

        public string toString()
        {
            return (" First Name : " + firstName + " Last Name : " + lastName + " Address : " + address + " City : " + city +
                " State : " + state + " Zip : " + zip + " Phone No : " + phoneNumber + " Email Id : " + emailId );
        }
    }
}
