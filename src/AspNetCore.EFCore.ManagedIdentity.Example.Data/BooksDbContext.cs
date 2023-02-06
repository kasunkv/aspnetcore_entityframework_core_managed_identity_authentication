using AspNetCore.CRUD.Example.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AspNetCore.CRUD.Example.Data;

public class BooksDbContext : DbContext
{
	public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) {}

	public DbSet<Book> Books => Set<Book>();

	public DbSet<Author> Authors =>	Set<Author>();



	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder
			.Entity<Book>()
			.HasData(new List<Book>
			{
				new Book { Id = 1, Title = "The Phoenix Project", ISBN = "0988262592", Author = "Gean Kim"},
				new Book { Id = 2, Title = "The Unicorn Project", ISBN = "1942788762", Author = "Gean Kim"},
				new Book { Id = 3, Title = "The DevOps Handbook", ISBN = "1942788002", Author = "Gean Kim"},
			});

		builder
			.Entity<Author>()
			.HasData(new List<Author>
			{
				new Author { Id = 1, Name = "Gean Kim", Category = "DevOps"},
				new Author { Id = 2, Name = "Cory House", Category = "Frontend" }
			});
	}
}

public class ToDoDbContextFactory : IDesignTimeDbContextFactory<BooksDbContext>
{
	public BooksDbContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AspNetCore.EFCore.ManagedIdentity.Example.Web"))
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

		var connectionString = configuration.GetConnectionString(nameof(BooksDbContext));

		var dbContextOptionsBuilder = new DbContextOptionsBuilder<BooksDbContext>();
		dbContextOptionsBuilder.UseSqlServer(connectionString);

		return new BooksDbContext(dbContextOptionsBuilder.Options);
	}
}