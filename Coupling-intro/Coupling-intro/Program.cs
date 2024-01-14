static void Main()
{
        
}
public class UserInterface
{
    private string _userName = "";
    private string _password = "";

    private void GetData()
    {
        Console.Write("Enter user name:");
        _userName = Console.ReadLine();

        _password = Console.ReadLine();
        Console.Write("Enter password:");
    }

    public void Signup()
    {
        GetData();
        var biz = new Business();
        biz.Signup(_userName, _password);

    }
}

public class Business
{
    public void Signup(string userName, string password)
    {
        var db = new DataAccessMySQL();
        db.Signup(userName, password);
    }
}

public class DataAccessSQLServer
{
    public void Signup(string userName, string password)
    {
        // use EF to store data in SQL Server
    }
}

public class DataAccessMySQL
{
    public void Signup(string userName, string password)
    {
        // use EF to store data in My SQL
    }
}