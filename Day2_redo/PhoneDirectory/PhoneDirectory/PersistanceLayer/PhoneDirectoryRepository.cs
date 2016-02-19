using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public List<PhoneEntry> Search(string searchNumber, string searchName)
        {
            List<PhoneEntry> phoneEntrylist = new List<PhoneEntry>();
           
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
                    phoneEntrylist.Add(new PhoneEntry(row["Name"].ToString(), (long)Convert.ToDouble(row["Number"])));
                }
                return phoneEntrylist;
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
                catch(SqlException sqlex)
                {
                    if(sqlex.Number == 2627)
                    {
                        validation.isError = true;
                        validation.description = "This Number already prsents in the Directory";
                    }
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