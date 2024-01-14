
static void Main()
{
    IDataAccess dataAccess = new DataAccessMySQL();
    IBusiness biz = new Business(dataAccess);
    
    var userInterface = new UserInterface(biz);
    userInterface.Signup();
 
}

public interface IBusiness
{
    void Signup(string userName, string password);
}

public interface IDataAccess
{
    void Signup(string userName, string password);
}

public class UserInterface
{
    private string _userName = "";
    private string _password = "";

    private readonly IBusiness _business;

    public UserInterface(IBusiness business)
    {
        _business = business;
    }
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

        _business.Signup(_userName, _password);

    }
}

public class Business : IBusiness
{
    private readonly IDataAccess _dataAccess;
    public Business(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public void Signup(string userName, string password)
    {
        _dataAccess.Signup(userName, password);
    }
}

public class DataAccessSQLServer : IDataAccess
{
    public void Signup(string userName, string password)
    {
        // use EF to store data in SQL Server
    }
}

public class DataAccessMySQL : IDataAccess
{
    public void Signup(string userName, string password)
    {
        // use EF to store data in My SQL
    }
}


