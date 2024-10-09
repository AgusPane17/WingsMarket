using System.ComponentModel.DataAnnotations;

namespace WingsMarket.DTOs.DragonDTO;
public class DragonDTO{

    public string? id;
    [StringLength(100)]
    public required string? nameDragon;
    [StringLength(50)]
    public required string? colorDragon;
    
    [Range(0,100)]
    public required int? ageDragon;
    [Required]
    [Range(0,Double.MaxValue)]

    public required double? costRental;
    [Range(0,Double.MaxValue)]
    public required double? costSale;
}