using Microsoft.AspNetCore.Mvc;
using WingsMarket.Models.DragonModel;
using Services.DragonService;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WingsMarket.Controllers.DragonController;

[ApiController]
[Route("[Dragon]")]
public class DragonController : ControllerBase
{
    private readonly ILogger<DragonController> _logger;
    DragonService _service;
    public DragonController (DragonService service, ILogger<DragonController> logger)
    {   

        _service = service;
        _logger = logger;

    }
    
    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("In GET");
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        _logger.LogInformation("In GET dragon by id");
        var dragon = await _service.GetById(id);
        if (dragon is not null)
        {   
            return Ok(dragon);
        }
        else
        {
            return NotFound();
        }
    }    
    [HttpPost("Create")]
    public async Task<IActionResult> Create(Dragon newDragon)
    {
        newDragon.id = Guid.NewGuid().ToString();
        var dragon = await _service.Create(newDragon);

        return CreatedAtAction( nameof( GetById ), new { _id = dragon!.id }, dragon);//hace referencia a crear una accion al hecho de ir y ejecutar otro metodo dentro de la clse controller/ como si fuese una consulta http
    }
// como id en [HttpPut("Edit/{id}")], el framework enlaza automáticamente el valor del 
// parámetro de la URL con el parámetro del método de acción. En tu caso, el int id en 
// la firma del método Edit.
// Cuando haces una solicitud HTTP a la ruta Edit/{id}, ASP.NET Core extrae el valor del 
// id de la URL y lo pasa como argumento al método de acción Edit. Este valor de id de la
//  URL tiene prioridad sobre cualquier otro valor que se pueda pasar en el cuerpo de la
// solicitud.

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(string id, Dragon editDragon) 
    {
        var dragon = await _service.GetById(id);
        
        if (dragon is not null) {

            Dragon dragon1 = new Dragon(id,editDragon);
            await _service.UpdateDragon(id, editDragon);

            return Ok(await _service.GetById(id));
        }
        else{
            return NotFound();
        }

    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var dragon = await _service.GetById(id);
        Console.WriteLine(@$"In edit dragon:
        {dragon}");
        if (dragon is not null) {
            await _service.DeleteDragon(id);

            return Ok(await _service.GetById(id));
        }
        else{
            return NotFound();
        }
    }

}