using Demo_NET6_Mongodb_By_MongoFramework.Extensions;
using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using MongoDB.Driver;
using MongoDB.Extensions.Migration;
using MongoFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton(_ => new MongoClient(builder.Configuration.GetConnectionString("BookStoreDbConnection")));

builder.Services.AddTransient<IMongoDbConnection>(sp =>
    MongoDbConnection.FromConnectionString(builder.Configuration.GetConnectionString("BookStoreDbConnection")));
builder.Services.AddTransient<BookStoreDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseTestMongoMigration();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
