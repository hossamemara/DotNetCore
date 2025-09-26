using DotNetCore.ActionFilters;
using DotNetCore.Authorization;
using DotNetCore.ConfigurationClasses;
using DotNetCore.DBContext;
using DotNetCore.DI;
using DotNetCore.Middleware;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("config.json");
// Add services to the container.
builder.Services.Configure<RateLimit>(builder.Configuration.GetSection("RateLimit"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwtBearer"));

var JwtConfig = builder.Configuration.GetSection("jwtBearer").Get<JwtOptions>();

builder.Services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options=>
{

    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = JwtConfig.Issuer,
        ValidateAudience = true,
        ValidAudience= JwtConfig.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SigningKey)),
    };

}
    
    );
var connectionString = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>()!;


builder.Services.AddControllers(options =>
 {
    // for global action filter registration

    options.Filters.Add<LogActivityFilter>();
    options.Filters.Add<PermissionBasedAuthorizationFilter>();


 });

if (connectionString.DataBaseType == "MongoDb")
{
    builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(connectionString.MongoDb));

    builder.Services.AddDbContext<ApplicationDBContext>((sp, options) =>
    {
        var client = sp.GetRequiredService<IMongoClient>();
        var dbName = connectionString.MongoDatabaseName!;
        options.UseMongoDB(client, dbName);
    });
}
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // new
builder.Services.AddSwaggerGen();

builder.Host.UseLamar((context, registry) =>
{
    // register services using Lamar
    registry.IncludeRegistry<DIRegistry>();
});

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())  // for security wise
{
    //  middleware

    #region middlewares

    app.MapOpenApi(); // new 
    app.UseSwagger();
    app.UseSwaggerUI();


    #endregion


}



//  Middleware & action filter   https://chatgpt.com/share/e/68c53a88-bc5c-8001-9be6-80686b688b98 
app.UseMiddleware<ProfilingMiddleware>();
app.UseMiddleware<RateLimitMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
