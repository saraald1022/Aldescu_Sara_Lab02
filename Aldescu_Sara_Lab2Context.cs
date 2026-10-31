using Microsoft.EntityFrameworkCore;

public class Aldescu_Sara_Lab2Context(DbContextOptions<Aldescu_Sara_Lab2Context> options) : DbContext(options)
{
    public DbSet<Aldescu_Sara_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Aldescu_Sara_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Aldescu_Sara_Lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Aldescu_Sara_Lab2.Models.Category> Category { get; set; } = default!;
    public DbSet<Aldescu_Sara_Lab2.Models.BookCategory> BookCategory { get; set; } = default!;
}
