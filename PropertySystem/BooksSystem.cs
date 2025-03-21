namespace BooksProject.PropertySystem
{
    internal class BooksSystem
    {
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public string Author { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }
        public double Rate { get; set; }

        public override string ToString()
        {
            return $"Name: {Title}, Year: {YearOfRelease}, Author: {Author}, Nationality: {Nationality}, Genre: {Genre}, Rate: {Rate}";
        }
    }
}
