using System;
using System.Data;
using Npgsql;

namespace StorageHandler
{
    public class StorageService : IStorageService
    {
        DataTable dt;
        string connStr;

        internal StorageService()
        {
            connStr = "Server=localhost;Port=5432;User Id=postgres;Password=142536789;Database=wowUser";
            dt = new DataTable();
        }

        public DataTable GetAllData()
        {
            //DataRow[] result;
             
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);

                adapter.Fill(dt);
                //result = dt.Select();
            }
            return dt;
        }

        public DataRow GetUserData(int id)
        {
            dt.Reset();
            DataRow result;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo WHERE Id='" + id + "'";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);


                adapter.Fill(dt);
                result = dt.Rows[0];
            }
            return result;
        }

        public int LoginUser(string name, string pw)
        {
            int userId = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM userinfo WHERE Name=@name and Password=@password";

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("password", pw);
                    userId = (int)cmd.ExecuteScalar();
                }
            }
            return userId;
        }

        public bool Registration(string name, string email, string password)
        {
            bool result = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo WHERE Email='" + email + "'";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                if (command.ExecuteScalar() == null)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO userinfo(name, email, registrationdate, password) " +
                                                           "users(@name, @email, @regdate, @password);";

                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("regdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("password", password);
                        cmd.ExecuteNonQuery();
                    }

                    result = true;
                }
            }

            return result;
        }
    }
}
