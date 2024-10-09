using System.ComponentModel.DataAnnotations;
using WingsMarket.Models.DragonModel;
using WingsMarket.Models.CustomerModel;
using Npgsql.Replication;

namespace WingsMarket.Models.PurchaseModel;
public class Purchase{

    private static double coefSale = 1.1;

    [Key]
    public string? id;
    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid integer Number")]
    private double costTotalPurchase; //costo total de la compra
    
    [Required]
    private Dragon dragonBought;
    [Required]
    private Customer customer;

    public Purchase(string id, Customer customer, Dragon dragon, double costTotalPurchase){
        this.id = id;
        this.customer = customer;
        this.dragonBought = dragon;
        this.costTotalPurchase = costTotalPurchase;
    }
    public Purchase(Customer customer,Dragon dragon){
        this.id = Guid.NewGuid().ToString();
        this.customer = customer;
        this.dragonBought = dragon;
        this.costTotalPurchase = dragonBought.getCostSale() * coefSale;
    }
    public static void setCoefSale(double newCoefSale){Purchase.coefSale = newCoefSale;}
}