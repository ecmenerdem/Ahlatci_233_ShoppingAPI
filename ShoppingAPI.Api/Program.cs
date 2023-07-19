using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Business.Concrete;
using ShoppingAPI.DAL.Abstract.DataManagement;
using ShoppingAPI.DAL.Concrete.EntityFramework.Context;
using ShoppingAPI.DAL.Concrete.EntityFramework.DataManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ShoppingContext>();
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IUserService, UserManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
