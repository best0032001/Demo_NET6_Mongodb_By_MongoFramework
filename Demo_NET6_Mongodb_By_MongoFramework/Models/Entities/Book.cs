using MongoDB.Extensions.Migration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;

public class Book : IVersioned
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? LastName2 { get; set; }
    public string? Author { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
    public int Version { get; set ; }
}
