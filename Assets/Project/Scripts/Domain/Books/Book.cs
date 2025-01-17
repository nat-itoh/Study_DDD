using System;
using Project.Domain.Shared;

namespace Project.Domain.Books.Model {

    public sealed class Book : EntityBase<BookId, Guid>
    {

        public Book(BookId id) : base(id) {

        }
    }
}
