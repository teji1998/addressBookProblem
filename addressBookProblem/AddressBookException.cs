using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    class AddressBookException : Exception
    {
      
        public AddressBookException(string message) : base(message) { }
        
    }
}
