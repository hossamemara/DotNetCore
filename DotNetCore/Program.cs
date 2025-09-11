using DotNetCore.DI;
using Lamar.Microsoft.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // new
builder.Services.AddSwaggerGen(options =>
{
});

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
    app.UseSwagger();


    #endregion


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
