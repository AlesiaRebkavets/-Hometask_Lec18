namespace DataBase;

public class EntityFrameworkHelper : DBBaseSetupHelper
{
    // adding new user to the database
    public void AddUser(User user)
    {
        using (var db = new UserContext())
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }

    // method returns data of the last one added user
    public User GetLastUser()
    {
        using (var db = new UserContext())
        {
            return db.Users.OrderByDescending(u => u.Id).FirstOrDefault();
        }
    }
}