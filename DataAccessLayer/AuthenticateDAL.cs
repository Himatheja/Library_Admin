using System;
using System.Collections.Generic;
namespace DataAccessLayer

{
    public class DALAuthenticate : IAuthenticationDAL
    {
        public bool DALIsValidUser(string UserName, string Password)
        {
            //database
            if (UserName == "Himatheja" & Password == "abcde")
            {
                return true;
            }

            return false;
        }
    }
    
}