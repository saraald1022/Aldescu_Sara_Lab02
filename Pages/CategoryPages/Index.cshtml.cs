using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aldescu_Sara_Lab2.Models;

namespace Aldescu_Sara_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Aldescu_Sara_Lab2Context _context;

    public IndexModel(Aldescu_Sara_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
