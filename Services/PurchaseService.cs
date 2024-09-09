using Microsoft.EntityFrameworkCore;
using Data.WingsMarketContext;
using WingsMarket.Models.PurchaseModel;


namespace WingsMarket.Services.PurchaseService;

public class PurchaseService{

    private readonly WingsMarketContext _context;
    public PurchaseService(WingsMarketContext context){
        _context = context;
    }

    public async Task<Purchase> GetPurchasebyId(){
        return await
    }
}