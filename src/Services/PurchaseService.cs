using Microsoft.EntityFrameworkCore;
using Data.WingsMarketContext;
using WingsMarket.Models.PurchaseModel;
using WingsMarket.Models.DragonModel;
using WingsMarket.Models.CustomerModel;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;


namespace WingsMarket.Services.PurchaseService;

public class PurchaseService{

    private readonly WingsMarketContext _context;
    public PurchaseService(WingsMarketContext context){
        _context = context;
    }

    public async Task<Purchase?> GetPurchasebyId(string id){
        try
        {
            return await _context.Purchases.AsNoTracking().SingleOrDefaultAsync( p => p.id == id);
        }
        catch (DbUpdateException dbEx)
        {
            // Error al actualizar la base de datos
            throw new Exception("Error updating database:" + dbEx.Message);
        }
        catch (ValidationException valEx)
        {
            // Error de validación
            throw new Exception("Validation error:" + valEx.Message);
        }
        catch (ArgumentNullException argEx)
        {
            // Error por argumentos nulos
            throw new Exception("One of the parameters is null: " + argEx.Message);
        }
        catch (Exception ex)
        {
            // Cualquier otro error
            throw new Exception("An error occurred:" + ex.Message);
        }
    }
    public async Task newPurchaseAndSave(Dragon dragon, Customer customer){
        try
        {
            Purchase purchase = new Purchase(customer, dragon);

            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();  
        }
        catch (DbUpdateException dbEx)
        {
            //Error al actualizar la base de datos
            throw new Exception("Error updating database:" + dbEx.Message);
        }
        catch (ValidationException valEx)
        {
            //Error de validación
            throw new Exception("Validation error:" + valEx.Message);
        }
        catch (ArgumentNullException argEx)
        {
            //Error por argumentos nulos
            throw new Exception("One of the parameters is null: " + argEx.Message);
        }
        catch (Exception ex)
        {
            //Cualquier otro error
            throw new Exception("An error occurred:" + ex.Message);
        }
        
        
    }
}