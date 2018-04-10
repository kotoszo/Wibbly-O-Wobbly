using System;
using System.Data;

namespace UserService.Dummy
{
    public class UserFactory
    {
        public DataTable Table { get; set; }
        string[] Columns = new string[] { "Name", "Email", "Password" };

        public UserFactory()
        {
            CreateTable();
            PopulateTable();
        }

        private void PopulateTable()
        {
            string[] firstNames = new string[] { "Béla", "Mari", "Jenő", "Józsi" };
            string[] lastNames = new string[] { "Nagy", "Kis", "Lakatos", "Kovács" };
            for (int i = 0; i < firstNames.Length; i++)
            {
                DataRow row = Table.NewRow();
                row[Columns[0]] = String.Format("{0} {1}", firstNames[i], lastNames[i]);
                row[Columns[1]] = String.Format("{0} {1}{2}", firstNames[i], lastNames[i], "gmail.com");
                row[Columns[2]] = "123";
                row["RegistrationDate"] = DateTime.Now;
                Table.Rows.Add(row);
            }
        }

        private void CreateTable()
        {
            Table = new DataTable("Users");
            DataColumn id = new DataColumn("Id")
            {
                AutoIncrement = true
            };
            Table.Columns.Add(id);
            Table.PrimaryKey = new DataColumn[] { id };
            foreach (var item in Columns)
            {
                Table.Columns.Add(StringColumn(item, 50, false));
            }
            DataColumn dateCol = new DataColumn("RegistrationDate")
            {
                DataType = typeof(DateTime)
            };
            Table.Columns.Add(dateCol);
        }
        private  DataColumn StringColumn(string name, int length, bool isNullable)
        {
            return new DataColumn(name)
            {
                DataType = typeof(string),
                AllowDBNull = isNullable,
                MaxLength = length
            };
        }
    }
}
