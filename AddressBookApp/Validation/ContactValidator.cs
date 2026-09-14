using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using System.Text.RegularExpressions;

namespace AddressBookApp.Validation
{
    public class ContactValidator
    {
        private bool IsValidName(string name)
        {
            string nameRegex = "^[A-Z][A-Za-z]{2,}$";
            return Regex.IsMatch(name, nameRegex);
        }
        private bool IsValidAddressPart(string value)
        {
            string addressRegex = "^.{4,}$";
            return Regex.IsMatch(value, addressRegex);
        }
        private bool IsValidZip(string zip)
        {
            string zipRegex = "^[0-9]{6}$";
            return Regex.IsMatch(zip, zipRegex);
        }
        private bool IsValidPhone(string phone)
        {
            string phoneRegex = "^[0-9]{10}$";
            return Regex.IsMatch(phone, phoneRegex);
        }
        private bool IsValidEmail(string email)
        {
            string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailRegex);
        }
        public void Validate(Contact c)
        {
            if (!IsValidName(c.FirstName))
            {
                throw new InvalidContactException(
                    "First name must start with a capital letter and be at least 3 characters."
                );
            }

            if (!IsValidName(c.LastName))
            {
                throw new InvalidContactException(
                    "Last name must start with a capital letter and be at least 3 characters."
                );
            }

            if (!IsValidAddressPart(c.Address))
            {
                throw new InvalidContactException(
                    "Address must contain at least 4 characters."
                );
            }

            if (!IsValidAddressPart(c.City))
            {
                throw new InvalidContactException(
                    "City must contain at least 4 characters."
                );
            }

            if (!IsValidAddressPart(c.State))
            {
                throw new InvalidContactException(
                    "State must contain at least 4 characters."
                );
            }

            if (!IsValidZip(c.Zip))
            {
                throw new InvalidContactException(
                    "Zip must contain exactly 6 digits."
                );
            }

            if (!IsValidPhone(c.PhoneNumber))
            {
                throw new InvalidContactException(
                    "Phone number must contain exactly 10 digits."
                );
            }

            if (!IsValidEmail(c.Email))
            {
                throw new InvalidContactException(
                    "Email format is invalid."
                );
            }
        }
    }
}
