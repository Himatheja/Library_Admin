namespace DataAccessLayer
{
    public class DALAuthenticate : IAuthenticationDAL
    {
        public bool DALIsValidUser(string UserName, string Password)
        {
            //database
            if (UserName == "Himatheja" & Password == "Hima@470")
            {
                return true;
            }

            return false;
        }
    }
}