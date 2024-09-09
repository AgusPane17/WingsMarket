using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using WingsMarket.DTOs.CustomerDTO;
using WingsMarket.Models.CustomerModel;
using WingsMarket.Services.CustomerService;

namespace WingsMarket.Controllers.CustomerController;

public class CustomerController : Controller{
    private readonly ILogger<CustomerController> logger;
    CustomerService service;
    public CustomerController (CustomerService service, ILogger<CustomerController> logger)
    {   

        this.service = service;
        this.logger = logger;

    }

    [HttpGet("Customer/id")]
    public async Task<IActionResult> GetCustomerById(string id){
        var customer = await service.GetCustomerById(id);
        if (customer == null)  {
            return NotFound();  
        }
        return Ok(customer);
    }

    [HttpPost("Customer/")]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO newCustomer){
        try{
            if (!ModelState.IsValid) {
                throw new  InvalidOperationException($"Failed to create customer. Model state is invalid: {ModelState}");                
            }
            if (newCustomer is null) {
                throw new ArgumentNullException(nameof(newCustomer), "The customer object is null.");                
            }
            Customer ctm = new Customer(
                    Guid.NewGuid().ToString(),
                    newCustomer.nameCustomer,
                    newCustomer.lastNameCustomer,
                    newCustomer.emailCustomer,
                    newCustomer.phoneNumberCustomer,
                    newCustomer.ageCustomer
                );
            var response = await service.CreateCustomer(ctm); 
            return Ok($"The customer was created with the id: {response.id}");
        }
        catch (InvalidOperationException ex)
        {
            // Manejo de errores específicos
            return BadRequest(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            // Manejo de errores específicos
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Manejo de cualquier otro tipo de excepción
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }  
    }
}