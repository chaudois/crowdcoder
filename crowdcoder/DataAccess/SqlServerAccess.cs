using System;
using crowdcoderDTO;
namespace DataAccess
{
    public class SqlServerAccess
    {
        public User GetUser(int id){
            return new User(){login="Damien",password="root"};
        }
        public User GetUserId(string login,string password){
            return new User(){login="Damien",password="root"};
        }
    }
}
