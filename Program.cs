
using CRUD_exam.Models;
using CRUD_exam.Services;

OwnerService ownerService = new OwnerService();
/*
Owner owner = new Owner();
owner.FirstName = "JJ";
owner.LastName = "Tommy";
owner.Age = 12;
owner.Gender = "Male";
owner.PhoneNumber = 765456789;
ownerService.CreatOwner(owner);

Owner owner2 = new Owner();
owner2.FirstName = "KK";
owner2.LastName = "Mark";
owner2.Age = 14;
owner2.Gender = "Male";
owner2.PhoneNumber = 984566789;
ownerService.CreatOwner(owner2);


Owner owner3 = new Owner();
owner3.FirstName = "DDD";
owner3.LastName = "Lara";
owner3.Age = 54;
owner3.Gender = "Female";
owner3.PhoneNumber = 123456789;
ownerService.CreatOwner(owner3);


Owner owner4 = new Owner();
owner4.FirstName = "ACA";
owner4.LastName = "Omaga";
owner4.Age = 32;
owner4.Gender = "Male";
owner4.PhoneNumber = 896675044;
ownerService.CreatOwner(owner4);

*/




Console.WriteLine("Get all owners: ");
var getall = ownerService.GetOwners();
foreach (var item in getall)
{
    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Gender + " " + item.PhoneNumber);
}
//
Console.WriteLine();
//

/*
Console.WriteLine("Get owner by Id: ");
var owner = ownerService.GetOwnerById(1);
Console.WriteLine(owner.Id + " " + owner.FirstName + " " + owner.LastName + " " + owner.Age + " " + owner.Gender + " " + owner.PhoneNumber);


ownerService.UpdateOwner(new Owner
{
    Id = 2,
    FirstName = "Ali",
    LastName = "Vali",
    Age = 12,
    Gender = "Male",
    PhoneNumber = 884567321
});

//
Console.WriteLine();
//

Console.WriteLine("After update: ");
var all = ownerService.GetOwners();
foreach (var item in all)
{
    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Gender + " " + item.PhoneNumber);
}

//
Console.WriteLine();
//


ownerService.DeleteOwnerById(1);

Console.WriteLine("After delete owner by Id: ");
var delete = ownerService.GetOwners();
foreach (var item in delete)
{
    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Gender + " " + item.PhoneNumber);
}


//
Console.WriteLine();
//
Console.WriteLine("Get all 'Males': ");
var males = ownerService.GetMaleOwners();
foreach (var item in males)
{
    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Gender + " " + item.PhoneNumber);
}

//
Console.WriteLine();
//


Console.WriteLine("After adding owner: ");
var getallagain = ownerService.GetOwners();
foreach (var item in getallagain)
{
    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Gender + " " + item.PhoneNumber);
}


var s = ownerService.GetMaleOwnersS();
foreach (var item in s)
{
    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Gender + " " + item.PhoneNumber);
}
*/




//////////////////////////////////Market////////////////////////////////////


MarketService marketService = new MarketService();
/*
Market market1 = new Market
{
    MarketName = "DG",
    Location = "Dushanbe , Rudaki",
    ownerId = 1
};
marketService.CreateMarket(market1);

Market market2 = new Market
{
    MarketName = "Gucci",
    Location = "Dushanbe , Center",
    ownerId = 2
};
marketService.CreateMarket(market2);


Market market3 = new Market
{
    MarketName = "Nike",
    Location = "Dushanbe , Dusti",
    ownerId = 4
};
marketService.CreateMarket(market3);


Market market4 = new Market
{
    MarketName = "Puma",
    Location = "Dushanbe , Poytakht",
    ownerId = 3
};
marketService.CreateMarket(market4);
*/

var getAll = marketService.GetMarkets();
foreach (var item in getAll)
{
    Console.WriteLine(item.Id + " " + item.MarketName + " " + item.Location + " " + item.ownerId);
}

