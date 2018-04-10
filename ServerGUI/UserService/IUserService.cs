using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UserService.Model;

namespace UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUser(string name, string password);

        [OperationContract]
        void NewUser(string name, string password, string email, DateTime regDate);

        // prop Connection
    }
}
