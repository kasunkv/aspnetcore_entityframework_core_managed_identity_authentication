using AspNetCore.CRUD.Example.Models.Data;
using AspNetCore.CRUD.Example.Models.ViewModels;
using AutoMapper;

namespace AspNetCore.CRUD.Example.Services.Mapping;

public class BooksMappingProfile : Profile
{
    public BooksMappingProfile()
    {
        CreateMap<Book, BookViewModel>();

        CreateMap<BookViewModel, Book>();
    }

}
