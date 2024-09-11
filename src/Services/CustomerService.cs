using Microsoft.EntityFrameworkCore;
using Data.WingsMarketContext;
using WingsMarket.Models.CustomerModel;

namespace WingsMarket.Services.CustomerService;

public class CustomerService{
    private readonly WingsMarketContext context;
    public CustomerService(WingsMarketContext context){
        this.context = context;
    }
    public async Task<Customer?> GetCustomerById(string id){
        return await context.Customer.AsNoTracking().SingleOrDefaultAsync(p =>p.id == id);
    }
    public async Task<Customer> CreateCustomer(Customer customer){
        
        try{
            await context.Customer.AddAsync(customer);
            await context.SaveChangesAsync();
            return customer;
        }
        catch(Exception ex){
            throw new InvalidOperationException("No se pudo crear el objeto en la base de datos.", ex);
        }
    }
}