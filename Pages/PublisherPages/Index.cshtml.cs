using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aldescu_Sara_Lab2.Models;

namespace Aldescu_Sara_Lab2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Aldescu_Sara_Lab2Context _context;

    public IndexModel(Aldescu_Sara_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publisher = await _context.Publisher.ToListAsync();
    }
}
