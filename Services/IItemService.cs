using CRUD_exam.Models;

namespace CRUD_exam.Services;

public interface IItemService
{
    List<Item> GetItems();
    
    Item GetItemByName(string name);
    
    bool CreateItem(Item market);
    
    bool UpdateItem(Item market);
    
    bool DeleteItem(int id);

    List<Item> GetByOwner();
}