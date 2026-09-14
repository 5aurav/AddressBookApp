using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

namespace AddressBookApp
{
    class Program
    {
        static void Main(String[] args)
        {
            AddressBook addressBook = new AddressBook();
            ContactValidator validator = new ContactValidator();
            AddressBookMain addressBookMain = new AddressBookMain();
            addressBookMain.AddAddressBook(addressBook);

            while (true)
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Show All Contacts");
                Console.WriteLine("5. Total Contact Count");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string ?choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter First Name: ");
                    string ?firstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string ?lastName = Console.ReadLine();

                    Console.Write("Enter Address: ");
                    string ?address = Console.ReadLine();

                    Console.Write("Enter City: ");
                    string ?city = Console.ReadLine();

                    Console.Write("Enter State: ");
                    string ?state = Console.ReadLine();

                    Console.Write("Enter Zip: ");
                    string ?zip = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    string ?phoneNumber = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    string ?email = Console.ReadLine();

                    Contact contact = new Contact(
                        firstName,
                        lastName,
                        address,
                        city,
                        state,
                        zip,
                        phoneNumber,
                        email
                    );

                    try
                    {
                        validator.Validate(contact);

                        if (addressBook.AddContact(contact))
                        {
                            Console.WriteLine("Contact added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Contact already exists.");
                        }
                    }
                    catch (InvalidContactException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter First Name: ");
                    string? firstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string? lastName = Console.ReadLine();

                    addressBook.EditContact(firstName, lastName);
                }
                else if (choice == "3")
                {
                    Console.Write("Enter First Name: ");
                    string? firstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string? lastName = Console.ReadLine();

                    addressBook.DeleteContact(firstName, lastName);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("\nAll Contacts:");
                    addressBook.PrintAll();
                }
                else if (choice == "5")
                {
                    Console.WriteLine($"Total Contacts: {addressBookMain.GetTotalContactCount()}");
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Exiting Address Book.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}