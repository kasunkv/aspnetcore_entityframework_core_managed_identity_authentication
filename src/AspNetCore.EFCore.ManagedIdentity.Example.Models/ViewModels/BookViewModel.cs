namespace AspNetCore.CRUD.Example.Models.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public string Author { get; set; } = default!;
}
