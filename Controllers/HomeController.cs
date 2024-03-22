using Microsoft.AspNetCore.Mvc;
using Mission11_Ashcroft.Models.ViewModels;
using System.Diagnostics;
using Mission11_Ashcroft.Models;

namespace Mission11_Ashcroft.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {

            int pageSize = 10;

            var books = new BooksListViewModel
            {


                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };


            return View(books);
        }

    }
}
