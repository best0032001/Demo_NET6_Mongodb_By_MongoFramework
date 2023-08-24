using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using MongoDB.Driver;

namespace Demo_NET6_Mongodb_By_MongoFramework.Models;

public class BookContext : IBookContext
{
    public BookContext(IConfiguration configuration)
    {
        MongoClient = new MongoClient(configuration.GetConnectionString("BookStoreDbConnection"));
        var database = MongoClient.GetDatabase(configuration.GetConnectionString("DatabaseName"));

        Books = database.GetCollection<Book>("Book");
    }
    public MongoClient MongoClient { get; set; }
    public IMongoCollection<Book> Books { get; }
}
