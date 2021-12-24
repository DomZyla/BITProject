using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class SQLHelper
    {
        private string _connectionString;

        private static readonly log4net.ILog log4netLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SQLHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["FD"].ConnectionString;
            log4net.Config.XmlConfigurator.Configure();
        }

        //sql="select * from customers";
        //or
        //sql="spGetCustomers"
        //select statements executing
        public DataTable ExecuteSQL(string sql, SqlParameter[] parameters=null,bool storedProcedure=false)
        {
            log4netLogger.Info(DateTime.Now + "[INFO] This is ExecuteSql method and the sql is " + sql);

            DataTable dataTable = new DataTable();

            //Here we will write code to get the details of the sql command and store it in dataTable.

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            if (storedProcedure==true)
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
            catch(SqlException ex)
            {
                log4netLogger.Error(DateTime.Now + "[Error] inside SQLHelper.cs - ExecuteSQL() " + ex.Message);

                connection.Close();
                throw new Exception(ex.Message);
            }

                return dataTable;
        }

        //insert, update, delete statements


        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            string message = DateTime.Now + " [ Info ] Executing the sql statement :" + sql;
            LogHelper.Log(LogTarget.File, message);

            int returnValue = -1;

            //Here we will write code to execute the insert, update, delete statements and the value those statements return will be stored in the integer variable returnValue.

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
                message = DateTime.Now + " [ Error ] " + ex.Message;
                LogHelper.Log(LogTarget.File, message);
                
                connection.Close();
                throw new Exception(ex.Message);
            }

            return returnValue;
        }
    }
}