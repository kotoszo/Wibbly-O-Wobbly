using System;
using UserService.Model;
using System.ServiceModel;

namespace UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUser(string name, string password);

        [OperationContract]
        bool NewUser(string name, string password, string email);

        // prop Connection
    }
}
