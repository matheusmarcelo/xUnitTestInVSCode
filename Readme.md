# xUnitTestInVsCode

A Project's example for a write unit tests with xUnit in VSCode

- [About](#about)
- [Installation](#installation)

## About
This project is an example to write a unit tests with xUnit in VSCode. 

## Installation
### Step 1: Create a Solution and Console Application
1. Create a New Solution
    ```bash
    dotnet new sln -n UnitTestSolution 

2. Create a new console application
    ```bash
    dotnet new -n UnitTestConsoleApp

3. Navigate to the Console Application Directory
    ```bash
    cd UnitTestConsoleApp

4. **Create the UserAccount Class:** In the UnitTestConsoleApp project directory, create a new file named UserAccount.cs and add the following code:
    ```C#
    public class UserAccount
    {
        private string _email;

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
            throw new ArgumentException("Email cannot be null or empty");
            }

            _email = email;
        }

        public string GetEmail()
        {
            return _email;
        }
    }

5. **Add the Console Application to the Solution:**
    ```bash
    dotnet sln add UnitTestConsoleApp/UnitTestConsoleApp.csproj

This command adds the console application project to the solution.

### Step 2: Create and Configure the Test Project
1. **Create a New xUnit Test Project**
    ```bash
    dotnet new xunit -n UnitTestConsoleApp.Tests

2. **Navigate to the Test Project Directory**
    ```bash
    cd UnitTestConsoleApp.Tests

3. **Add xUnit Package:** Add the necessary NuGet packages for xUnit:
    ```bash
    dotnet add package xunit

4. **Reference the console Application:** Add a project reference from the test project to the console application:
    ```bash
    dotnet add referecen ../UnitTestConsoleApp/UnitTestConsoleApp.csproj

### Step 3: Write Unit Tests Using xUnit
1. **Create your test file**: For example, create a UserAccountTest.cs file in the UniTestConsoleApp.Tests directory

2. **Write your tests:** Here's sample test file using xUnit:
    ```C#
    using Xunit;
    using System;
    using UnitTestConsoleApp;

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
            public void SetEmail_ValidEmail_EmailIsSet()
            {
                // Arrange
                string email = "test@example.com";

                // Act
                _userAccount.SetEmail(email);

                // Assert
                Assert.Equal(email, _userAccount.GetEmail());
            }

            [Fact]
            public void SetEmail_EmptyEmail_ThrowsArgumentException()
            {
                // Arrange
                string emptyEmail = "";

                // Act and Assert
                var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(emptyEmail));
                Assert.Equal("Email cannot be null or empty", exception.Message);
            }

            [Fact]
            public void GetEmail_NoEmailSet_ReturnsNull()
            {
                // Act
                string email = _userAccount.GetEmail();

                // Assert
                Assert.Null(email);
            }

            [Theory]
            [InlineData("user@example.com")]
            [InlineData("admin@domain.com")]
            [InlineData("support@company.org")]
            public void SetEmails_ValidEmail_EmailIsSet(string email)
            {
                // Act
                _userAccount.SetEmail(email);

                // Assert
                Assert.Equal(email, _userAccount.GetEmail());
            }

            [Theory]
            [InlineData("")]
            [InlineData(null)]
            [InlineData(" ")] // Testing a single space as input
            public void SetEmail_InvalidEmail_ThrowsArgumentException(string invalidEmail)
            {
                // Act and Assert
                var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(invalidEmail));
                Assert.Equal("Email cannot be null or empty", exception.Message);
            }
        }
    }

### Step 4: Run your tests
```bash
dotnet test
