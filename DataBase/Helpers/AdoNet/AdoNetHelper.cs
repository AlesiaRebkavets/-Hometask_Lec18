using Microsoft.Data.SqlClient;

namespace DataBase;

public class AdoNetHelper : DBBaseSetupHelper
{
    // adding data to Users table
    public void AddUser(string name, int age)
    {
        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            sqlConnection.Open();
            SqlCommand command =
                new SqlCommand("INSERT INTO adonetdb.dbo.Users (Name, Age) VALUES (@name, @age)",
                    sqlConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@age", age);
            command.ExecuteNonQuery();
        }
    }

    // method returns data of the last one added user
    public User GetLastUser()
    {
        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            sqlConnection.Open();

            var command = new SqlCommand("SELECT TOP 1 * FROM adonetdb.dbo.Users ORDER BY id DESC;", sqlConnection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = (int)reader["id"],
                    Name = (string)reader["name"],
                    Age = (int)reader["age"]
                };
            }

            return null;
        }
    }

    // method deletes data from Users table
    public void ClearUsers()
    {
        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            sqlConnection.Open();
            var command = new SqlCommand("DELETE FROM adonetdb.dbo.Users;", sqlConnection);
            command.ExecuteNonQuery();
        }
    }
}