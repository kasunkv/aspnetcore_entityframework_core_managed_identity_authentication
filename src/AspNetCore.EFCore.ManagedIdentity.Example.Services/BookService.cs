using AspNetCore.CRUD.Example.Data.Repository;
using AspNetCore.CRUD.Example.Models.Data;
using AspNetCore.CRUD.Example.Models.ViewModels;
using AutoMapper;

namespace AspNetCore.CRUD.Example.Services;

public class BookService : IBooksService
{
    private readonly IBooksRepository _booksRepository;
    private readonly IMapper _mapper;

    public BookService(IBooksRepository booksRepository, IMapper mapper)
    {
        _booksRepository = booksRepository;
        _mapper = mapper;
    }

    public async Task<List<BookViewModel>> GetAllBooksAsync()
    {
        var books = await _booksRepository.GetAllAsync();
        var results = _mapper.Map<List<Book>, List<BookViewModel>>(books);

        return results;
    }

    public async Task<BookViewModel> GetBookByIdAsync(int id)
    {
        var book = await _booksRepository.GetByIdAsync(id);
        var result = _mapper.Map<Book, BookViewModel>(book);

        return result;
    }

    public async Task<BookViewModel> AddBookAsync(BookViewModel book)
    {
        var bookEntity = _mapper.Map<Book>(book);
        var updatedBook = await _booksRepository.UpdateAsync(bookEntity);

        return _mapper.Map<BookViewModel>(updatedBook);
    }

    public async Task<BookViewModel> UpdateBookAsync(BookViewModel book)
    {
        var savedBook = await _booksRepository.FindById(book.Id);
        var toUpdateBook = _mapper.Map(book, savedBook);
        var updatedBook = await _booksRepository.UpdateAsync(toUpdateBook);

        return _mapper.Map<BookViewModel>(updatedBook);
    }

    public async Task<BookViewModel> DeleteBookAsync(int id)
    {
        var bookEntity = await _booksRepository.FindById(id);
        var deletedBook = await _booksRepository.DeleteAsync(bookEntity);

        return _mapper.Map<BookViewModel>(deletedBook);
    }
}
