using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace PhoneDirectory
{
    class PhoneDirectoryRepository
    {
        PhoneEntryDto result = new PhoneEntryDto();
        ErrorDto error = new ErrorDto();
        string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        /*
        public PhoneEntryDto Search(string input)
        {
            using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
            {
                sqlConn.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Name like @input or Number like @input", sqlConn);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@input", "%" + input + "%");
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.Table = t;
                return result;
            }
        }
        */
        public List<PhoneEntry> Search(string input)
        {
            List<PhoneEntry> list = new List<PhoneEntry>();
            using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
            {
                sqlConn.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Name like @input or Number like @input", sqlConn);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@input", "%" + input + "%");
                DataTable table = new DataTable();
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
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand("Insert into PhoneDirectory values(@name,@phone)");
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("@name", phoneEntry.name);
                    cmd.Parameters.AddWithValue("@phone", phoneEntry.number);
                    cmd.ExecuteNonQuery();
                    error.isError = false;
                    return error;
                }
            }
            catch (Exception e)
            {
                error.isError = true;
                error.description = e.ToString();
                return error;
            }
        }
    }
}