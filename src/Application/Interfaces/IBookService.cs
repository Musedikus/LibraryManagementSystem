using Application.Common.Models;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<ResultModel<BookDto>> CreateBookAsync(CreateBookRequest request,string userId);
        Task<ResultModel<BookDto>> GetBookByIdAsync(int id);
        Task<ResultModel<IEnumerable<BookDto>>> GetBooksAsync(BookSearchRequest request);
        Task<ResultModel<bool>> UpdateBookAsync(int id, UpdateBookRequest request);
        Task<ResultModel<string>> DeleteBookAsync(int id);
    }
}
