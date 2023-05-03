using Demo_NET6_Mongodb_By_MongoFramework.Models;
using MongoFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMongoDbConnection>(sp =>
    MongoDbConnection.FromConnectionString(builder.Configuration.GetConnectionString("BookStoreDbConnection")));
builder.Services.AddTransient<BookStoreDbContext>();
//https://medium.com/@TimHolzherr/writing-migrations-for-mongodb-in-c-f4ceb64e00c1
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
