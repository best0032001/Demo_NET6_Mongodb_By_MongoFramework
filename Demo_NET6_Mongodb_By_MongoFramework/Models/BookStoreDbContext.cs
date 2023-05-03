using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using MongoFramework;

namespace Demo_NET6_Mongodb_By_MongoFramework.Models;

public class BookStoreDbContext : MongoDbContext
{
    public BookStoreDbContext(IMongoDbConnection connection)
     : base(connection)
    {
    }
    public MongoDbSet<Book> Books { get; set; } = null!;
}
