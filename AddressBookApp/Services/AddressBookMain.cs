using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        private List<AddressBook> books = new List<AddressBook>();
        public void AddAddressBook(AddressBook addressBook)
        {
            books.Add(addressBook);
        }

        public int GetTotalContactCount()
        {
            return books.Sum(book => book.Contacts.Count);
        }
    }
}
