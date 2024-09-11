using System.ComponentModel.DataAnnotations;
using WingsMarket.Models.DragonModel;

namespace WingsMarket.Models.TypeDragonModel;

public class TypeDragon
{
    public int id;
    [Required]
    [MaxLength(100)]  
    private string nameTypeDragon;

    private List<Dragon> allDragonOfAOneType; 

    public TypeDragon (string newNameType){
        this.nameTypeDragon = newNameType;
        allDragonOfAOneType = [];
    }

    public string getTypeNameDragon() 
    {
        return nameTypeDragon;
    }
    public void setTypeNameDragon(string newNameType)
    {
        this.nameTypeDragon = newNameType;
    }
}