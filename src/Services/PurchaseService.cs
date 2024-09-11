using Microsoft.EntityFrameworkCore;
using Data.WingsMarketContext;
using WingsMarket.Models.PurchaseModel;
using WingsMarket.Models.DragonModel;
using WingsMarket.Models.CustomerModel;
using System.Runtime.InteropServices;


namespace WingsMarket.Services.PurchaseService;

public class PurchaseService{

    private readonly WingsMarketContext _context;
    public PurchaseService(WingsMarketContext context){
        _context = context;
    }

    public async Task<Purchase?> GetPurchasebyId(string id){
        return await _context.Purchases.AsNoTracking().SingleOrDefaultAsync( p => p.id == id);
    }
    public async Task newPurchase(Dragon dragon, Customer customer){
        Purchase purchase = new Purchase(customer, dragon);
        await _context.Purchases.AddAsync(purchase);
        await _context.SaveChangesAsync();
    }
}