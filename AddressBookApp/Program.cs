using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp
{
    class Program
    {
        static void Main(String[] args)
        {
            Contact contact = new Contact(
            "Saurav",
            "Yadav",
            "House no 585 Sector 32A",
            "Chandigarh",
            "Chandigarh",
            "160030",
            "7087626063",
            "sauravkumaryadav2442005@gmail.com"
             );

            ContactValidator validator = new ContactValidator();

            try
            {
                validator.Validate(contact);

                Console.WriteLine(contact.ToString());
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}