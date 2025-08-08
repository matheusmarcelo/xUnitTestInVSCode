using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestConsoleApp;
using Xunit;

namespace UnitTestConsoleApp.Tests
{
    public class UserAccountTests
    {
        private UserAccount _userAccount;

        // This method is run before each test
        public UserAccountTests()
        {
            _userAccount = new UserAccount();
        }

        [Fact]
        public void SetEmail_ValidEmail_EmailsSet()
        {
            string email = "test@example.com";

            _userAccount.SetEmail(email);

            Assert.Equal(email, _userAccount.GetEmail());
        }

        [Fact]
        public void SetEmail_EmptyEmail_ThrowsArgumentException()
        {
            string emptyEmail = "";

            var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(emptyEmail));

            Assert.Equal("Email cannot be null or empty", exception.Message);
        }

        [Fact]
        public void GetEmail_NoEmaiSet_ReturnNull()
        {
            string email = _userAccount.GetEmail();

            Assert.Null(email);
        }

        [Theory]
        [InlineData("user@example.com")]
        [InlineData("admin@domain.com")]
        [InlineData("support@company.org")]
        public void SetEmails_ValidEmail_EmailsSet(string email)
        {
            _userAccount.SetEmail(email);

            Assert.Equal(email, _userAccount.GetEmail());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void SetEmail_InvalidEmail_ThrowsArgumentException(string email)
        {
            var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(email));
            Assert.Equal("Email cannot be null or empty", exception.Message);
        }
    }
}