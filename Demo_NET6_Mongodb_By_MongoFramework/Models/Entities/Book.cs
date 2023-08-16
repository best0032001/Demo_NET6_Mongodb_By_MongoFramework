using MongoDB.Extensions.Migration;

namespace Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;

public record Book : IVersioned
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Author { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
    public int Version { get; set ; }
}
