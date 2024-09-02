using CRUD_exam.Models;

namespace CRUD_exam.Services;

public interface ICustomerService
{
    List<Customer> GetCustomers();
    
    Customer GetCustomerByName(string name);
    
    bool CreateCustomer(Customer customer);
    
    bool UpdateCustomer(Customer customer);
    
    bool DeleteCustomer(int id);

    List<Customer> GetByMarketOwner();

}