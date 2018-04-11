using System;
using UserService.Model;
using System.ServiceModel;
using System.Collections.Generic;

namespace UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        bool NewUser(string name, string password, string email);

        [OperationContract]
        List<User> GetAllUser();
    }
}
