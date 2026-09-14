using AddressBookApp.Models;
using System;
using System.Collections.Generic;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts = new List<Contact>();
        public IReadOnlyList<Contact> Contacts =>contacts;

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void PrintAll()
        {
            foreach(Contact contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
