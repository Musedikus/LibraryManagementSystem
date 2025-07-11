using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Create a new book.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
             var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Forbid();
            }
            var result = await _bookService.CreateBookAsync(request,userId);
            return Ok(result);
        }

        /// <summary>
        /// Get a book by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get all books with optional search, paging.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] BookSearchRequest request)
        {
            var result = await _bookService.GetBooksAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Update a book by its ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            var result = await _bookService.UpdateBookAsync(id, request);
            return Ok(result);
        }

        /// <summary>
        /// Delete a book by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            return Ok(result);
        }
    }
}
