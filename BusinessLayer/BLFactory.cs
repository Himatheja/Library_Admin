namespace BusinessLayer
{
    public static class BLFactory
    {
        public static IAuthenticationBL GetAuthObject()
        {
            return new BALAuthenticate();
        }
    }
}