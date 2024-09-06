using System.ComponentModel.DataAnnotations;
using WingsMarket.Models.DragonRiderModel;

namespace WingsMarket.Models.DragonModel{

    public class Dragon 
    {

        public string id {get; set;}
        [Required]
        [MaxLength(100)]    
        private string nameDragon  {get; set;}
        private int ageDragon  {get; set;}
        private string? colorDragon {get; set;}  
        private int costRental  {get; set;}
        private int costSale  {get; set;}        
        private DragonRider? hisDragonRider;

        public Dragon(string id,string nameDragon, int ageDragon, string colorDragon, int costRental,int costSale)
        {
            this.id = id;
            this.nameDragon = nameDragon;
            this.ageDragon = ageDragon;
            this.colorDragon = colorDragon;
            this.costRental =  costRental;
            this.costSale = costSale;
        }
        public Dragon(string id, Dragon editDragon)
        {   
            this.id = id;
            this.nameDragon = editDragon.nameDragon;
            this.ageDragon = editDragon.ageDragon;
            this.colorDragon = editDragon.colorDragon;
            this.costRental =  editDragon.costRental;
            this.costSale = editDragon.costSale;
        }
        public int getAgeDragon(){
            return ageDragon;
        }
        public string? getNameDragon(){
            return nameDragon;
        }
        public string? getColorDragon(){
            return colorDragon;
        }
        public int getCostRental(){
            return ageDragon;
        }
        public int getCostSale(){
            return costSale;
        }
        public DragonRider? GetDragonRider(){
            return hisDragonRider;
        }
        public void setAgeDragon(int age){
            this.ageDragon = age;
        }
        public void setColorDragon(string colorDragon){
            this.colorDragon = colorDragon;
        }
        public void setNameDragon(string nameDragon){
            this.nameDragon = nameDragon;
        }
        public void setCostSaleDragon(int newCostSale){
            this.costSale = newCostSale;
        }
        public void setCostRentalDragon(int newCostRental){
            this.costRental = newCostRental;
        }
        public void assignDragonRider(DragonRider aDragonRider){
            this.hisDragonRider = aDragonRider;
        }
    }

}
