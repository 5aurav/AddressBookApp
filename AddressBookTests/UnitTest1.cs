using NUnit.Framework;
using AddressBookApp.Services;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using System.Linq;

namespace AddressBookApp.Tests
{
    [TestFixture]
    public class AddressBookTests
    {
        private Contact CreateSample(string first = "John", string last = "Doe", string city = "CityA")
        {
            return new Contact(
                first,
                last,
                "123 Main St",
                city,
                "StateX",
                "123456",
                "1234567890",
                "john.doe@example.com"
            );
        }

        [Test]
        public void AddContact_ValidContact_AddsAndReturnsTrue()
        {
            var book = new AddressBook();
            var contact = CreateSample();

            bool added = book.AddContact(contact);

            Assert.That(added);
            Assert.That(book.Contacts.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddContact_DuplicateContact_ReturnsFalse()
        {
            var book = new AddressBook();
            var contact = CreateSample();

            Assert.That(book.AddContact(contact));
            Assert.That(!book.AddContact(contact));
            Assert.That(book.Contacts.Count, Is.EqualTo(1));
        }

        [Test]
        public void ContactValidator_InvalidEmail_ThrowsInvalidContactException()
        {
            var invalid = new Contact(
                "Bad",
                "Email",
                "Addr",
                "City",
                "State",
                "123456",
                "1234567890",
                "invalid-email"
            );

            var validator = new ContactValidator();

            Assert.Throws<InvalidContactException>(() => validator.Validate(invalid));
        }
    }
}