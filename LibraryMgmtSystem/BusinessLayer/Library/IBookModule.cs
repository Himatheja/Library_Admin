using DomainLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Library
{
    public interface IBookModule
    {
        string IssueBook(BookIssueModel obj);
    
        IEnumerable<BookIssueModel> GetBookHistory(int bookid);
        int BookAvailabilityCheck(string bookname);
        string ReturnBook(int bookid);

        string DisableBook(int bookid);

        string AddBook(BookModel bookObj);

        int LastBookID();

        string CurrentWorkingAdmin();

        IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled);
    }
}
