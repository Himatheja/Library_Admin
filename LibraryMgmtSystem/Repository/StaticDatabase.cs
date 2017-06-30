using DomainLayer.Models;
using System.Collections.Generic;

namespace Repository
{
    internal static class StaticDatabase
    {
        internal static List<BookModel> _booksList = new List<BookModel>()
        {
            new BookModel() {  BookID=1, Name="Book1", AuthorName="Author1", Department="IT", IsActive=true ,IsAvailable=true },
            new BookModel() {  BookID=2, Name="Book2", AuthorName="Author2", Department="IT", IsActive=true ,IsAvailable=true },
            new BookModel() {  BookID=3, Name="Book3", AuthorName="Author3", Department="CSE", IsActive=false ,IsAvailable=true},
            new BookModel() {  BookID=4, Name="Book4", AuthorName="Author4", Department="IT", IsActive=true,IsAvailable=true },
            new BookModel() {  BookID=5, Name="Book5", AuthorName="Author1", Department="ECE" , IsActive=false ,IsAvailable=false }
        };

        internal static List<UserModel> _usersList = new List<UserModel>()
        {
            
            new UserModel() {  UserID=1, Name="User1", Email="User1Email", IsActive=true},
            new UserModel() {  UserID=2, Name="User2", Email="User2Email", IsActive=false},
            new UserModel() {  UserID=3, Name="User3", Email="User3Email", IsActive=true},
            new UserModel() {  UserID=4, Name="User4", Email="User4Email", IsActive=true}
        };
        internal static List<AdminModel> _adminslist=new List<AdminModel>(){
            new AdminModel() {  AdminID=1, Name="Admin", Email="Admin1", IsActive=true, Password="Pwd1", IsLoggedIn=false  },
            new AdminModel() {  AdminID=2, Name="Admin  ", Email="Admin2", IsActive=true, Password="Pwd2", IsLoggedIn=false },
            new AdminModel() {  AdminID=3, Name="Admin", Email="Admin3", IsActive=true, Password="Pwd3", IsLoggedIn=true },

        };

        internal static List<BookIssueModel> _bookHistoryList = new List<BookIssueModel>()
        {
         
        };
        

    }
}
