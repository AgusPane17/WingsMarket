using Microsoft.EntityFrameworkCore;
using WingsMarket.Models.DragonModel;
using WingsMarket.Models.DragonRiderModel;
using WingsMarket.Models.PurchaseModel;
using WingsMarket.Models.TypeDragonModel;

namespace Data.WingsMarketContext;
public class WingsMarketContext : DbContext
{
    public WingsMarketContext(DbContextOptions<WingsMarketContext> options) : base(options){}
    public DbSet<Dragon> Dragons {get; set;}
    public DbSet<DragonRider> DragonRiders {get; set;}
    public DbSet<TypeDragon> TypeDragons {get; set;}
    public DbSet<Purchase> Purchases {get; set;}
}