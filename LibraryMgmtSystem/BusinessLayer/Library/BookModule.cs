using DomainLayer.Models;
using System.Collections.Generic;

using Repo = Repository.Library;
using System;

namespace BusinessLayer.Library
{
    internal class BookModule : IBookModule
    {
        Repo.IBookModule _bookObj;

        public BookModule()
        {
            _bookObj = Repository.RepoFactory.GetBookModuleObject();
        }

        public string AddBook(BookModel bookObj)
        {
            return _bookObj.AddBook(bookObj);
        }

        public IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled = false)
        {
            return _bookObj.GetAllBooks(isIncludeDisabled);
        }
      
        public int BookAvailabilityCheck(string bookname){
            return _bookObj.BookAvailabilityCheck(bookname);
        }
        public IEnumerable<BookIssueModel> GetBookHistory(int bookid){
            return _bookObj.GetBookHistory(bookid);
        }

        public string IssueBook(BookIssueModel obj)
        {
            return _bookObj.IssueBook(obj);
        }

        public String DisableBook(int bookID)
        {
            return _bookObj.DisableBook(bookID);
        }

        public string ReturnBook(int bookid)
        {
            return _bookObj.ReturnBook(bookid);
        }
        public int LastBookID(){
            return _bookObj.LastBookID();
        }
        
        public string CurrentWorkingAdmin(){
            return _bookObj.CurrentWorkingAdmin();
        }
    }
}