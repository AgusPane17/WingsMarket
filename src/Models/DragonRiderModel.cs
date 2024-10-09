using System.ComponentModel.DataAnnotations;
using WingsMarket.Models.DragonModel;

namespace WingsMarket.Models.DragonRiderModel;

public class DragonRider 
{
    public string? id {get; set;}
    private string nameDragonRider;
    private string lastNameDragonRider;
    private int ageDragonRider;
    private string emailDragonRider;
    private Dragon? hisDragon;

    public DragonRider (string nameDragonRider, string lastNameDragonRider, string emailDragonRider, int ageDragonRider ){
        this.id = null;
        this.nameDragonRider = nameDragonRider;
        this.lastNameDragonRider = lastNameDragonRider;
        this.emailDragonRider = emailDragonRider;
        this.ageDragonRider = ageDragonRider;
    }
    public DragonRider (string? id, string nameDragonRider, string lastNameDragonRider, string emailDragonRider, int ageDragonRider ){
        this.id = id;
        this.nameDragonRider = nameDragonRider;
        this.lastNameDragonRider = lastNameDragonRider;
        this.emailDragonRider = emailDragonRider;
        this.ageDragonRider = ageDragonRider;
    }
    public Dragon? getDragon(){
        return hisDragon;
    }
    public int getAgeDragonRider()
    {
        return ageDragonRider;
    }
    public string getEmail() {
        return emailDragonRider;
    }
    public string getNameDragonRider()
    {
        return nameDragonRider;
    }
    public string getLastNameDragonRider()
    {
        return lastNameDragonRider;
    }
    public void setNameDragonRider(string nameRider)
    {
        this.nameDragonRider = nameRider;
    }
    public void setLastNameDragonRider(string lastNameRider)
    {
        this.lastNameDragonRider = lastNameRider;
    }
    public void setEmail(string emailRider)
    {
        this.emailDragonRider = emailRider;
    }
    public void setAgeDragonRider(int ageRider)
    {
        this.ageDragonRider = ageRider;
    }
    public void assignarDragon(Dragon aDragon) 
    {
        this.hisDragon = aDragon;
    }
} 