using MongoDB.Bson;
using MongoDB.Extensions.Migration;

public class ExampleMigration : IMigration
{
    public int Version => 3;

    public void Up(BsonDocument document)
    {
        document["LastName"] = "-";
    }

    public void Down(BsonDocument document)
    {
        document["Name"] += " Migrated down to 0";
    }
}
