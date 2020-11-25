using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class ContactDetails
    {
        //Variables
        public String firstName; // { get; set; }
        public String lastName; // { get; set; }
        public String address; //{ get; set; }
        public String city; // { get; set; }
        public String state; // { get; set; }
        public String zip; // { get; set; }
        public String phoneNumber; // { get; set; }
        public String emailId; // { get; set; }

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
        
        //Get and set methods are used
        
        public string GetFirstName()
        {
            return firstName;
        }
       
        public string GetLastName()
        {
            return lastName;
        }
        
        public string GetAddress()
        {
            return address;
        }
       
        public string GetCity()
        {
            return city;
        }
        
        public string GetState()
        {
            return state;
        }
       
        public string GetEmailId()
        {
            return emailId;
        }
       
        public String GetPhoneNumber()
        {
            return phoneNumber;
        }
       
        public String GetZip()
        {
            return zip;
        }
        

        //Set method takes the parameter that is passed
        //and variable names are being assigned
        //Also this keyword is being used to refer the current object
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }
       
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }
       
        public void SetAddress(string address)
        {
            this.address = address;
        }
        
        public void SetCity(string city)
        {
            this.city = city;
        }
       
        public void SetState(string state)
        {
            this.state = state;
        }
        
        public void SetZip(String zip)
        {
            this.zip = zip;
        }
       
        public void SetPhoneNumber(String phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        
        public void SetEmailId(string emailId)
        {
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
            return (" First Name : " + firstName + " Last Name : " + lastName + " Address : " + address + " City : " + city +
                " State : " + state + " Zip : " + zip + " Phone No : " + phoneNumber + " Email Id : " + emailId );
        }
    }
}
