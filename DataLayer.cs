using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Linq;
using TestWeb.Models;

namespace TestWeb.Common
{
    public class DataLayer
    {
        SqlConnection con;
        public DataLayer()
        {
            con = new SqlConnection("Data Source=LAPTOP-NCVMKQT3;Initial Catalog=School;Persist Security Info=True;User ID=sa;Password=sa");
        }

        public DataTable GetDataFromSP(string spName)
        {
            Student student = new Student();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(spName, con);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.Fill(dt);

            return dt;
        }

        public DataTable GetDataFromSP(string spName, List<SqlParameter> parameterCollection)
        {
            Student student = new Student();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterCollection.ToArray());

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            

            sqlDataAdapter.Fill(dt);

            return dt;

        }
        public DataTable UpdateFromSP(string spName,List<SqlParameter> parameterCollection)
        {

            Student student = new Student();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterCollection.ToArray());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return dt;
        }

       


    } 
}
