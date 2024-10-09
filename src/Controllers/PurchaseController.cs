using Microsoft.AspNetCore.Mvc;
using WingsMarket.Services.PurchaseService;
using WingsMarket.Services.DragonService;
using WingsMarket.Services.CustomerService;
using WingsMarket.Models.DragonModel;
using WingsMarket.Models.PurchaseModel;
using WingsMarket.Models.CustomerModel;

namespace WingsMarket.Controllers.PurchaseController;

[ApiController]
[Route("[Purcharse]")]
public class PurchaseController : Controller
{
    private readonly ILogger<PurchaseController> _logger;

    private readonly PurchaseService _servicePurchase;
    private readonly DragonService _serviceDragon;
    private readonly CustomerService _serviceCustomer;

    public PurchaseController(PurchaseService servicePurchase, DragonService serviceDragon,CustomerService serviceCustomer, ILogger<PurchaseController> logger){
        
        _servicePurchase = servicePurchase;
        _serviceDragon = serviceDragon;
        _serviceCustomer = serviceCustomer;
        _logger = logger;
    }
    [HttpPost("/newPurcharse/idCustomer/idDragon")]
    public async Task<IActionResult> newPurcharse(string idCustomer, string idDragon){

        //Aca deberia tener middelware que validen el como son los params traidos para evaluar
        try{
            var dragon = await _serviceDragon.GetById(idDragon);
            if (dragon is null ) return StatusCode(404, "Dragon is invalid");
               
            var customer = await _serviceCustomer.GetCustomerById(idCustomer);    
            if (customer is null) return StatusCode(404, "Customer is invalid"); 

            await _servicePurchase.newPurchaseAndSave(dragon, customer);
            return Ok();
        }
        catch (Exception ex){
            return StatusCode(500,$"Error created the purchase. Because: {ex}");
        } 
        
    }
}