using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PersonalBlog.Interface;
using PersonalBlog.Strategies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options => { options.CheckConsentNeeded = context => true; });

ConfigureServices(builder.Services);
ConfigureDataServices(builder.Services);

var app = builder.Build();

app.UseRouting().UseStaticFiles().UseCookiePolicy().UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();


void ConfigureServices(IServiceCollection builderServices)
{
    builderServices.AddControllers();
    builderServices.AddRazorPages();
    builderServices.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builderServices.AddScoped<IAuthorizer, IpBasedAuthorizer>();
    builderServices.AddScoped<ProtectorAttribute>();
    builderServices.AddLogging(c => c.AddConsole());
}

void ConfigureDataServices(IServiceCollection serviceCollection)
{
    var client = new AmazonDynamoDBClient();
    var context = new DynamoDBContext(client);
    serviceCollection.AddSingleton<IDynamoDBContext>(context);
    //serviceCollection.AddScoped<IDataService, DynanmoDbDataService>();
    serviceCollection.AddScoped<IDataService, SqlServerDataService>();
}