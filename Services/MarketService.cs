using CRUD_exam.Models;
using Npgsql;

namespace CRUD_exam.Services;

public class MarketService : IMarketService
{

    #region CreateTable

    public static void CreateTable()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.CMarket,connection))
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
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.DMarket,connection))
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

    #region GetMarkets

    public List<Market> GetMarkets()
    {
        try
        {
            List<Market> markets = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.SelectM,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Market market = new Market();
                            market.Id = reader.GetInt32(0);
                            market.MarketName = reader.GetString(1);
                            market.Location = reader.GetString(2);
                            market.ownerId = reader.GetInt32(3);
                            
                            markets.Add(market);
                        }
                    }
                }

                return markets;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion

    #region GetMarketByName

    public Market GetMarketByName(string name)
    {
        try
        {
            Market market = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.GetByName,connection))
                {
                    command.Parameters.AddWithValue("@market_name", name);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            market.Id = reader.GetInt32(0);
                            market.MarketName = reader.GetString(1);
                            market.Location = reader.GetString(2);
                            market.ownerId = reader.GetInt32(3);
                        }

                        return market;
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
    

    #region CreateMarket

    public bool CreateMarket(Market market)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.InsertM,connection))
                {
                    command.Parameters.AddWithValue("@market_name", market.MarketName);
                    command.Parameters.AddWithValue("@location", market.Location);
                    command.Parameters.AddWithValue("@owner_id", market.ownerId);

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

    #region UpdateMakret

    public bool UpdateMarket(Market market)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.UpdateM,connection))
                {
                    command.Parameters.AddWithValue("@id", market.Id);
                    command.Parameters.AddWithValue("@market_name", market.MarketName);
                    command.Parameters.AddWithValue("@location", market.Location);
                    command.Parameters.AddWithValue("@owner_id", market.ownerId);

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


    #region DeleteMakret

    public bool DeleteMarket(int id)
    {
        try
        {
            int res = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.DeleteM,connection))
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

    #region GetMarketWithOwner

    public List<Market> GetMarketWithOwner()
    {
        try
        {
            List<Market> markets = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(OwnerService.Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(CommandsSql.SelectMales,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Market market = new Market();
                            market.Id = reader.GetInt32(0);
                            market.MarketName = reader.GetString(1);
                            market.Location = reader.GetString(2);
                            market.ownerId = reader.GetInt32(3);
                            
                            markets.Add(market);
                        }
                    }
                }

                return markets;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion
 
    
    public class CommandsSql
    {
        public const string CMarket = @"Create table if not exists markets(
                                             id serial primary key,
                                             market_name varchar not null,
                                             location varchar not null,
                                             owner_id int,
                                             Foreign key(owner_id) references owners(id)
                                                                               )";

        public const string DMarket = "Drop table if exists markets";

        public const string InsertM = "Insert into markets(market_name,location,owner_id) values (@market_name,@location,@owner_id)";

        public const string GetByName = "Select * from markets where market_name = @market_name";

        public const string UpdateM = "Update markets set market_name = @market_name,location = @location,owner_id = @owner_id where id = @id";

        public const string DeleteM = "Delete from markets where id = @id";

        public const string SelectM = "select * from markets";

        public const string SelectMales = "Select * from markets m join owners o on o.id = m.owner_id where o.gender = 'Male'";
    }
}