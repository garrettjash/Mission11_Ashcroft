using Microsoft.AspNetCore.Mvc;
using Mission11_Ashcroft.Models.ViewModels;
using System.Diagnostics;
using Mission11_Ashcroft.Models;

namespace Mission11_Ashcroft.Controllers
{
    public class HomeController : Controller
    {
        // access to the interface
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            // 10 items per page
            int pageSize = 10;

            var books = new BooksListViewModel
            {

                //Order the books by title
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    //new instance of PaginationInfo and be able to access the data from the PaginationInfo class
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            // pass books back to the view
            return View(books);
        }

    }
}
