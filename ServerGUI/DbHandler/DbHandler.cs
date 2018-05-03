using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DbHandler
{
    public class DbHandler : IDbHandler
    {
        private readonly string connStr;

        private DataTable dt = new DataTable();
        
        public DbHandler()
        {
            //ConnectionStringSettingsCollection x = ConfigurationManager.ConnectionStrings;
            //if (x["connString"] == null)
            //{
            //    throw new Exception("Config file not found");
            //}
            //connStr = x["connString"].ConnectionString;
            connStr = "Server=localhost;Port=5432;User Id=postgres;Password=142536789;Database=wowUser";
        }

        public void CreateDb()
        {
            NpgsqlConnection _connPg = new NpgsqlConnection(connStr);

            FileInfo file = new FileInfo(@"C:\C#\00000Personal\backup\createdb");
            string script = file.OpenText().ReadToEnd();
            var m_createdb_cmd = new NpgsqlCommand(script, _connPg);
            _connPg.Open();
            m_createdb_cmd.ExecuteNonQuery();
            _connPg.Close();
        }

        public bool Registration(string name, string email, string password)
        {
            bool result = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo WHERE Email='" + email + "'";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                if(command.ExecuteScalar() == null)
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
                    userId =(int)cmd.ExecuteScalar();
                }
            }
            return userId;
        }

        //TODO: More elegent solution for getting only one row of data.
        public DataRow GetUserData(int id)
        {
            dt.Reset();
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
            dt.Reset();
            DataRow[] result;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM userinfo";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);

                adapter.Fill(dt);
                result = dt.Select();
            }
            return result;
        }
    }
}
