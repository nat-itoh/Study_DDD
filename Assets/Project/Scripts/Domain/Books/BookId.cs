using System;
using Project.Domain.Shared;

namespace Project.Domain.Books.Model {

    public sealed class BookId : IdentifierBase<BookId> {

        public BookId() { }

        public BookId(Guid value) : base(value){ }
    }
}
