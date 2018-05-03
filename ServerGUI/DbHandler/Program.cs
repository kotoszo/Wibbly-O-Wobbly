using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                timer("SELECT * FROM getbikebyid(1)");
            }
            Console.WriteLine("_____________________________________");
            for (int i = 0; i < 100; i++)
            {
                timer("SELECT b.bikename, b.price, b.biketype, s.suppliername FROM bikes b INNER JOIN suppliers s ON s.id = b.supplierid WHERE b.id = 1");
            }
            //timer("SELECT * FROM getbikebyid(1)");
            //timer("SELECT b.bikename, b.price, b.biketype, s.suppliername FROM bikes b INNER JOIN suppliers s ON s.id = b.supplierid WHERE b.id = 1");

            //timer("SELECT * FROM getbikebyid(1)");
            //foreach (DataRow item in a.Rows)
            //{
            //    var b = item["name"];
            //    Console.WriteLine(b);
            //}

            Console.ReadKey();
        }

        private static void timer(string query)
        {
            string connStr = "Server=localhost;Port=5432;User Id=postgres;Password=142536789;Database=wowUser";
            DataTable a = new DataTable();

            var time = DateTime.Now;

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);

                adapter.Fill(a);
                conn.Close();
            }
            var time2 = DateTime.Now;
            Console.WriteLine(time2-time);
            foreach (DataRow item in a.Rows)
            {
                var b = item["bikename"];
                Console.WriteLine(b);
            }
        }
    }
}
