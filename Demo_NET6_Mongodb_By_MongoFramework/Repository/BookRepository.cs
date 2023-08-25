using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using Demo_NET6_Mongodb_By_MongoFramework.Repository.Interface;
using MongoDB.Driver;
using System.Net;

namespace Demo_NET6_Mongodb_By_MongoFramework.Repository;

public class BookRepository : IBookRepository
{
    private readonly IBookContext _context;
    public BookRepository(IBookContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> AddBooks(Book book)
    {
        using (var session = _context.MongoClient.StartSession())
        {
            session.StartTransaction();
            try
            {
                _context.Books.InsertOne(session, book);
                List<Book> books = _context.Books.Find(session, p => true).ToList();
                session.CommitTransaction();
                return books;
            }
            catch (Exception ex)
            {
                session.AbortTransaction();
                throw new Exception(ex.Message);
            }
        }
    }

    public async Task<List<Book>> DeleteBooks(string bookId)
    {
        using (var session = _context.MongoClient.StartSession())
        {
            session.StartTransaction();
            try
            {
                FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(m => m.Id, bookId);
                DeleteResult deleteResult = _context.Books.DeleteOne(session, filter);
                List<Book> books = _context.Books.Find(session, p => true).ToList();
                session.CommitTransaction();
                return books;
            }
            catch (Exception ex)
            {
                session.AbortTransaction();
                throw new Exception(ex.Message);
            }
        }
    }

    public async Task<List<Book>> GetBooks()
    {
        List<Book> books = _context.Books.Find(p => true).ToList();
        return books;
    }

    public async Task<List<Book>> GetBooks(string bookId)
    {
        List<Book> books = _context.Books.Find(p => p.Id == bookId).ToList();
        return books;
    }

    public async Task<List<Book>> UpdateBooks(Book book)
    {
        using (var session = _context.MongoClient.StartSession())
        {
            session.StartTransaction();
            try
            {
                ReplaceOneResult updateResult = _context
                                     .Books
                                     .ReplaceOne(session, filter: g => g.Id == book.Id, replacement: book);
                List<Book> books = _context.Books.Find(session, p => true).ToList();
                session.CommitTransaction();
                return books;
            }
            catch (Exception ex)
            {
                session.AbortTransaction();
                throw new Exception(ex.Message);
            }
        }
    }
}
