using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Demo_NET6_Mongodb_By_MongoFramework.Controllers;

[Route("api")]
[ApiController]
public class BookController: ControllerBase
{
    private BookStoreDbContext _bookStoreDbContext;
    public BookController(BookStoreDbContext bookStoreDbContext)
    {
        _bookStoreDbContext=bookStoreDbContext;
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
        List<Book> books = _bookStoreDbContext.Books.Where(w=>w.Id== bookId).ToList();
        return Ok(books);
    }
    [HttpDelete("books/{bookId}")]
    public async Task<ActionResult> DeleteBooks(String bookId)
    {
        List<Book> books = _bookStoreDbContext.Books.Where(w => w.Id == bookId).ToList();
        _bookStoreDbContext.Books.RemoveRange(books);
        _bookStoreDbContext.SaveChanges();
        books = _bookStoreDbContext.Books.ToList();
        return Ok(books);
    }
    [HttpPut("books/{bookId}")]
    public async Task<ActionResult> UpdateBooks(String bookId, [FromBody] Book book)
    {
        Book bookData = _bookStoreDbContext.Books.Where(w => w.Id == bookId).First();
        bookData.Name = book.Name;
        bookData.Price = book.Price;
        bookData.Category = book.Category;
        bookData.Author = book.Author;
        _bookStoreDbContext.SaveChanges();
        List<Book> books = _bookStoreDbContext.Books.ToList();
        return Ok(books);
    }

    [HttpPost("books")]
    public async Task<ActionResult> AddBooks(Book book)
    {
        _bookStoreDbContext.Books.Add(book);
        _bookStoreDbContext.SaveChanges();
        List<Book> books = _bookStoreDbContext.Books.ToList();
        return Ok(books);
    }
}
