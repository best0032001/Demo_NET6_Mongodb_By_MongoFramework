using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using MongoDB.Extensions.Migration;
using Swashbuckle.AspNetCore.Swagger;

namespace Demo_NET6_Mongodb_By_MongoFramework.Extensions;

public static class TestMongoMigrationBuilderExtensions
{
    public static IApplicationBuilder UseTestMongoMigration(this IApplicationBuilder app)
    {
        return app.UseMongoMigration(m => m
    .ForEntity<Book>(e => e
        .AtVersion(3)
        .WithMigration(new ExampleMigration())));
    }
}
