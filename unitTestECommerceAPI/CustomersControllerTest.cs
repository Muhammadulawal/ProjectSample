using ECommerceAPI.Controllers;
using ECommerceAPI.Data;
using ECommerceAPI.DTO;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace unitTestECommerceAPI
{
 
    public class CustomersControllerTests
    {
        // Instance of the controller being tested
        private readonly CustomerController _controller;

        // Mock instance of the service
        private readonly Mock<CustomerRepository> _mockService;

        // Constructor to initialize mock service and the controller
        public CustomersControllerTests()
        {
            // Creating a mock object for ICustomerService
            _mockService = new Mock<CustomerRepository>();

            // Injecting the mock object into the controller
            _controller = new CustomerController(_mockService.Object);
        }

        // Test to verify that GetCustomerById returns an OkObjectResult with the correct Customer
        [Fact]
        public void GetCustomer_ReturnsOkResultWithCustomer()
        {
            // Arrange
            var CustomerId = 1; // Define the Customer ID to retrieve
            var expectedCustomer = new Customer { CustomerId = 1, Name = "John Doe", Email = "john@example.com", Address = "Abuja" }; // Define the expected Customer
            _mockService.Setup(service => service.GetCustomerByIdAsync(CustomerId)).Returns(expectedCustomer); // Configure the mock service to return the expected Customer

            // Act
            var result = _controller.GetCustomerById(CustomerId) as OkObjectResult; // Call the controller method and cast the result to OkObjectResult

            // Assert
            Assert.NotNull(result); // Check that the result is not null
            Assert.Equal(200, result.StatusCode); // Check that the status code is 200 OK
            Assert.Equal(expectedCustomer, result.Value); // Check that the returned value is the expected Customer
        }

        // Test to verify that GetCustomerById returns a NotFoundResult when the Customer is not found
        [Fact]
        public void GetCustomer_ReturnsNotFoundWhenCustomerNotFound()
        {
            // Arrange
            var CustomerId = 99; // Define a non-existent Customer ID
            _mockService.Setup(service => service.GetCustomerByIdAsync(CustomerId)).Returns((Customer)null); // Configure the mock service to return null

            // Act
            var result = _controller.GetCustomerById(CustomerId) as NotFoundResult; // Call the controller method and cast the result to NotFoundResult

            // Assert
            Assert.NotNull(result); // Check that the result is not null
            Assert.Equal(404, result.StatusCode); // Check that the status code is 404 Not Found
        }

        // Test to verify that GetAllCustomers returns an OkObjectResult with a list of Customers
        [Fact]
        public void GetAllCustomers_ReturnsOkResultWithListOfCustomers()
        {
            // Arrange
            var expectedCustomers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "John Doe", Email = "john@example.com", Address="Abuja"},
                new Customer { CustomerId = 2, Name = "Jane Smith", Email = "jane@example.com", Address = "Lagos" }
            }; // Define the expected list of Customers
            _mockService.Setup(service => service.GetAllCustomersAsync()).Returns(expectedCustomers); // Configure the mock service to return the expected list of Customers

            // Act
            var result = _controller.GetAllCustomers() as OkObjectResult; // Call the controller method and cast the result to OkObjectResult

            // Assert
            Assert.NotNull(result); // Check that the result is not null
            Assert.Equal(200, result.StatusCode); // Check that the status code is 200 OK
            Assert.Equal(expectedCustomers, result.Value); // Check that the returned value is the expected list of Customers
        }

        // Test to verify that AddCustomer returns a CreatedAtActionResult
        [Fact]
        public void AddCustomer_ReturnsCreatedAtAction()
        {
            // Arrange
            var newCustomer = new CustomerDTO { CustomerId = 3, Name = "Sam Wilson", Email = "sam@example.com", Address="Kano"}; // Define the new Customer to add

            // Act
            var result = _controller.CreateCustomer(newCustomer) as CreatedAtActionResult; // Call the controller method and cast the result to CreatedAtActionResult

            // Assert
            Assert.NotNull(result); // Check that the result is not null
            Assert.Equal(201, result.StatusCode); // Check that the status code is 201 Created
            Assert.Equal("GetCustomerById", result.ActionName); // Check that the action name is "GetCustomerById"
            Assert.Equal(newCustomer.CustomerId, ((Customer)result.Value).CustomerId); // Check that the returned Customer ID is the new Customer's ID
        }

        // Test to verify that UpdateCustomer returns a NoContentResult
        [Fact]
        public void UpdateCustomer_ReturnsNoContent()
        {
            // Arrange
            var updatedCustomer = new CustomerDTO { CustomerId = 1, Name = "John Updated", Email = "john.updated@example.com", Address = "Abuja, Nigeria"}; // Define the updated Customer
            _mockService.Setup(service => service.UpdateCustomerAsync(updatedCustomer)); // Configure the mock service to update the Customer

            // Act
            var result = _controller.UpdateCustomer(1, updatedCustomer) as NoContentResult; // Call the controller method and cast the result to NoContentResult

            // Assert
            Assert.NotNull(result); // Check that the result is not null
            Assert.Equal(204, result.StatusCode); // Check that the status code is 204 No Content
        }

        // Test to verify that DeleteCustomer returns a NoContentResult
        [Fact]
        public void DeleteCustomer_ReturnsNoContent()
        {
            // Arrange
            var CustomerId = 1; // Define the Customer ID to delete
            _mockService.Setup(service => service.DeleteCustomerAsync(CustomerId)); // Configure the mock service to delete the Customer

            // Act
            var result = _controller.DeleteCustomer(CustomerId) as NoContentResult; // Call the controller method and cast the result to NoContentResult

            // Assert
            Assert.NotNull(result); // Check that the result is not null
            Assert.Equal(204, result.StatusCode); // Check that the status code is 204 No Content
        }
    }
}