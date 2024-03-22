namespace Mission11_Ashcroft.Models
{
    public class EFBookRepository : IBookRepository
    {
        BookstoreContext _context;
        public EFBookRepository(BookstoreContext temp)
        {
            _context = temp;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
