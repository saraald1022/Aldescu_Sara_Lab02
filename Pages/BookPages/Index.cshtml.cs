using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aldescu_Sara_Lab2.Models;

namespace Aldescu_Sara_Lab2.Pages.BookPages
{
    public class IndexModel : PageModel
    {
        private readonly Aldescu_Sara_Lab2Context _context;

        public IndexModel(Aldescu_Sara_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; } = default!;
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)!
                    .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();

                if (book.BookCategories != null)
                {
                    BookD.Categories = book.BookCategories.Select(s => s.Category).Cast<Category>();
                }
            }
        }
    }
}