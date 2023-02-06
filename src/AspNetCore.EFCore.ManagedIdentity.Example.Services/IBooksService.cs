using AspNetCore.CRUD.Example.Models.ViewModels;

namespace AspNetCore.CRUD.Example.Services
{
    public interface IBooksService
    {
        Task<List<BookViewModel>> GetAllBooksAsync();

        Task<BookViewModel> GetBookByIdAsync(int id);

        Task<BookViewModel> AddBookAsync(BookViewModel book);

        Task<BookViewModel> UpdateBookAsync(BookViewModel book);

        Task<BookViewModel> DeleteBookAsync(int id);

    }
}
