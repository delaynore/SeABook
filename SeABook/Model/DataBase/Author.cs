using System.Collections.Generic;

namespace SeABook.Model.DataBase
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
