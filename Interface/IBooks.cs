using BooksProject.LibraryManagement;
using BooksProject.PropertySystem;

namespace BooksProject.Interface
{
    internal interface IBooks
    {
        void PrintBooks();
        List<BooksSystem> SearchBooks(string searchText);
        void SearchBooksByGenre(string genre);
        void SortBooksByLanguage(string language);
        void AddBooks(BooksSystem book);
        void RemoveBooks(string bookName);
        void EditBooks(string title, BooksSystem UpdatedBook);

    }
}
