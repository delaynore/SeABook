using System.Collections.Generic;

namespace SeABook.Model.DataBase
{
    public class ReadingRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
