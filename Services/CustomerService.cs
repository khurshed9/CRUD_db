using CRUD_exam.Models;

namespace CRUD_exam.Services;
using Npgsql;

public class CustomerService : ICustomerService
{
    #region CreateTable

    public static void CreateTable()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.CreateTable,connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    #endregion

    #region DropTable

    public static void DropTable()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.DropTable,connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    #endregion


    #region GetCustomers

    public List<Customer> GetCustomers()
    {
        try
        {
            List<Customer> customers = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.Select,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.Id = reader.GetInt32(0);
                            customer.CustomerName = reader.GetString(1);
                            customer.Age = reader.GetInt32(2);
                            customer.PhoneNumber = reader.GetInt32(3);
                            customer.CustomerBalance = reader.GetDecimal(4);
                            customer.ItemAmount = reader.GetInt32(5);
                            customer.itemId = reader.GetInt32(6);
                            
                            customers.Add(customer);
                        }
                    }
                }

                return customers;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion
   

    #region GetCustomerByName

    public Customer GetCustomerByName(string name)
    {
        try
        {
            Customer customer = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.SelectByName,connection))
                {
                    command.Parameters.AddWithValue("@customer_name", name);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.Id = reader.GetInt32(0);
                            customer.CustomerName = reader.GetString(1);
                            customer.Age = reader.GetInt32(2);
                            customer.PhoneNumber = reader.GetInt32(3);
                            customer.CustomerBalance = reader.GetDecimal(4);
                            customer.ItemAmount = reader.GetInt32(5);
                            customer.itemId = reader.GetInt32(6);
                        }

                        return customer;
                    }
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion
    

    #region CreateCustomer

    public bool CreateCustomer(Customer customer)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.Insert,connection))
                {
                    command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                    command.Parameters.AddWithValue("@age", customer.Age);
                    command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@customer_balance", customer.CustomerBalance);
                    command.Parameters.AddWithValue("@item_amount", customer.ItemAmount);
                    command.Parameters.AddWithValue("@item_id", customer.itemId);

                    res = command.ExecuteNonQuery();
                }

                return res > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    #endregion

    #region UpdateCustomer

    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.Update,connection))
                {
                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                    command.Parameters.AddWithValue("@age", customer.Age);
                    command.Parameters.AddWithValue("@customer_balance", customer.CustomerBalance);
                    command.Parameters.AddWithValue("@item_amount", customer.ItemAmount);
                    command.Parameters.AddWithValue("@item_id", customer.itemId);

                    res = command.ExecuteNonQuery();
                }

                return res > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    #endregion


    #region DeleteCustomer

    public bool DeleteCustomer(int id)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.Delete,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    res = command.ExecuteNonQuery();
                }

                return res > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    #endregion

    #region SelectByMarketOwner

    public List<Customer> GetByMarketOwner()
    {
        try
        {
            List<Customer> customers = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CustomerCommands.SelectByMarketOwner,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.Id = reader.GetInt32(0);
                            customer.CustomerName = reader.GetString(1);
                            customer.Age = reader.GetInt32(2);
                            customer.PhoneNumber = reader.GetInt32(3);
                            customer.CustomerBalance = reader.GetDecimal(4);
                            customer.ItemAmount = reader.GetInt32(5);
                            customer.itemId = reader.GetInt32(6);
                            
                            customers.Add(customer);
                        }
                    }
                }

                return customers;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion
    
    
    
    
    
    public class CustomerCommands
    {
        public const string CreateTable = @"Create table if not exists customers(
                                            id serial primary key,
                                            customer_name varchar not null,
                                            age int check(age > 0),
                                            phone_number int ,
                                            customer_balance decimal ,
                                            item_amount int check(item_amount > 0),
                                            item_id int,
                                            Foreign key(item_id) references items(id)  
                                                                                )";

        public const string DropTable = "Drop table if exists customers";

        public const string Insert = "Insert into customers(customer_name,age,phone_number,customer_balance,item_amount,item_id) values (@customer_name,@age,@phone_number,@customer_balance,@item_amount,@item_id)";

        public const string Update = "Update customers set customer_name = @customer_name, age = @age, phone_number = @phone_number,customer_balance = @customer_balance, item_amount = @customer_amount,item_id = @item_id";

        public const string Delete = "Delete from customers where id = @id";

        public const string Select = "Select * from customers";

        public const string SelectByName = "Select * from customers where customer_name = @customer_name limit 1";

        public const string SelectByMarketOwner = "Select * from customers c join items i on i.id = c.item_id join markets m on m.id = i.market_id join owners o on o.id = m.owner_id where o.age > 25";
    }
}