namespace SeABook.Model.DataBase
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Anntotation { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int ReadingRoomId { get; set; }
        public ReadingRoom ReadingRoom { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }

    }
}
