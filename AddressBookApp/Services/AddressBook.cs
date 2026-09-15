using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookApp.Exceptions;
using AddressBookApp.Validation;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts = new List<Contact>();
        public IReadOnlyList<Contact> Contacts => contacts;

        public bool AddContact(Contact contact)
        {
            bool isDuplicate = contacts.Any(c =>
                c.FirstName == contact.FirstName &&
                c.LastName == contact.LastName);

            if (isDuplicate)
            {
                return false;
            }

            contacts.Add(contact);
            return true;
        }

        public void EditContact(string ?firstName, string ?lastName)
        {
            Contact ?contact = contacts.FirstOrDefault(c =>
                c.FirstName == firstName && c.LastName == lastName);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.Write($"Enter First Name ({contact.FirstName}): ");
            string ?newFirstName = Console.ReadLine();

            Console.Write($"Enter Last Name ({contact.LastName}): ");
            string ?newLastName = Console.ReadLine();

            Console.Write($"Enter Address ({contact.Address}): ");
            string ?newAddress = Console.ReadLine();

            Console.Write($"Enter City ({contact.City}): ");
            string ?newCity = Console.ReadLine();

            Console.Write($"Enter State ({contact.State}): ");
            string ?newState = Console.ReadLine();

            Console.Write($"Enter Zip ({contact.Zip}): ");
            string ?newZip = Console.ReadLine();

            Console.Write($"Enter Phone Number ({contact.PhoneNumber}): ");
            string ?newPhoneNumber = Console.ReadLine();

            Console.Write($"Enter Email ({contact.Email}): ");
            string ?newEmail = Console.ReadLine();

            string updatedFirstName = string.IsNullOrEmpty(newFirstName)
        ? contact.FirstName : newFirstName;

            string updatedLastName = string.IsNullOrEmpty(newLastName)
                ? contact.LastName : newLastName;

            string updatedAddress = string.IsNullOrEmpty(newAddress)
                ? contact.Address : newAddress;

            string updatedCity = string.IsNullOrEmpty(newCity)
                ? contact.City : newCity;

            string updatedState = string.IsNullOrEmpty(newState)
                ? contact.State : newState;

            string updatedZip = string.IsNullOrEmpty(newZip)
                ? contact.Zip : newZip;

            string updatedPhoneNumber = string.IsNullOrEmpty(newPhoneNumber)
                ? contact.PhoneNumber : newPhoneNumber;

            string updatedEmail = string.IsNullOrEmpty(newEmail)
                ? contact.Email : newEmail;

            Contact updatedContact = new Contact(
                updatedFirstName,
                updatedLastName,
                updatedAddress,
                updatedCity,
                updatedState,
                updatedZip,
                updatedPhoneNumber,
                updatedEmail
            );

            ContactValidator validator = new ContactValidator();

            try
            {
                validator.Validate(updatedContact);

                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.Address = updatedContact.Address;
                contact.City = updatedContact.City;
                contact.State = updatedContact.State;
                contact.Zip = updatedContact.Zip;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.Email = updatedContact.Email;

                Console.WriteLine("Contact updated successfully.");
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteContact(string? firstName, string? lastName)
        {
            Contact? contact = contacts.FirstOrDefault(c =>
                c.FirstName == firstName && c.LastName == lastName);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.Remove(contact);

            Console.WriteLine("Contact deleted successfully.");
        }

        public List<Contact> SearchByCity(string city)
        {
            return contacts.Where(c => c.City == city).ToList();
        }

        public List<Contact> SearchByState(string state)
        {
            return contacts.Where(c => c.State == state).ToList();
        }

        public void ViewByCityOrState()
        {
            Console.WriteLine("--- By City ---");

            var contactsByCity = contacts.GroupBy(c => c.City);

            foreach (var group in contactsByCity)
            {
                Console.WriteLine($"{group.Key}:");

                foreach (Contact contact in group)
                {
                    Console.WriteLine(contact.FirstName + " " + contact.LastName);
                }
            }

            Console.WriteLine("--- By State ---");

            var contactsByState = contacts.GroupBy(c => c.State);

            foreach (var group in contactsByState)
            {
                Console.WriteLine($"{group.Key}:");

                foreach (Contact contact in group)
                {
                    Console.WriteLine(contact.FirstName + " " + contact.LastName);
                }
            }
        }

        public void GetCountByCityOrState()
        {
            var cityCounts = contacts
                .GroupBy(c => c.City)
                .Select(g => new { City = g.Key, Count = g.Count() });

            Console.Write("By City: ");

            foreach (var city in cityCounts)
            {
                Console.Write($"{city.City} = {city.Count}, ");
            }

            Console.WriteLine();

            var stateCounts = contacts
                .GroupBy(c => c.State)
                .Select(g => new { State = g.Key, Count = g.Count() });

            Console.Write("By State: ");

            foreach (var state in stateCounts)
            {
                Console.Write($"{state.State} = {state.Count}, ");
            }

            Console.WriteLine();
        }

        public void SortByName()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortByCity()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.City);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortByState()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.State);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortByZip()
        {
            var sortedContacts = contacts
                .OrderBy(c => c.Zip);

            foreach (Contact contact in sortedContacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void PrintAll()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
