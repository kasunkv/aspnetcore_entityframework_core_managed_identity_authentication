using AspNetCore.CRUD.Example.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.CRUD.Example.Data.Repository;

public class BooksRepository : IBooksRepository
{
    private readonly BooksDbContext _context;
    private readonly DbSet<Book> _books;


    public BooksRepository(BooksDbContext context)
    {
        _context = context;
        _books = _context.Set<Book>();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _books.ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return (await _books.SingleOrDefaultAsync(b => b.Id == id))!;
    }

    public async Task<Book> InsertAsync(Book entity)
    {
        _books.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Book> UpdateAsync(Book entity)
    {
        _books.Attach(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Book> DeleteAsync(Book entity)
    {
        _books.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Book> FindById(int id)
    {
        return (await _books.FindAsync(id))!;
    }
}
