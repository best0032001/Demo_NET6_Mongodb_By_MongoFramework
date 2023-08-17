using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using MongoDB.Driver;
using MongoFramework;

namespace Demo_NET6_Mongodb_By_MongoFramework.Models;

public interface IBookContext
{
    IMongoCollection<Book> Books { get; }
}
