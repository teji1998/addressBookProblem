using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    interface AddressBookInterface
    {
        public void AddContact();
        public void DeleteContact();
        public void EditContact();
        public void ViewContact();
        public void SearchContact();
        public void CountContacts();
        public void ViewContactByCityOrState();
    }
}
