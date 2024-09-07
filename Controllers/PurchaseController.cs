using Microsoft.AspNetCore.Mvc;
using Services.PurchaseService;
using WingsMarket.Models.DragonModel;
using WingsMarket.Models.PurchaseModel;
using WingsMarket.Models.CustomerModel;

namespace WingsMarket.Controllers.PurchaseController;

[ApiController]
[Route("[Purcharse]")]
public class PurchaseController : Controller
{
    private readonly ILogger<PurchaseController> _logger;

    PurchaseService _service;

    public PurchaseController(PurchaseService service, ILogger<PurchaseController> logger){
        
        _service = service;
        _logger = logger;
    }
    [HttpPost("/newPurcharse/idCustomer/idDragon")]
    public async Task<IActionResult> newPurcharse(string idCustomer, string idDragon){
        return Ok();
    }
}