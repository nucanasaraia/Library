using BooksProject.LibraryManagement;
using BooksProject.PropertySystem;
using System.Text.RegularExpressions;

namespace BooksProject.Menu
{
    internal class AppMenu
    {
        public static void ReadBooks()
        {
            BooksLibrary booksLibrary = new BooksLibrary();
            BooksMember booksMember = new BooksMember();
            bool isRunnig = true;
            while (isRunnig)
            {
                Console.WriteLine("              ");
                Console.WriteLine("Print Books(1)" +
                "\nSearch Book(2)" +
                "\nSearch Books by Genre(3)" +
                "\nSort Books by Language(4)" +
                "\nAdd Book(5)" +
                "\nRemove Book(6)" +
                "\nEdit Book(7)" +
                "\n~~ ~~ ~~ ~~ ~~ ~~\n" +
                "Member registration(8)" +
                "\nPrint Member(9)" +
                "\nRemove member(10)" +
                "\nSearch member(11)" +
                "\nLogin(12)" +
                "\nExit(13)"); 


                Console.WriteLine("              ");
                Console.Write("Enter Number: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        booksLibrary.PrintBooks();
                        break;
                    case "2":
                        Console.Write("Enter title to search: ");
                        string searchbook = Console.ReadLine();
                        var result = booksLibrary.SearchBooks(searchbook);
                        if (result.Count == 0)
                        {
                            Console.WriteLine("No books found with the title: " + searchbook);
                        }
                        else
                        {
                            foreach (var item in result)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case "3":
                        Console.Write("Enter genre (Historical/Drama/Fiction/Phil): ");
                        string searchGenre = Console.ReadLine();
                        booksLibrary.SearchBooksByGenre(searchGenre);
                        break;
                    case "4": 
                        Console.Write("Enter language (Georgian/English): ");
                        string language = Console.ReadLine();
                        booksLibrary.SortBooksByLanguage(language);
                        break;
                    case "5":
                        BooksSystem newBook = new BooksSystem();
                        Console.Write("Enter title: ");
                        newBook.Title = Console.ReadLine();
                        Console.Write("Enter year of release: ");
                        newBook.YearOfRelease = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter director name: ");
                        newBook.Author = Console.ReadLine();
                        Console.Write("Enter genre: ");
                        newBook.Genre = Console.ReadLine();
                        Console.Write("Enter nationality: ");
                        newBook.Nationality = Console.ReadLine();
                        Console.Write("Enter Rate: ");
                        newBook.Rate = double.Parse(Console.ReadLine());
                        booksLibrary.AddBooks(newBook);
                        break;
                    case "6":
                        Console.Write("Enter the title to remove: ");
                        string removeBook = Console.ReadLine();
                        booksLibrary.RemoveBooks(removeBook);
                        break;
                    case "7":
                        BooksSystem editBook = new BooksSystem();
                        Console.Write("Enter edited title: ");
                        string editeBookTitle = Console.ReadLine();
                        Console.Write("Enter new title: ");
                        editBook.Title = Console.ReadLine();
                        Console.Write("Enter edited year of release: ");
                        editBook.YearOfRelease = int.Parse(Console.ReadLine());
                        Console.Write("Enter director name: ");
                        editBook.Author = Console.ReadLine();
                        Console.Write("Enter Rate: ");
                        editBook.Rate = double.Parse(Console.ReadLine());
                        Console.Write("Enter nationality: ");
                        editBook.Nationality = Console.ReadLine();
                        Console.Write("Enter genre: ");
                        editBook.Genre = Console.ReadLine();
                        booksLibrary.EditBooks(editeBookTitle, editBook);
                        break;
                    case "8":
                        BooksMember register = new BooksMember();
                        Console.Write("Enter name: ");
                        register.Name = Console.ReadLine();
                        Console.Write("Enter lastname: ");
                        register.LastName = Console.ReadLine();
                        register.Id++;
                        Console.Write("Enter password: ");
                        register.Password = Console.ReadLine();
                        string pattern = "@";
                        Console.Write("Enter mail: ");
                        register.Email = Console.ReadLine();
                        bool isMatch = Regex.IsMatch(register.Email, pattern);
                        register.RegistrationData = DateTime.Now;
                        if (isMatch)
                        {
                            booksMember.Registration(register);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect mail");
                        }
                        break;
                    case "9":
                        booksMember.Print();
                        break;
                    case "10":
                        Console.Write("Enter Id to remove member: ");
                        int removeMember = int.Parse(Console.ReadLine());
                        booksMember.RemoveMember(removeMember);
                        break;
                    case "11":
                        Console.Write("Enter name to search member: ");
                        string memberName = Console.ReadLine();
                        var searched = booksMember.Search(memberName);
                        foreach(var item in searched)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("user not found");
                        break;
                    case "12":
                        MemberInfo();
                        break;
                    case "13":
                         isRunnig = false;
                        Console.WriteLine("you exited");
                        break;
                    default:
                        Console.WriteLine("Wrong input enter correct!");
                        break;
                }
            }
        }
        public static void MemberInfo()
        {
            BooksMember booksMember = new BooksMember(); 
            int quantity = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Login(1) Registration(2)");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter user name: ");
                            string logName = Console.ReadLine();
                            Console.WriteLine("Enter password: ");
                            string password = Console.ReadLine();
                            quantity++;
                            Console.WriteLine(quantity);
                            if (booksMember.Login(logName, password) && quantity != 3)
                            {
                                Console.WriteLine("Logged in Successfully :)");
                                Console.WriteLine("~~ ~~ ~~ ~~ ~~ ~~");
                                ReadBooks();
                            }
                            else if (quantity == 2)
                            {
                                Console.WriteLine("Forgot password, recover your information!");
                                Console.WriteLine("************");
                                Console.Write("Enter user name: ");
                                string recoveryName = Console.ReadLine();
                                Console.Write("Enter new password: ");
                                string newPassword = Console.ReadLine();
                                booksMember.RecoveryInformation(recoveryName, new MembersSystem { Password = newPassword });
                                quantity = 0;
                            }
                            else
                            {
                                Console.WriteLine("Wrong user, try again!");
                            }
                            break;

                        case "2":
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter lastname: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string regPassword = Console.ReadLine();
                            Console.Write("Enter mail: ");
                            string email = Console.ReadLine();

                            MembersSystem newMember = new MembersSystem
                            {
                                Name = name,
                                LastName = lastName,
                                Password = regPassword,
                                Email = email,
                                RegistrationData = DateTime.Now
                            };

                            string pattern = "@";
                            bool isMatch = Regex.IsMatch(newMember.Email, pattern);
                            if (isMatch)
                            {
                                booksMember.Registration(newMember);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect mail!");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("An error occurred during user operation.");
                }
            }
        }

    }
}
