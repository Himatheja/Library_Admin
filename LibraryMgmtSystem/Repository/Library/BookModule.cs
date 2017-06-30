using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Library
{
    internal class BookModule : IBookModule
    {
        public string AddBook(BookModel bookObj)
        {
            try
            {
                StaticDatabase._booksList.Add(bookObj);

                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;
            }
        }

        public int LastBookID()
        {
            return StaticDatabase._booksList.Max(ID => ID.BookID);
        }

        public IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled)
        {
            try
            {
                if (isIncludeDisabled)
                {
                    return StaticDatabase._booksList;
                }

                return StaticDatabase._booksList.Where(m => m.IsActive == true);
            }
            catch
            {
                throw;
            }
        }

       public IEnumerable<BookIssueModel> GetBookHistory(int bookid){
           try{
               return StaticDatabase._bookHistoryList.Where(m => m.BookID == bookid);
           }
           catch{
               throw;
           }           
       }
       public int BookAvailabilityCheck(string bookname){
           try{
               if(StaticDatabase._booksList.Any(m => m.Name == bookname && m.IsAvailable == true)){
                   var matchedbooks=StaticDatabase._booksList.Where(m => m.Name == bookname && m.IsAvailable == true).Select(p=>p.BookID);
                   return matchedbooks.Count();
               }
               else{
                   return 0;
               }
           }
           catch{
               throw;
           }
       }

        public string IssueBook(BookIssueModel obj)
        {
            try
            {
                if (StaticDatabase._bookHistoryList.Any(m => m.BookID == obj.BookID && m.ReturnedAt == null))
                {
                    return StringLiterals.BookIsAssignedToUser;
                }
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == obj.BookID).FirstOrDefault();
                obj.BookName=bookObj.Name;
                MakeBookUnavailable(obj.BookID);
                StaticDatabase._bookHistoryList.Add(obj);
                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;
            }
        }

        public string DisableBook(int bookID)
        {
            try{
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == bookID).FirstOrDefault();
                bookObj.IsActive = false;
                return StringLiterals.BookRemovedMsg;
            }
            catch{
                throw;
            }
        }
        public string ReturnBook(int bookid)
        {
            try{
                BookIssueModel bookObj = StaticDatabase._bookHistoryList.Where(m => m.BookID == bookid).FirstOrDefault();
                bookObj.ReturnedAt=DateTime.Today;
                MakeBookAvailable(bookid);
                return StringLiterals.BookReturnedMsg;
            }
            catch{
                throw;
            }
            
        }


        public string CurrentWorkingAdmin()
        {
            return Convert.ToString(StaticDatabase._adminslist.Where(m => m.IsLoggedIn == true).Select(p => p.Name));
        }

        internal void MakeBookAvailable(int bookid)
        {
            try
            {
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == bookid).FirstOrDefault();
                bookObj.IsAvailable = true;
            }
            catch
            {
                throw;
            }

        }
      

        internal void MakeBookUnavailable(int bookid){
            try{
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == bookid).FirstOrDefault();
                bookObj.IsAvailable=false;
            }
            catch{
                throw;
            }
            
        }
       
    }
}
