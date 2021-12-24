using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BITWebApplication
{
    public class SQLHelper
    {
        private string _connectionString;



        public SQLHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["FD"].ConnectionString;

        }

        public DataTable ExecuteSQL(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            DataTable dataTable = new DataTable();

            //Here we will write code to get the details of the sql comnand and store it in dataTable.

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            if (storedProcedure == true)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i]);
                }
            }

            try
            {
                SqlDataReader results = command.ExecuteReader();
                dataTable.Load(results);
                connection.Close();
            }
            catch (SqlException ex)
            {
                connection.Close();
                throw new Exception(ex.Message);
            }
            return dataTable;
        }

        //insert,update,delete statements
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            int returnValue = -1;

            //Here we will write code to actually execute the insert,update,delete statements and whatever value those statements
            //return will be stored in the integer variable returnValue;

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            if (storedProcedure == true)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i]);
                }
            }

            try
            {
                returnValue = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {
                connection.Close();
                throw new Exception(ex.Message);
            }
            return returnValue;
        }
    }
}