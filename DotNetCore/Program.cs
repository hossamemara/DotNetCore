using DotNetCore.ActionFilters;
using DotNetCore.ConfigurationClasses;
using DotNetCore.DI;
using DotNetCore.Middleware;
using Lamar.Microsoft.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("config.json");
// Add services to the container.
builder.Services.Configure<RateLimit>(builder.Configuration.GetSection("RateLimit"));

builder.Services.AddControllers(options =>
{
    // for global action filter registration

    options.Filters.Add<LogActivityFilter>(); 


});
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
