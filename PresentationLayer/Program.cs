using System;
using BusinessLayer;

namespace PresentationLayer
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Login");
            Console.Write("Username :");
            string UserName = Console.ReadLine();
            Console.Write("Password :");
            string Password = Console.ReadLine();

            if(Validations.IsUserNameValid(UserName)&&Validations.IsPasswordValid(Password))

            {
                IAuthenticationBL BALObj = BLFactory.GetAuthObject();

                if(BALObj.BALIsValidUser(UserName, Password))
                {
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.WriteLine("Try Again");
                    //return 0 ;
                }
            }      
        }
    }
}
