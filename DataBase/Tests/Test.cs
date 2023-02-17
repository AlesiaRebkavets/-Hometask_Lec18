using NUnit.Framework;

namespace DataBase.Tests;

public class Test
{
    [Test]
    public void TestWithAdoNetHelper()
    {
        var helper = new AdoNetHelper();
        var name = "Ann";
        var age = 15;
        helper.AddUser(name, age); // adding a new record
        var user = helper.GetLastUser(); // getting data of the last one record

        // verifying that user is created and the fields' values are correct
        Assert.NotNull(user);
        Assert.AreEqual(name, user.Name);
        Assert.AreEqual(age, user.Age);

        // deleting data from 'Users' table
        helper.ClearUsers();
    }

    [Test]
    public void TestWithEntityFrameworkHelper()
    {
        var helper = new EntityFrameworkHelper();
        var user = new User { Name = "John Doe", Age = 30 };
        helper.AddUser(user); // adding a new record

        var lastUser = helper.GetLastUser(); // getting data of the last one record

        // verifying that the fields' values are correct
        Assert.AreEqual(user.Name, lastUser.Name);
        Assert.AreEqual(user.Age, lastUser.Age);
    }
}