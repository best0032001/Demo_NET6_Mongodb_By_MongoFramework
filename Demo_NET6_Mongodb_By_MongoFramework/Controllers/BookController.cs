using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;


namespace Demo_NET6_Mongodb_By_MongoFramework.Controllers;

[Route("api")]
[ApiController]
public class BookController : ControllerBase
{
    private BookStoreDbContext _bookStoreDbContext;
    public BookController(BookStoreDbContext bookStoreDbContext)
    {
        _bookStoreDbContext = bookStoreDbContext;
    }
    [HttpGet("books")]
    public async Task<ActionResult> GetBooks()
    {
        List<Book> books = _bookStoreDbContext.Books.ToList();
        return Ok(books);
    }
    [HttpGet("books/{bookId}")]
    public async Task<ActionResult> GetBooks(String bookId)
    {
        List<Book> books = _bookStoreDbContext.Books.Where(w => w.Id == bookId).ToList();
        return Ok(books);
    }
    [HttpDelete("books/{bookId}")]
    public async Task<ActionResult> DeleteBooks(String bookId)
    {
        using (var session = _bookStoreDbContext.Connection.Client.StartSession())
        {
            session.StartTransaction();
            try
            {

                Book book = _bookStoreDbContext.Books.Where(w => w.Id == bookId).First();
                _bookStoreDbContext.Books.Remove(book);
                _bookStoreDbContext.SaveChanges();
                session.CommitTransaction();
                List<Book> books = _bookStoreDbContext.Books.ToList();
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

        using (var session = _bookStoreDbContext.Connection.Client.StartSession())
        {
            session.StartTransaction();
            try
            {
                Book bookData = _bookStoreDbContext.Books.Where(w => w.Id == bookId).First();
                _bookStoreDbContext.Books.Remove(bookData);
                _bookStoreDbContext.SaveChanges();
                _bookStoreDbContext.Books.Add(book);
                _bookStoreDbContext.SaveChanges();
                List<Book> books = _bookStoreDbContext.Books.ToList();
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
        using (var session = _bookStoreDbContext.Connection.Client.StartSession())
        {
            session.StartTransaction();
            try
            {
                _bookStoreDbContext.Books.Add(book);
                _bookStoreDbContext.Books.Add(book);
                _bookStoreDbContext.SaveChanges();
                List<Book> books = _bookStoreDbContext.Books.ToList();
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
