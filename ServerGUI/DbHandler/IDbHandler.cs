using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DbHandler
{
    public interface IDbHandler
    {
        bool Registration(string name, string email, string password);

        int LoginUser(string name, string pw);

        DataRow GetUserData(int id);

        DataRow[] GetAllData();


    }
}
