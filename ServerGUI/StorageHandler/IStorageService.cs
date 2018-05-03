using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StorageHandler
{
    public interface IStorageService
    {
        bool Registration(string name, string email, string password);

        int LoginUser(string name, string pw);

        DataRow GetUserData(int id);

        DataTable GetAllData();
    }
}
