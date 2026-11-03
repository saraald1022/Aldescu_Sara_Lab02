using System.Collections.Generic;
using Aldescu_Sara_Lab2.Models;

namespace Aldescu_Sara_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; } = default!;
        public IEnumerable<Book> Books { get; set; } = default!;
    }
}
