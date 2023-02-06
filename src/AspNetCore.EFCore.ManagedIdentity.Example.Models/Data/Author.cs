namespace AspNetCore.CRUD.Example.Models.Data;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
}
