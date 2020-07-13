using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.DataAccess
{
    class ImplementDataAccess
    {
        //Store the connection string.
        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + "\\DbDisposableCode.mdf;Integrated Security=True";

        //Initiate a new SqlConnection object, passing the connection string to the constructor.
        //Open the connection and then return the SqlConnection object to the caller.
        public static SqlConnection GetSqlConnection()
        {
            var con = new SqlConnection(ConnectionString);          //Instantiate the SqlConnection object.
            if (con.State == ConnectionState.Closed) con.Open();    //Check if the connection is closed and if it is, Open the connection.
            return con;                                             //Return the SqlConnection object to the caller.            
        }

        //Instantiate a DataTable object to store the results of a select query.
        //Instantiate a SqlDataAdapter to process the results of a select query on the database into the DataTable object.
        //Return the TableData object to the caller.
        public static DataTable GetDataTable(string SqlSelectQuery) //Pass a select query as a string
        {
            var con = GetSqlConnection();                           //Get a new SqlConnection instance.
            var table = new DataTable();                            //Instantiate the DataTable object.

            var adapter = new SqlDataAdapter(SqlSelectQuery, con);  //Instantiate a new SqlDataAdapter object, passing the select query as the first parameter and the SqlConnection object thereafter.
            adapter.Fill(table);                                    //Use the Fill method of the adapter object to populate the DataTable object with the results of the Select query.

            return table;                                           //Return the DataTable oboject to the caller.
        }

        //Instantiate a new SqlCommand, passing an SQL transaction as a string and the SqlConnection object.
        //Execute the transaction.
        public static void ExecuteSqlTransaction(string SqlTransactionText)
        {
            var con = GetSqlConnection();                           //Get a new SqlConnection instance.

            var cmd = new SqlCommand(SqlTransactionText, con);      //Instantiate the SqlCommand object
            cmd.ExecuteNonQuery();                                  //Use the ExecuteNonQuery method of the SqlCommand object to execute the transaction.
        }

        //Dispose of the SqlConnection object.
        public static void CloseDBConnection()
        {
            var con = GetSqlConnection();
            if (con.State == ConnectionState.Open) con.Close();

        }

    }
}
