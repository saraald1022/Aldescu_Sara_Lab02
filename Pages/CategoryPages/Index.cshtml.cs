using Aldescu_Sara_Lab2.Models;
using Aldescu_Sara_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aldescu_Sara_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Aldescu_Sara_Lab2Context _context;

    public IndexModel(Aldescu_Sara_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;
    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryIndexData();
        CategoryData.Categories = await _context.Category
            .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author)
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;
            var category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
            CategoryData.Books = category.BookCategories
                .Select(s => s.Book);
        }
    }
}
