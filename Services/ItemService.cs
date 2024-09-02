using CRUD_exam.Models;

namespace CRUD_exam.Services;
using Npgsql;

public class ItemService : IItemService
{

    #region CreateTable

    public static void CreateTable()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.CreateTable,connection))
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
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.DropTable, connection))
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
    
    #region GetItems
    
    public List<Item> GetItems()
    {
        try
        {
            List<Item> items = new ();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.Select,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Id = reader.GetInt32(0);
                            item.ItemName = reader.GetString(1);
                            item.Price = reader.GetInt32(2);
                            item.Amount = reader.GetInt32(3);
                            item.market_Id = reader.GetInt32(4);
                            
                            items.Add(item);
                        }
                    }
                }

                return items;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
    
    #endregion

    #region GetItemByName
    
    public Item GetItemByName(string name)
    {
        try
        {
            Item item = new Item();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.SelectByName,connection))
                {
                    command.Parameters.AddWithValue("@item_name", name);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.Id = reader.GetInt32(0);
                            item.ItemName = reader.GetString(1);
                            item.Price = reader.GetDecimal(2);
                            item.Amount = reader.GetInt32(3);
                            item.market_Id = reader.GetInt32(4);
                        }

                        return item;
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

    #region CreateItem

    public bool CreateItem(Item market)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.Insert,connection))
                {
                    command.Parameters.AddWithValue("@item_name", market.ItemName);
                    command.Parameters.AddWithValue("@price", market.Price);
                    command.Parameters.AddWithValue("@amount", market.Amount);
                    command.Parameters.AddWithValue("@market_id", market.market_Id);

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
    

    #region UpdateItem
    
        public bool UpdateItem(Item market)
        {
            try
            {
                int res = 0;
                using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.Update, connection))
                    {
                        command.Parameters.AddWithValue("@id", market.Id);
                        command.Parameters.AddWithValue("@item_name", market.ItemName);
                        command.Parameters.AddWithValue("@price", market.Price);
                        command.Parameters.AddWithValue("@amount", market.Amount);
                        command.Parameters.AddWithValue("@market_id", market.market_Id);

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

    #region DeleteItem
    public bool DeleteItem(int id)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.Delete,connection))
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

    #region SelectExpensives

    public List<Item> GetExpensives()
    {
        try
        {
            List<Item> items = new ();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.SelectExpensives,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Id = reader.GetInt32(0);
                            item.ItemName = reader.GetString(1);
                            item.Price = reader.GetInt32(2);
                            item.Amount = reader.GetInt32(3);
                            item.market_Id = reader.GetInt32(4);
                            
                            items.Add(item);
                        }
                    }
                }

                return items;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion

    #region SelectByOwner

    public  List<Item> GetByOwner()
    {
        try
        {
            List<Item> items = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(ItemCommands.SelectByOwner,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Id = reader.GetInt32(0);
                            item.ItemName = reader.GetString(1);
                            
                            items.Add(item);
                        }
                    }
                }

                return items;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion

    
    
    public class ItemCommands
    {
        public const string CreateTable = @"Create table if not exists items(
                                        id serial primary key,
                                        item_name varchar not null,
                                        price decimal ,
                                        amount int check(amount > 0),
                                        market_id int,
                                        Foreign key(market_id) references markets(id)
                                                                        )";

        public const string DropTable = "Drop table if exists items";

        public const string Insert = "Insert into items(item_name,price,amount,market_id) values (@item_name,@price,@amount,@market_id)";

        public const string Update = "Update items set item_name = @item_name,price = @price,amount = @amount,,market_id = @market_id where id = @id";

        public const string Delete = "Delete from items where id = @id";

        public const string Select = "Select * from items";

        public const string SelectByName = "Select * from items where item_name = @item_name";

        public const string SelectExpensives = "select * from items where price > 10000";

        public const string SelectByOwner = @"Select i.id,i.item_name from items i join markets m on m.id = i.market_id
                                                                                   join owners o on o.id = m.owner_id
                                                                                            where o.first_name like 'A%'";

    }
}