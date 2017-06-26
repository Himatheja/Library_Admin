namespace BusinessLayer
{
    public interface IAuthenticationBL
    {
        bool BALIsValidUser(string UserName, string Password);
    }
}
