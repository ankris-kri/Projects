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
    class Repository
    {

        Result result = new Result();
        Error error = new Error();
        string sql = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public Result SearchAll()
        {
            using (SqlConnection sq = new SqlConnection(sql))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("SELECT * FROM PhoneDirectory", sq);
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.value = t;
                return result;
            }
        }
        public Result SearchByName(String _name)
        {
            using (SqlConnection sq = new SqlConnection(sql))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Name like @phone", sq);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@phone", "%" + _name + "%");
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.value = t;
                return result;
            }
        }
        public Result SearchByNumber(int _number)
        {
            using (SqlConnection sq = new SqlConnection(sql))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Number like @phone", sq);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@phone", "%" + _number + "%");
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.value = t;
                return result;
            }
        }
        public Error Add(PhoneDirectory phonedirectory)
        {
            try
            {
                using (SqlConnection sq = new SqlConnection(sql))
                {
                    sq.Open();
                    var cmd = new SqlCommand("Insert into PhoneDirectory values(@name,@phone)");
                    cmd.Connection = sq;
                    cmd.Parameters.AddWithValue("@name", phonedirectory.name);
                    cmd.Parameters.AddWithValue("@phone", phonedirectory.number);
                    cmd.ExecuteNonQuery();
                    error.iserror = false;
                    return error;
                }
            }
            catch (Exception e)
            {
                error.iserror = true;
                error.description = e.ToString();
                return error;
            }
        }
    }
}
