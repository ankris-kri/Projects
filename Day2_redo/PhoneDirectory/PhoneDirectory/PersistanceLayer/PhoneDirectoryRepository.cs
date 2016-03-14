using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PhoneDirectory
{
    class PhoneDirectoryRepository
    {
        public string sqlConnectionString { get; set; }
        public ErrorValidation validation { get; set; }

        public PhoneDirectoryRepository()
        {
            validation = new ErrorValidation();
            sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        }

        public List<PhoneEntry> Search(string searchBy,string searchName,string searchNumber=null)
        {
            var phoneEntrylist = new List<PhoneEntry>();
            string BaseQuery="select * from PhoneDirectory";
            string searchQuery;

            using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
            {
                sqlConn.Open();                 
                if (searchBy=="Number")
                    searchQuery=BaseQuery+" "+"where Name like @name or Number like @number";
                else
                    searchQuery = BaseQuery + " " + "where Name like @name";

                var _dataadapter = new SqlDataAdapter(searchQuery, sqlConn);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@name", "%" + searchName + "%");
                _dataadapter.SelectCommand.Parameters.AddWithValue("@number", "%" + searchNumber + "%");

                var table = new DataTable();
                _dataadapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    phoneEntrylist.Add(new PhoneEntry(row["Name"].ToString(), (long)Convert.ToDouble(row["Number"])));
                }
          
                var orderedList =phoneEntrylist.OrderBy(x => x.name).ToList();
                return orderedList;
            }
        }
        public ErrorValidation Add(PhoneEntry phoneEntry)
        {
            using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
            {
                try
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand("Insert into PhoneDirectory values(@name,@phone)");
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("@name", phoneEntry.name);
                    cmd.Parameters.AddWithValue("@phone", phoneEntry.number);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    validation.isError = true;
                    validation.description = e.ToString();
                }
                return validation;
            }
        }
    }
}