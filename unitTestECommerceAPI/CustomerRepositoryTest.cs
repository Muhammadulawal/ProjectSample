// Importing the Models namespace which likely contains the UserRepository and User classes
using ECommerceAPI.Data;
using ECommerceAPI.DTO;
using ECommerceAPI.Models;



namespace unitTestECommerceAPI;


    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _customerRepository;

        // Constructor initializes the UserRepository instance
        public CustomerRepositoryTests()
        {
            _customerRepository = new CustomerRepository();
        }

        // Test to verify that GetUserById returns the correct user
        [Fact]
        public void GetCustomerByIdAsync_ReturnsCorrectUser()
        {
            // Arrange
            var customerId = 1;

            // Act
            var result = _customerRepository.GetCustomerByIdAsync(customerId);

            // Assert
            // Check that result is not null
            Assert.NotNull(result);

            // Check that the ID of the returned user is correct
            Assert.Equal(customerId, result.Id);
        }

        // Test to verify that GetUserById returns null when the user is not found
        [Fact]
        public void GetCustomerByIdAsync_ReturnsNullWhenUserNotFound()
        {
            // Arrange
            // Assuming this ID does not exist
            var customerId = 99;

            // Act
            var result = _customerRepository.GetCustomerByIdAsync(customerId);

            // Assert
            // Check that result is null
            Assert.Null(result);
        }

        // Test to verify that GetAllUsers returns all users
        [Fact]
        public async void GetAllCustomersAsync_ReturnsAllUsers()
        {
            // Act
            var result = await _customerRepository.GetAllCustomersAsync();

            // Assert
            // Check that result is not null
            Assert.NotNull(result);

            // Assuming there are 2 users, check that the count is correct
            Assert.Equal(2, result.Count());
        }

        // Test to verify that AddUser adds a user correctly
        [Fact]
        public async void AddCustomer_AddsCustomerCorrectly()
        {
            // Arrange
            var newCustomer = new CustomerDTO {  Name = "Sam Wilson",  Email = "sam@example.com", Address = "FCT, Abuja"};

        // Act
            var newId = await _customerRepository.InsertCustomerAsync(newCustomer);
            var result = await _customerRepository.GetCustomerByIdAsync(newId);

            // Assert
            Assert.NotNull(result); // Check that the user was added and returned
            Assert.Equal(newCustomer.Name, result.Name); // Check that the ID is correct
            Assert.Equal(newCustomer.Address, result.Address); // Check that the name is correct
            Assert.Equal(newCustomer.Email, result.Email); // Check that the email is correct
        }

        // Test to verify that UpdateUser updates a user correctly
        [Fact]
        public async void UpdateCustomer_UpdatesCustomerCorrectly()
        {
            // Arrange
            var updatedCustomer = new CustomerDTO { CustomerId = 1, Name = "John Updated", Email = "john.updated@example.com", Address = "Abuja, Nigeria"  };

            // Act
            _customerRepository.UpdateCustomerAsync(updatedCustomer);
            var result =  await _customerRepository.GetCustomerByIdAsync(1);

            // Assert
            Assert.NotNull(result); // Check that the user was found
            Assert.Equal(updatedCustomer.Name, result.Name); // Check that the name was updated
            Assert.Equal(updatedCustomer.Email, result.Email); // Check that the email was updated
        }

        // Test to verify that DeleteUser deletes a user correctly
        [Fact]
        public void DeleteCustomer_DeletesCustomerCorrectly()
        {
            // Arrange
            var customerId = 1;

            // Act
            _customerRepository.DeleteCustomerAsync(customerId);
            var result = _customerRepository.GetCustomerByIdAsync(customerId);

            // Assert
            Assert.Null(result); // Check that the user was deleted and cannot be found
        }
    }
