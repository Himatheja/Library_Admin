using DataAccessLayer;

namespace BusinessLayer
{
    internal class BALAuthenticate : IAuthenticationBL
    {
        DALAuthenticate _DALObj;

        public BALAuthenticate()
        {
            _DALObj = new DALAuthenticate();
        }

        public bool BALIsValidUser(string UserName, string Password)
        {
            return _DALObj.DALIsValidUser(UserName, Password);
        }
    }
}
