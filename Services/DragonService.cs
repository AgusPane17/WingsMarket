using Microsoft.EntityFrameworkCore;
using Data.WingsMarketContext;
using WingsMarket.Models.DragonModel;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Metadata.Ecma335;

namespace WingsMarket.Services.DragonService;
public class DragonService{

    private readonly WingsMarketContext _context; //Falla si lo dejo como un string que no puede ser null
    public DragonService (WingsMarketContext context)
    {
        _context = context;
    }
    public async Task<Dragon> Create(Dragon newDragon)
    {
        await _context.Dragons.AddAsync(newDragon);
        await _context.SaveChangesAsync();
        return newDragon;
    }
    public async Task<Dragon?> GetById(string id)
    {
        return await _context.Dragons.AsNoTracking().SingleOrDefaultAsync( p => p.id == id);
        
    }
    public async Task UpdateDragon(string id, Dragon editDragon){
        
        await _context.Database.ExecuteSqlAsync(
            $"UPDATE Dragon SET nameDragon ='{editDragon.getNameDragon()}', colorDragon = '{editDragon.getColorDragon()}', ageDragon = '{editDragon.getAgeDragon()}', costRental = '{editDragon.getCostRental()}', costSale = {editDragon.getCostSale()} WHERE Id = {id}"
        );

        await _context.SaveChangesAsync();
    }
    public async Task<bool> DeleteDragon(string id)
    {
        var dragon = await _context.Dragons.FindAsync(id);
        if(dragon is not null) 
        {
            _context.Dragons.Remove(dragon);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
        
    }
}