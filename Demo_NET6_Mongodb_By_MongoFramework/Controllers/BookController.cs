using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;

namespace Demo_NET6_Mongodb_By_MongoFramework.Controllers;

[Route("api")]
[ApiController]
public class BookController : ControllerBase
{
  //  private readonly BookStoreDbContext _bookStoreDbContext;
    private readonly IBookContext _bookContext;
    public BookController( IBookContext bookContext)
    {
      //  _bookStoreDbContext = bookStoreDbContext;
        _bookContext = bookContext;
    }
    [HttpGet("books")]
    public async Task<ActionResult> GetBooks()
    {
        List<Book> books = await _bookContext.Books.Find(p => true)
                            .ToListAsync();
        return Ok(books);
    }
    [HttpGet("books/{bookId}")]
    public async Task<ActionResult> GetBooks(String bookId)
    {
        List<Book> books =await _bookContext.Books.Find(w => w.Id == bookId).ToListAsync();
        return Ok(books);
    }
    [HttpDelete("books/{bookId}")]
    public async Task<ActionResult> DeleteBooks(String bookId)
    {
        FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Id, bookId);
        DeleteResult deleteResult = await _bookContext
                                                       .Books
                                                       .DeleteOneAsync(filter);
        List<Book> books = await _bookContext.Books.Find(w => w.Id == bookId).ToListAsync();
        return Ok(books);
    }
    [HttpPut("books/{bookId}")]
    public async Task<ActionResult> UpdateBooks(String bookId, [FromBody] Book book)
    {
        var updateResult = await _bookContext
                            .Books
                            .ReplaceOneAsync(filter: g => g.Id == book.Id, replacement: book);

        //Book bookData = _bookStoreDbContext.Books.Where(w => w.Id == bookId).First();
        //_bookStoreDbContext.Books.Remove(bookData);
        //_bookStoreDbContext.SaveChanges();
        //_bookStoreDbContext.Books.Add(book);
        //_bookStoreDbContext.SaveChanges();
        List<Book> books = await _bookContext.Books.Find(w => w.Id == bookId).ToListAsync();
        return Ok(books);
    }

    [HttpPost("books")]
    public async Task<ActionResult> AddBooks(Book book)
    {

        await _bookContext.Books.InsertOneAsync(book);


        List<Book> books = await _bookContext.Books.Find(w => w.Id == book.Id).ToListAsync();
        return Ok(books);
    }
}
