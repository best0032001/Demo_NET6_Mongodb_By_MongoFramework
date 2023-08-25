using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;

namespace Demo_NET6_Mongodb_By_MongoFramework.Repository.Interface;

public interface IBookRepository
{
    Task<List<Book>> GetBooks();

    Task<List<Book>> GetBooks(String bookId);

    Task<List<Book>> DeleteBooks(String bookId);

    Task<List<Book>> UpdateBooks(Book book);

    Task<List<Book>> AddBooks(Book book);
}
