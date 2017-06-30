using BusinessLayer;
using BusinessLayer.Auth;
using BusinessLayer.Library;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationPage :
            IAuthentication obj = BALFactory.GetAuthenticationObject();
            Console.Write("\nEnter Admin MailID:");
            string Email=Console.ReadLine();
            Console.Write("Enter Password:");
            string Password = Console.ReadLine();
            

            bool result = obj.Authenticate(new AuthModel
            {
                Email = Email,
                Password = Password
            });
            if (result)
            {
                Console.WriteLine("\nAdmin Login Successfull");
                IBookModule bookObj = BALFactory.GetBookModuleObject();
                bool logout = false ;
                do
                {
                    Console.WriteLine("1.Add new Book" +"\n2)View all Books "+ "\n3)Check book availability"+
                        "\n4)Issue a Book " + "\n5) Return Boook " + "\n6) Book Disable"+ "\n7) Book History "+"\n8)Logout");
                    Console.Write("Enter your choice:");
                    int Option = Convert.ToInt32(Console.ReadLine());
                    switch (Option)
                    {
                      
                        case 1:
                        {
                            Console.Write("Enter Book Name:");
                            string bookName = Console.ReadLine();
                            Console.Write("Enter Author Name:");
                            string authorName = Console.ReadLine();
                            Console.Write("Enter Department Name:");
                            string deptName = Console.ReadLine();
                            Console.Write("Enter no. of Copies:");
                            int bookcount=Convert.ToInt32(Console.ReadLine());
                            int lastbookid=(bookObj.LastBookID())+1;
                            for(int i=0;i<bookcount;i++,lastbookid++){
                                bookObj.AddBook(new BookModel
                                {
                                    BookID=lastbookid,
                                    Name = bookName,
                                    AuthorName = authorName,
                                    Department = deptName,
                                    IsActive = true,
                                    IsAvailable=true
                                }); 
                            }
                            break;
                        }
                        
                        case 2:
                        {
                            IEnumerable<BookModel> AllBooksList=bookObj.GetAllBooks(true);
                            Console.WriteLine("\n Entire Books in Library are ::");
                            foreach(BookModel bookitem in AllBooksList){
                                Console.WriteLine("\nBookId={0}\nBookName={1}\nAuthorName={2}\nDepartment={3}",bookitem.BookID,bookitem.Name,bookitem.AuthorName,bookitem.Department);
                            }
                            break;
                        }
                        case 3:
                        {
                            Console.Write("Enter Book name to check availability:");
                            string _bookname=Console.ReadLine();
                            int _availableBooksCount=bookObj.BookAvailabilityCheck(_bookname);
                            if(_availableBooksCount>0){
                                Console.WriteLine("Total "+_availableBooksCount+" books are available");
                            }
                            else{
                                Console.WriteLine("Currently no book is available");
                            }
                            break;
                        }
                        case 4:
                        {
                            Console.Write("Enter Book ID to issue:");
                            int IssueBookID=Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter UserID to whom you're issuing book:");
                            string UserID=Console.ReadLine();
                            DateTime? returnedAt=null;
                            bookObj.IssueBook(new BookIssueModel
                                {
                                    BookID=IssueBookID,
                                    UserID = UserID,
                                    OperationPerformedAt = DateTime.Today,
                                    ReturnedAt = returnedAt,
                                    PerformedByID = bookObj.CurrentWorkingAdmin()
                                }); 
                            break;
                        }
                        case 5:
                        {
                            Console.WriteLine("Enter returning BookID:");
                            int returningBookId=Convert.ToInt32(Console.ReadLine());
                            bookObj.ReturnBook(returningBookId);
                            break;
                        }
                        case 6:
                        {
                            Console.WriteLine("Enter BookID to disable:");
                            int disablingBookId=Convert.ToInt32(Console.ReadLine());
                            bookObj.DisableBook(disablingBookId);
                            break;
                        }
                        case 7:
                        {
                            Console.WriteLine("Enter BookId to get its history:");
                            int bookId=Convert.ToInt32(Console.ReadLine());
                            IEnumerable<BookIssueModel> BookHistoryList=bookObj.GetBookHistory(bookId);
                            int j=1;
                            foreach(BookIssueModel bookHistoryItem in BookHistoryList){
                                if(j==1){
                                    Console.WriteLine("\nBookId={0}\nBookName={1}\n\n"+j+".IssuedTo={2}\n IssuedAt={3}\n ReturnedAt={4}\n",bookHistoryItem.BookID,
                                    bookHistoryItem.BookName,bookHistoryItem.UserID,bookHistoryItem.OperationPerformedAt,bookHistoryItem.ReturnedAt);
                                    j++;
                                }
                                else{
                                    Console.WriteLine(j+".IssuedTo={0}\n IssuedAt={1}\n ReturnedAt={2}\n",bookHistoryItem.UserID,
                                    bookHistoryItem.OperationPerformedAt,bookHistoryItem);
                                    j++;
                                } 
                            }
                            break;
                        }
                       case 8:
                       {
                           Console.WriteLine("Successfully Logged out..!");
                           logout = true;
                           break;
                       }
                    }
                   //g Console.WriteLine();
                } while (!logout);
                goto AuthenticationPage;

            }
            else
            {
                Console.WriteLine("Your entered incorrect credentials try again.");
                Console.ReadKey();
            }
           
        }
    }
}
