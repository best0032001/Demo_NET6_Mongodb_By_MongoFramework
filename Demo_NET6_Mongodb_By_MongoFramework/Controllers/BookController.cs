using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;


namespace Demo_NET6_Mongodb_By_MongoFramework.Controllers;

[Route("api")]
[ApiController]
public class BookController : ControllerBase
{
    //  private BookStoreDbContext _bookStoreDbContext;
    private readonly IBookContext _context;
    public BookController(IBookContext context)
    {
        _context = context;
    }
    [HttpGet("books")]
    public async Task<ActionResult> GetBooks()
    {
        List<Book> books = _context.Books.Find(p => true).ToList();
        return Ok(books);
    }
    [HttpGet("books/{bookId}")]
    public async Task<ActionResult> GetBooks(String bookId)
    {
        List<Book> books = _context.Books.Find(p =>p.Id==bookId).ToList();
        return Ok(books);
    }
    [HttpDelete("books/{bookId}")]
    public async Task<ActionResult> DeleteBooks(String bookId)
    {
        using (var session = _context.MongoClient.StartSession())
        {
            session.StartTransaction();
            try
            {

                FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(m => m.Id, bookId);
                DeleteResult deleteResult =  _context.Books.DeleteOne(session, filter);
                List<Book> books = _context.Books.Find(session,p => true).ToList();
                session.CommitTransaction();
                return Ok(books);
            }
            catch (Exception ex)
            {
                session.AbortTransaction();
                return BadRequest();

            }
        }

    }
    [HttpPut("books/{bookId}")]
    public async Task<ActionResult> UpdateBooks(String bookId, [FromBody] Book book)
    {

        using (var session = _context.MongoClient.StartSession())
        {
            session.StartTransaction();
            try
            {
                book.Id= bookId;
                var updateResult =  _context
                                        .Books
                                        .ReplaceOne(session,filter: g => g.Id == bookId, replacement: book);

                List<Book> books = _context.Books.Find(session,p => true).ToList();
                session.CommitTransaction();
                return Ok(books);
            }
            catch (Exception ex)
            {
                session.AbortTransaction();
                return BadRequest();
            }
        }
    }

    [HttpPost("books")]
    public async Task<ActionResult> AddBooks(Book book)
    {
        using (var session = _context.MongoClient.StartSession())
        {
            session.StartTransaction();
            try
            {
                _context.Books.InsertOne(session,book);
                List<Book> books = _context.Books.Find(session, p => true).ToList();
                session.CommitTransaction();
                return Ok(books);
            }
            catch (Exception ex)
            {
                session.AbortTransaction();
                return BadRequest();
            }
        }
    }
}
