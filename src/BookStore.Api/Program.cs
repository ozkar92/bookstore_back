using BookStore.Persistence;
using BookStore.Repositories.Implementations;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Implementations;
using BookStore.Services.Interfaces;
using BookStore.Services.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var corsConfiguration = "BookStoreCors";
builder.Services.AddCors(setup =>
{
    setup.AddPolicy(corsConfiguration, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Registering context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});



builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(config =>
{
    //Añadir perfiles de mapeo
    config.AddProfile<BookProfile>();
    config.AddProfile<CustomerProfile>();
    config.AddProfile<OrderProfile>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(corsConfiguration);
app.MapControllers();

app.Run();
