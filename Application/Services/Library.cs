using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Factories;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Services;

namespace LibraryManagement.Application.Services
{
    public class Library
    {
        public Library(IUIHelper ui)
        {
            Books = new List<Book>();
            Users = new List<User>();
            Loans = new List<Loan>();

            _ui = ui;
        }

        #region Properties
        public List<Book> Books { get; }
        public List<User> Users { get; }
        public List<Loan> Loans { get; }

        private IUIHelper _ui;
        #endregion


        #region Registration Books Methods
        public void RegisterBook((string bookName, string author, string isbn, int publicationYear) bookData)
        {

            Validator.ValidateBook(bookData);
            var book = BookFactory.CreateBook(bookData.bookName, bookData.author, bookData.isbn, bookData.publicationYear);

            Books.Add(book);
        }
        #endregion


        #region Registration Users Methods
        public void RegisterUser((string userName, string userEmail, string userPhone, int userOpt) userData)
        {
            Validator.ValidateUser(userData);
            var user = UserFactory.CreateUser(userData.userOpt, userData.userName, userData.userEmail, userData.userPhone);

            Users.Add(user);
        }
        #endregion


        public void MakeLoan()
        { }

        public void ProcessReturn()
        { }
    }
}
