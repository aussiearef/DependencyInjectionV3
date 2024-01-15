using Microsoft.Extensions.DependencyInjection;

IServiceCollection collection = new ServiceCollection();
collection.AddScoped<IDataAccess, DataAccessMySQL>();
collection.AddScoped<IBusiness, Business>();
collection.AddScoped<UserInterface>();

IServiceProvider provider = collection.BuildServiceProvider();

UserInterface ui = provider.GetService<UserInterface>();
ui.Signup();

public class UserInterface
{
    private string _userName;
    private string _password;

    private IBusiness _business;

    public UserInterface(IBusiness business)
    {
        _business = business;
    }
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

        //var biz = new Business();
        _business.SignUp(_userName, _password);
    }
}

public interface IBusiness
{
    void SignUp(string userName, string password);
}
public class Business : IBusiness
{
    private IDataAccess _dataAccess;

    public Business(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public void SignUp(string userName, string password)
    {
        //var da = new DataAccessMySQL();
        _dataAccess.SignUp(userName, password);
    }
}

public interface IDataAccess
{
    void SignUp(string userName, string password);
}
public class DataAccessSqlServer : IDataAccess
{
    public void SignUp(string userName, string password)
    {
        // use EF to write data into Sql Server   
    }
}

public class DataAccessMySQL : IDataAccess
{
    public void SignUp(string userName, string password)
    {
        // use EF to write data into My SQL  
    }
}