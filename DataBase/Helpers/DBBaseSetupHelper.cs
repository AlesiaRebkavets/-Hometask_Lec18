using Microsoft.Data.SqlClient;

namespace DataBase;

// КЛАСС НЕ ЯВЛЯЕТСЯ ЧАСТЬЮ ДЗ, ТАК КАК ПО УСЛОВИЮ НЕ ВАЖНО КАК СОЗДАВАЛАСЬ БАЗА ДАННЫХ И ТАБЛИЦА
// ЭТИ МЕТОДЫ Я ПИСАЛА ДЛЯ СЕБЯ ЧТОБЫ ПОТРЕНИРОВАТЬСЯ СОЗДАВАТЬ БД И ТАКИМ СПОСОБОМ ТОЖЕ
// МЕТОДЫ НЕ ИСПОЛЬЗУЮТСЯ В ТЕСТАХ, ОСТАВИЛА ИХ ДЛЯ СЕБЯ НА БУДУЩЕЕ
public class DBBaseSetupHelper
{
    public static string ConnectionString => ConfigurationHelper.LocalDbConnectionString;

    public static void CreateConnection()
    {
        SqlConnection sqlConnection;

        using (sqlConnection = new SqlConnection(ConnectionString))
        {
            try
            {
                Console.WriteLine(sqlConnection.State);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                Console.WriteLine(sqlConnection.State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(sqlConnection.State);
    }

    // method creates new database
    public static void CreteDatabase()
    {
        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            sqlConnection.Open(); // opening connection

            SqlCommand command = new SqlCommand("CREATE DATABASE adonetdb", sqlConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Database is created");
        }
    }

    // adding new table to the database
    public static void CreateUsersTable()
    {
        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            sqlConnection.Open(); // opening connection

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "CREATE TABLE adonetdb.dbo.Users (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)";
            command.Connection = sqlConnection;
            command.ExecuteNonQuery();
            Console.WriteLine("Users table is created");
        }
    }
}