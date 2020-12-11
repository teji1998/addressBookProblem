using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookProblem
{
    interface AddressBookInterface
    {
        public void AddContact(string filename);
        public void DeleteContact(string filename);
        public void EditContact(string filename);
        public void ViewContact(string filename);
        public void SearchContact(string filename);
        public void CountContacts(string filename);
        public void ViewContactByCityOrState();
    }
}
