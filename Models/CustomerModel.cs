using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using WingsMarket.Models.PurchaseModel;

namespace WingsMarket.Models.CustomerModel;

public class Customer{

    public string? id;
    [Required]
    [StringLength(100)]
    private string nameCustomer;
    [Required]
    [StringLength(100)]
    private string lastNameCustomer;
    [Required]
    [Range(18,100)]
    private int ageCustomer;
    [Required]
    [EmailAddress]
    private string emailCustomer;
    [Required]
    [Phone]
    private string phoneNumberCustomer;
    List<Purchase> purchases = new List<Purchase>();

    public Customer (string nameCustomer, string lastNameCustomer,string emailCustomer, string phoneNumberCustomer, int ageCustomer){
        this.ageCustomer = ageCustomer;
        this.emailCustomer = emailCustomer;
        this.nameCustomer = nameCustomer;
        this.lastNameCustomer = lastNameCustomer;
        this.phoneNumberCustomer = phoneNumberCustomer;
    }
    public Customer (string id,string nameCustomer, string lastNameCustomer,string emailCustomer, string phoneNumberCustomer, int ageCustomer){
        this.ageCustomer = ageCustomer;
        this.emailCustomer = emailCustomer;
        this.nameCustomer = nameCustomer;
        this.lastNameCustomer = lastNameCustomer;
        this.phoneNumberCustomer = phoneNumberCustomer;
        this.id = id;
    }

    public string getNameCustomer(){return nameCustomer;}
    public string getLastNameCustomer(){return lastNameCustomer;}
    public string getPhoneNumberCustomer(){return phoneNumberCustomer;}
    public int getAgeCustomer(){return ageCustomer;}
    public string getEmailCustomer(){return emailCustomer;}
    public void setNameCustomer(string newNameCustomer){this.nameCustomer = newNameCustomer;}
    public void setLastNameCustomer(string newLastName){this.lastNameCustomer = newLastName;}
    public void setAgeCustomer(int newAge){this.ageCustomer = newAge;}
    public void setEmailCustomer(string newEmail){this.emailCustomer = newEmail;}
    public void setPhoneNumber(string newPhoneNumber){this.phoneNumberCustomer = newPhoneNumber;}
    public void newPurchase(Purchase newPurchase) {this.purchases.Add(newPurchase);}

}