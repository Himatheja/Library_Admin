using DomainLayer.Models;
using System.Collections.Generic;

namespace Repository.Library
{
    public interface IBookModule
    {
        string IssueBook(BookIssueModel obj);


        IEnumerable<BookIssueModel> GetBookHistory(int bookid);

        int BookAvailabilityCheck(string bookname);

        string ReturnBook(int bookId);

        string AddBook(BookModel bookObj);

        string DisableBook(int bookId);

        int LastBookID();

        string CurrentWorkingAdmin();

        IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled);
    }
}
