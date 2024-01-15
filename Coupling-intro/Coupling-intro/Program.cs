public class UserInterface
{
    private string _userName;
    private string _password;

    private void GetData()
    {
        Console.Write("Enter user name:");
        _userName = Console.ReadLine();
        
        Console.Write("Enter password:");
        _password = Console.ReadLine();
    }

    public void Signup()
    {
        GetData();

        var biz = new Business();
        biz.SignUp(_userName, _password);
    }
}

public class Business
{
    public void SignUp(string userName, string password)
    {
        var da = new DataAccessMySQL();
        da.SignUp(userName, password);
    }
}

public class DataAccessSqlServer
{
    public void SignUp(string userName, string password)
    {
        // use EF to write data into Sql Server   
    }
}

public class DataAccessMySQL
{
    public void SignUp(string userName, string password)
    {
        // use EF to write data into My SQL  
    }
}