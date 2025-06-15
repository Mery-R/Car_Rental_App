using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int Userid);
        bool IsAccess(string username);
        UserModel GetById(int Userid);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
        
    }
}
