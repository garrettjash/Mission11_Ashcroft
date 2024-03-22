namespace Mission11_Ashcroft.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
