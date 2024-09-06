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
    private double costPurchase;
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
    private int numberPurchase;
    [Required]
    private Dragon dragonBought;
    [Required]
    private Customer customer;

    public Purchase(Customer customer,Dragon dragon ){
        this.customer = customer;
        this.dragonBought = dragon;
        this.costPurchase = dragon.getCostSale() * coefSale;
    }
    public Purchase(string id,Customer customer,Dragon dragon ,float costPurchase, int numberPurchase){
        this.customer = customer;
        this.dragonBought = dragon;
        this.id = id;
        this.costPurchase = costPurchase;
        this.numberPurchase = numberPurchase;
    }
    public static void setCoefSale(double newCoefSale){Purchase.coefSale = newCoefSale;}
}