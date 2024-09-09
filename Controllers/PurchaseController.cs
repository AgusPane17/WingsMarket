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
    private readonly ILogger<PurchaseController> logger;

    PurchaseService servicePurchase;
    DragonService serviceDragon;
    CustomerService serviceCustomer;

    public PurchaseController(PurchaseService servicePurchase, DragonService serviceDragon,CustomerService serviceCustomer, ILogger<PurchaseController> logger){
        
        this.servicePurchase = servicePurchase;
        this.serviceDragon = serviceDragon;
        this.serviceCustomer = serviceCustomer;
        this.logger = logger;
    }
    [HttpPost("/newPurcharse/idCustomer/idDragon")]
    public async Task<IActionResult> newPurcharse(string idCustomer, string idDragon){

        //Aca deberia tener middelware que validen el como son los params traidos para evaluar
        try{
            var dragon = await serviceDragon.GetById(idDragon);
            var customer = await serviceCustomer.GetCustomerById(idCustomer);    
               
            if (dragon is null || customer is null){
                
            }
        }
        catch (Exception ex){
            return StatusCode(500,$"Error created the purchase. Because: {ex}");
        } 
        return Ok();
    }
}