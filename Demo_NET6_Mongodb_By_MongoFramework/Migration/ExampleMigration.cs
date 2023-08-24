using MongoDB.Bson;
using MongoDB.Extensions.Migration;

public class ExampleMigration : IMigration
{
    public int Version => 2;

    public void Up(BsonDocument document)
    {
        document["LastName2"] = document["LastName"];
        document.Remove("LastName");
    }

    public void Down(BsonDocument document)
    {
        document["Name"] += " Migrated down to 0";
    }
}
