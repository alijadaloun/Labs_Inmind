using System;
using System.Collections.Generic;

namespace Lab1.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public int? Isbn { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
