using CRUD_exam.Models;
using Npgsql;

namespace CRUD_exam.Services;

public class OwnerService : IOwnerService
{

    #region CreateDatabase

    public static void CreateDatabase()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.DefaultConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.CreatDatabase,connection))
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

    #region DropDatabase

    public static void DropDatabase()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.DefaultConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.DropDatabase,connection))
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

    #region CreateTable

    public static void CreateTable()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.CreateTable,connection))
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
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand commmand = new NpgsqlCommand(Commands.DropTable,connection))
                {
                    commmand.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion


    #region GetOwners

    public List<Owner> GetOwners()
    {
        try
        {
            List<Owner> owners = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.Select,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Owner owner = new Owner();
                            owner.Id = reader.GetInt32(0);
                            owner.FirstName = reader.GetString(1);
                            owner.LastName = reader.GetString(2);
                            owner.Age = reader.GetInt32(3);
                            owner.Gender = reader.GetString(4);
                            owner.PhoneNumber = reader.GetInt32(5);
                            
                            owners.Add(owner);
                        }
                    }
                }

                return owners;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion


    #region GetOwnerById

    
    public Owner GetOwnerById(int id)
    {
        try
        {
            Owner owner = new Owner();
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.GetById,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            owner.Id = reader.GetInt32(0);
                            owner.FirstName = reader.GetString(1);
                            owner.LastName = reader.GetString(2);
                            owner.Age = reader.GetInt32(3);
                            owner.Gender = reader.GetString(4);
                            owner.PhoneNumber = reader.GetInt32(5);
                        }

                        return owner;
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


    #region CreateOwner

    public bool CreatOwner(Owner owner)
    {
        try
        {
            int result = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.Insert,connection))
                {
                    command.Parameters.AddWithValue("@first_name", owner.FirstName);
                    command.Parameters.AddWithValue("@last_name", owner.LastName);
                    command.Parameters.AddWithValue("@age", owner.Age);
                    command.Parameters.AddWithValue("@gender", owner.Gender);
                    command.Parameters.AddWithValue("@phone_number", owner.PhoneNumber);

                    result = command.ExecuteNonQuery();
                }
            }

            return result > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    #endregion


    #region UpdateOwner

    
    public bool UpdateOwner(Owner owner)
    {
        try
        {
            int result = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.Update,connection))
                {
                    command.Parameters.AddWithValue("@id", owner.Id);
                    command.Parameters.AddWithValue("@first_name", owner.FirstName);
                    command.Parameters.AddWithValue("@last_name", owner.LastName);
                    command.Parameters.AddWithValue("@age", owner.Age);
                    command.Parameters.AddWithValue("@gender", owner.Gender);

                    result = command.ExecuteNonQuery();
                }
                return result > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    #endregion


    #region DeleteOwnerById

    public bool DeleteOwnerById(int id)
    {
        try
        {
            int result = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.Delete,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    result = command.ExecuteNonQuery();
                }

                return result > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    #endregion

    #region GetMaleOwners

    public List<Owner> GetMaleOwners()
    {
        try
        {
            List<Owner> owners = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.SelectMales,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Owner owner = new Owner();
                            owner.Id = reader.GetInt32(0);
                            owner.FirstName = reader.GetString(1);
                            owner.LastName = reader.GetString(2);
                            owner.Age = reader.GetInt32(3);
                            owner.Gender = reader.GetString(4);
                            owner.PhoneNumber = reader.GetInt32(5);
                            
                            owners.Add(owner);
                        }
                    }
                }

                return owners;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion

    #region GetMaleOwnersS

    public List<Owner> GetMaleOwnersS()
    {
        try
        {
            List<Owner> owners = new();
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Commands.SelectOwnersWithFistName,connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Owner owner = new Owner();
                            owner.Id = reader.GetInt32(0);
                            owner.FirstName = reader.GetString(1);
                            owner.LastName = reader.GetString(2);
                            owner.Age = reader.GetInt32(3);
                            owner.Gender = reader.GetString(4);
                            owner.PhoneNumber = reader.GetInt32(5);
                            
                            owners.Add(owner);
                        }
                    }
                }

                return owners;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    #endregion
    
    
    
    public class Commands
    {
        public const string DefaultConnectionString =
            "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=Galchaew05;";

        public const string ConnectionString =
            "Server=localhost;Port=5432;Database=trading_db;Username=postgres;Password=Galchaew05;";

        public const string CreatDatabase = "Create database trading_db";

        public const string DropDatabase = "Drop database trading_db with(force)";

        public const string CreateTable = @"Create table if not exists owners(
                                            id serial primary key,
                                            first_name varchar not null,
                                            last_name varchar not null,
                                            age int check(age > 0),
                                            gender varchar not null,
                                            phone_number int unique
                                                                            )";

        public const string DropTable = "Drop table if exists owners";

        public const string Insert = @"Insert into owners(first_name,last_name,age,gender,phone_number) 
                                       values(@first_name,@last_name,@age,@gender,@phone_number)";

        public const string GetById = "Select * from owners where id = @id";

        public const string Update = @"Update owners set first_name = @first_name,last_name = @last_name,
                                                         age = @age,gender = @gender,phone_number = @phone_number where id = @id";

        public const string Delete = "Delete from owners where id = @id";
        
        public const string Select = "Select * from owners";

        public const string SelectOwnersWithFistName = "select * from owners where first_name like 'S%'";

        public const string SelectMales = "Select * from owners where gender = 'Male'";
    }
}