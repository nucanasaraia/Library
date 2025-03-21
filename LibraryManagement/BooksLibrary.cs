using BooksProject.Interface;
using BooksProject.PropertySystem;

namespace BooksProject.LibraryManagement
{
    internal class BooksLibrary : BooksSystem, IBooks
    {
        private List<BooksSystem> Books;

        public BooksLibrary()
        {
            Books = new List<BooksSystem>()
            {
                new BooksSystem() { Title = "Data Tutashkhia", Author = "Chabua Amirejibi", Genre = "Historical", Nationality = "Georgian", Rate = 9.6, YearOfRelease = 1973 },
                new BooksSystem() { Title = "The Right Hand of the Grand Master", Author = "Konstantine Gamsakhurdia", Genre = "Historical", Nationality = "Georgian", Rate = 9.5, YearOfRelease = 1939 },
                new BooksSystem() { Title = "White Flags", Author = "Nodar Dumbadze", Genre = "Drama", Nationality = "Georgian", Rate = 9.4, YearOfRelease = 1973 },
                new BooksSystem() { Title = "Zebuloni", Author = "Jemal Karchkhadze", Genre = "Fiction", Nationality = "Georgian", Rate = 9.3, YearOfRelease = 1979 },
                new BooksSystem() { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Genre = "Phil", Nationality = "Russian", Rate = 9.5, YearOfRelease = 1866 },
                new BooksSystem() { Title = "The Stranger", Author = "Albert Camus", Genre = "Phil", Nationality = "French", Rate = 9.4, YearOfRelease = 1942 },
                new BooksSystem() { Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Genre = "Phil", Nationality = "Russian", Rate = 9.7, YearOfRelease = 1880 },
            };


        }

        public void AddBooks(BooksSystem book)
        {
            try
            {
                if (Books.Any(b => b.Title == book.Title))
                {
                    Console.WriteLine("Book already exists");
                }
                else
                {
                    Books.Add(book);
                    Console.WriteLine("Book Added Succesfully");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error Adding Book: { ex.Message} ");
            }
        }

        public void EditBooks(string title, BooksSystem UpdatedBook)
        {
            try
            {
                BooksSystem bookToEdit = Books.Find(b => b.Title == title);
                if (bookToEdit != null)
                {
                    bookToEdit.Title = UpdatedBook.Title;
                    bookToEdit.Author = UpdatedBook.Author;
                    bookToEdit.Genre = UpdatedBook.Genre;
                    bookToEdit.Nationality = UpdatedBook.Nationality;
                    bookToEdit.Rate = UpdatedBook.Rate;
                    bookToEdit.YearOfRelease = UpdatedBook.YearOfRelease;
                    Console.WriteLine("Book Edited Succesfully");
                }
                else
                {
                    Console.WriteLine("Book has not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing Book: {ex.Message}");
            }
        }

        public void PrintBooks()
        {
            foreach( var item in Books)
            {
                Console.WriteLine(item);
            }
        }

        public void RemoveBooks(string bookName)
        {
            BooksSystem remove = Books.Find(bok => bok.Title == bookName);
            try
            {
                if (remove != null)
                {
                    Books.Remove(remove);
                    Console.WriteLine("Book Removed Succesfully");
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }

        public List<BooksSystem> SearchBooks(string searchText)
        {
            return Books.Where(title => title.Title == searchText).ToList();
        }

        public void SearchBooksByGenre(string genre)
        {
            try
            {
                var genreBooks = Books.Where(book => book.Genre.ToLower() == genre.ToLower()).ToList();

                if (genreBooks.Any())
                {
                    foreach (var book in genreBooks)
                    {
                        Console.WriteLine(book);
                    }
                }
                else
                {
                    Console.WriteLine($"No books found for that genre");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }

        public void SortBooksByLanguage(string language)
        {
            try
            {
                var filteredBooks = Books.Where(book =>
                 (language.ToLower() == "georgian" && book.Nationality.ToLower() == "georgian") ||
                 (language.ToLower() == "english" &&
                 (book.Nationality.ToLower() == "russian" || book.Nationality.ToLower() == "french"))
                 ).ToList();

                if (filteredBooks.Any())
                {
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine(book);
                    }
                }
                else
                {
                    Console.WriteLine($"No books found for that language");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }


    }
}
