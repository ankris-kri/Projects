using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhoneDirectory
{
    class PhoneDirectoryRepository
    {
        public string sqlConnectionString { get; set; }
        public ErrorDto error{ get; set; }
        public PhoneDirectoryRepository()
        {
            error = new ErrorDto();
            sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        }

        public List<PhoneEntry> Search(string searchNumber, string searchName)
        {
            List<PhoneEntry> list = new List<PhoneEntry>();
           
            using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
            {
                sqlConn.Open();                   
                var _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Name like @name or number like @number", sqlConn);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@name", "%" + searchName + "%");
                _dataadapter.SelectCommand.Parameters.AddWithValue("@number", "%" + searchNumber + "%");

                var table = new DataTable();
                _dataadapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new PhoneEntry(row["Name"].ToString(),(long)Convert.ToDouble(row["Number"])));
                }
    
                return list;
            }
        }
        public ErrorDto Add(PhoneEntry phoneEntry)
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
                    error.isError = true;
                    error.description = e.ToString();
                }
                return error;
            }
        }
    }
}