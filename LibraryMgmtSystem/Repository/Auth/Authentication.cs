using DomainLayer.Models;
using System.Linq;

namespace Repository.Auth
{
    internal class Authentication : IAuthentication
    {
        public bool Authenticate(AuthModel obj)
        {
             if(StaticDatabase._adminslist.Any(m => m.Email == obj.Email && m.Password == obj.Password && m.IsActive == true)){
                     StaticDatabase._adminslist.Where(m => m.Email == obj.Email).FirstOrDefault().IsLoggedIn=true;
                     return true;
             }
             else{
                 return false;
             }
        }
    }
}