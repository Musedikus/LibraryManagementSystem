using Application.Common.Models;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Book> _bookRepo;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookRepo = _unitOfWork.Repository<Book>();
        }

        public async Task<ResultModel<BookDto>> CreateBookAsync(CreateBookRequest request,string userId)
        {
            try
            {
                // Use repository's AnyAsync to check for existing ISBN
                if (await _bookRepo.AnyAsync(b => b.ISBN == request.ISBN))
                    return ResultModel<BookDto>.Failure("Book with this ISBN already exists.",null, 400);

                var book = new Book
                {
                    Title = request.Title,
                    Author = request.Author,
                    ISBN = request.ISBN,
                    PublishedDate = request.PublishedDate,
                    CreatedById = userId,
                    CreatedAt = DateTime.UtcNow,    
                };

                await _bookRepo.AddAsync(book);
                await _unitOfWork.SaveChangesAsync();

                var dto = new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate
                };

                return ResultModel<BookDto>.SuccessResponse(dto, "Book created successfully", 201);
            }
            catch (Exception ex)
            {
                return ResultModel<BookDto>.Failure("Unexpected error", new List<string> { ex.Message }, 500);
            }
        }


        public async Task<ResultModel<string>> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _bookRepo.GetByIdAsync(id);
                if (book == null)
                {
                    return ResultModel<string>.Failure(
                        message: "Book not found.",
                        statusCode: 404
                    );
                }

                _bookRepo.Delete(book);
                await _unitOfWork.SaveChangesAsync();

                return ResultModel<string>.SuccessResponse(
                    data: null, // or "Book deleted"
                    message: "Book deleted successfully.",
                    statusCode: 200
                );
            }
            catch (Exception ex)
            {
                return ResultModel<string>.Failure(
                    message: "An unexpected error occurred while deleting the book.",
                    errors: new List<string> { ex.Message },
                    statusCode: 500
                );
            }
        }


       public async Task<ResultModel<BookDto>> GetBookByIdAsync(int id)
       {
    try
    {
        var book = await _bookRepo.GetByIdAsync(id);
        if (book == null)
        {
            return ResultModel<BookDto>.Failure(
                message: "Book not found.",
                statusCode: 404
            );
        }

        var dto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PublishedDate = book.PublishedDate
        };

        return ResultModel<BookDto>.SuccessResponse(
            data: dto,
            message: "Book retrieved successfully.",
            statusCode: 200
        );
    }
    catch (Exception ex)
    {
        return ResultModel<BookDto>.Failure(
            message: "An unexpected error occurred while retrieving the book.",
            errors: new List<string> { ex.Message },
            statusCode: 500
        );
    }
}


        public async Task<ResultModel<IEnumerable<BookDto>>> GetBooksAsync(BookSearchRequest request)
        {
            try
            {
                var query = _bookRepo.GetAll();

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(request.Search))
                {
                    query = query.Where(b =>
                        b.Title.Contains(request.Search) ||
                        b.Author.Contains(request.Search));
                }
                var totalCount = await query.CountAsync();
                // Apply pagination
                var books = await query
                    .OrderBy(b => b.Title)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var dtos = books.Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate
                });

                return ResultModel<IEnumerable<BookDto>>.SuccessResponse(
                    data: dtos,
                    message: "Books retrieved successfully",
                    statusCode: 200,
                    totalCount : totalCount
                );
            }
            catch (Exception ex)
            {
                return ResultModel<IEnumerable<BookDto>>.Failure(
                    message: "Failed to retrieve books.",
                    errors: new List<string> { ex.Message },
                    statusCode: 500
                );
            }
        }


        public async Task<ResultModel<bool>> UpdateBookAsync(int id, UpdateBookRequest request)
        {
            try
            {
                var book = await _bookRepo.GetByIdAsync(id);
                if (book == null)
                {
                    return ResultModel<bool>.Failure($"Book with ID {id} not found.");
                }

                book.Title = request.Title ?? book.Title;
                book.Author = request.Author ?? book.Author;
                book.ISBN = request.ISBN ?? book.ISBN;
                book.PublishedDate = request.PublishedDate ?? book.PublishedDate;
                book.UpdatedAt = DateTime.UtcNow;

                _bookRepo.Update(book);
                await _unitOfWork.SaveChangesAsync();

                return ResultModel<bool>.SuccessResponse(true, "Book updated successfully.");
            }
            catch (Exception ex)
            {
                return ResultModel<bool>.Failure("An error occurred while updating the book.", new List<string> { ex.Message });
            }
        }

    }
}
