using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WingsMarket.Models.DragonRiderModel;

namespace WingsMarket.Models.DragonModel{

    public class Dragon 
    {

        public string id {get; set;}
        [Required]
        [StringLength(100)]  
        private string nameDragon  {get; set;}
        [Range(0,100)]
        private int? ageDragon  {get; set;}
        [StringLength(50)]
        private string colorDragon {get; set;}  
        [Range(0,Double.MaxValue)]
        private double costRental  {get; set;}
        [Range(0,Double.MaxValue)]
        private double costSale  {get; set;} 
        [ForeignKey("Dragon")]       
        private DragonRider? hisDragonRider;

        public Dragon(string id,string nameDragon, int? ageDragon, string colorDragon, double costRental,double costSale)
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
        public int? getAgeDragon(){
            return ageDragon;
        }
        public string? getNameDragon(){
            return nameDragon;
        }
        public string? getColorDragon(){
            return colorDragon;
        }
        public double getCostRental(){
            return costRental;
        }
        public double getCostSale(){
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
        public void setCostSaleDragon(double newCostSale){
            this.costSale = newCostSale;
        }
        public void setCostRentalDragon(double newCostRental){
            this.costRental = newCostRental;
        }
        public void assignDragonRider(DragonRider aDragonRider){
            this.hisDragonRider = aDragonRider;
        }
    }

}
