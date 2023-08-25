using Demo_NET6_Mongodb_By_MongoFramework.Models;
using Demo_NET6_Mongodb_By_MongoFramework.Models.Entities;
using Demo_NET6_Mongodb_By_MongoFramework.Repository.Interface;
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
    private readonly IBookRepository _bookRepository;
    public BookController(IBookContext context,IBookRepository bookRepository)
    {
        _context = context;
        _bookRepository = bookRepository;
    }
    [HttpGet("books")]
    public async Task<ActionResult> GetBooks()
    {   
        return Ok(await _bookRepository.GetBooks());
    }
    [HttpGet("books/{bookId}")]
    public async Task<ActionResult> GetBooks(String bookId)
    {
        return Ok(await _bookRepository.GetBooks(bookId));
    }
    [HttpDelete("books/{bookId}")]
    public async Task<ActionResult> DeleteBooks(String bookId)
    {
        return Ok(await _bookRepository.DeleteBooks(bookId));

    }
    [HttpPut("books/{bookId}")]
    public async Task<ActionResult> UpdateBooks(String bookId, [FromBody] Book book)
    {
        return Ok(await _bookRepository.UpdateBooks(book));
    }

    [HttpPost("books")]
    public async Task<ActionResult> AddBooks(Book book)
    {
        return Ok(await _bookRepository.AddBooks(book));
    }
}