/*
Console.WriteLine();
Console.WriteLine("Get by name: ");
var one = marketService.GetMarketByName("DG");
Console.WriteLine(one.Id + " " + one.MarketName + " " + one.Location + " " + one.ownerId);

Console.WriteLine();
Console.WriteLine("After delete: ");
marketService.DeleteMarket(3);
var getAllAgain = marketService.GetMarkets();
foreach (var item in getAllAgain)
{
    Console.WriteLine(item.Id + " " + item.MarketName + " " + item.Location + " " + item.ownerId);
}

marketService.UpdateMarket(new Market{Id = 1,MarketName = "Piano",Location = "RU",ownerId = 4});

Console.WriteLine();
Console.WriteLine("After update: ");
var getAllagain = marketService.GetMarkets();
foreach (var item in getAllagain)
{
    Console.WriteLine(item.Id + " " + item.MarketName + " " + item.Location + " " + item.ownerId);
}

Console.WriteLine();
Console.WriteLine("Male markets: ");
var males = marketService.GetMarketWithOwner();
foreach (var item in males)
{
    Console.WriteLine(item.Id + " " + item.MarketName + " " + item.Location + " " + item.ownerId);
}*/


////////////////////////////Items///////////////////////////////


ItemService itemService = new ItemService();
/*
Item item1 = new Item
{
  ItemName  = "Nike 231",
  Price = 12000,
  Amount = 4,
  market_Id = 3
};
itemService.CreateItem(item1);

Item item2 = new Item
{
    ItemName  = "Gucci JJ",
    Price = 4000,
    Amount = 8,
    market_Id = 2
};
itemService.CreateItem(item2);

Item item3 = new Item
{
    ItemName  = "Puma sport",
    Price = 8400,
    Amount = 13,
    market_Id = 4
};
itemService.CreateItem(item3);

Item item4 = new Item
{
    ItemName  = "DG scarf",
    Price = 500,
    Amount = 34,
    market_Id = 1
};
itemService.CreateItem(item4);
*/

Console.WriteLine("Get items: ");
var getItems = itemService.GetItems();
foreach (var item in getItems)
{
    Console.WriteLine(item.Id + " " + item.ItemName + " " + item.Price + " " + item.Amount + " " + item.market_Id);
}

Console.WriteLine();
Console.WriteLine("Get item higher than 10000$: ");
var ex = itemService.GetExpensives();
foreach (var item in ex)
{
    Console.WriteLine(item.Id + " " + item.ItemName + " " + item.Price + " " + item.Amount + " " + item.market_Id);
}

Console.WriteLine();
Console.WriteLine("Get by owner name: ");
var getByowner = itemService.GetByOwner();
foreach (var item in getByowner)
{
    Console.WriteLine(item.Id + " " + item.ItemName);
}


Console.WriteLine();
/////////////////////////////////////////Customers/////////////////////////////////////////////


CustomerService customerService = new CustomerService();
/*Customer customer = new Customer
{
  CustomerName = "Karim",
  Age = 32,
  PhoneNumber = 998666666,
  CustomerBalance = 16050,
  ItemAmount = 7,
  itemId = 2
};
customerService.CreateCustomer(customer);


Customer customer2 = new Customer
{
    CustomerName = "Nabi",
    Age = 18,
    PhoneNumber = 988321466,
    CustomerBalance = 6050,
    ItemAmount = 4,
    itemId = 1
};
customerService.CreateCustomer(customer2);


Customer customer3 = new Customer
{
    CustomerName = "Vova",
    Age = 54,
    PhoneNumber = 800554322,
    CustomerBalance = 1100,
    ItemAmount = 15,
    itemId = 3
};
customerService.CreateCustomer(customer3);*/


Console.WriteLine("Get all customers: ");
var getCustomers = customerService.GetCustomers();
foreach (var item in getCustomers)
{
    Console.WriteLine(item.Id + " " + item.CustomerName + " " + item.Age + " " + item.PhoneNumber + " " + item.CustomerBalance + " " + item.ItemAmount + " " + item.itemId);
}

Console.WriteLine();
Console.WriteLine("Get by market owner: ");
var groupBy = customerService.GetByMarketOwner();
foreach (var VARIABLE in groupBy)
{
    Console.WriteLine(VARIABLE.Id + " " + VARIABLE.CustomerName + " " + VARIABLE.Age + " " + VARIABLE.PhoneNumber + " " + VARIABLE.CustomerBalance + " " + VARIABLE.ItemAmount + " " + VARIABLE.itemId);
}

Console.WriteLine();
Console.WriteLine("Get by name: ");
var getOne = customerService.GetCustomerByName("Vova");
Console.WriteLine(getOne.Id + " " + getOne.CustomerName + " " + getOne.Age + " " + getOne.PhoneNumber + " " + getOne.CustomerBalance + " " + getOne.ItemAmount + " " + getOne.itemId);