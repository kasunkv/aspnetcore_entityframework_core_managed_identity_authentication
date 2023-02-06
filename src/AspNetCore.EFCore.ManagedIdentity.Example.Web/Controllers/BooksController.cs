using AspNetCore.CRUD.Example.Models.ViewModels;
using AspNetCore.CRUD.Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.CRUD.Example.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _bookService;

        public BooksController(IBooksService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> Create(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var newBook = await _bookService.AddBookAsync(book);
                return View("Details", newBook);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var updatedBook = await _bookService.UpdateBookAsync(book);
                return View("Details", updatedBook);
            }
            else
            {
                return View(book);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookViewModel book)
        {
            await _bookService.DeleteBookAsync(book.Id);
            return RedirectToAction("Index");
        }
    }
}
