using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandler
{
    public class DbHandler
    {
        private const string connStr = "Server=localhost;Port=5432;User Id=postgres;Password=testpassword; Database=wowUser";

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public DbHandler() { }

        public bool Registration(string Name, string Email, string Password)
        {
            bool result = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo WHERE Email='" + Email + "'";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                if(command.ExecuteScalar() == null)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO userinfo(name, email, registrationdate, password) " +
                                                           "VALUES(@name, @email, @regdate, @password);";

                        cmd.Parameters.AddWithValue("name", Name);
                        cmd.Parameters.AddWithValue("email", Email);
                        cmd.Parameters.AddWithValue("regdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("password", Password);
                        cmd.ExecuteNonQuery();
                    }

                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        //TODO: More elegent solution for getting only one row of data.
        public DataRow GetUserData(int id)
        {
            ds.Reset();
            DataRow result;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo WHERE Id='"+ id +"'";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);


                adapter.Fill(dt);
                result = dt.Rows[0];
            }
            return result;
        }

        public DataRow[] GetAllData()
        {
            ds.Reset();
            DataRow[] result;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);

                adapter.Fill(ds);
                dt = ds.Tables[0];
                result = dt.Select();
            }
            return result;
        }
    }
}
