using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCallJquery.Models
{
    public class ApiCallDb
    {
        public string connectionString = @"server=DESKTOP-7AKSS97\MSSQLSERVER02;Integrated Security=True;database=weather;";

        public void apiData(ApiCall objApiCall)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("adddata", sqlConnection);
            
            sqlCommand.Parameters.AddWithValue("@location", objApiCall.location);
            sqlCommand.Parameters.AddWithValue("@country", objApiCall.country);
            sqlCommand.Parameters.AddWithValue("@longitude", objApiCall.lon);
            sqlCommand.Parameters.AddWithValue("@latitude", objApiCall.lat);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }


        public List<ApiCall> getdetail()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("getdata", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];
            connection.Close();
            var dataList = new List<ApiCall>();
            foreach (DataRow row in dt.Rows)
            {
                ApiCall users = new ApiCall()
                {
                    
                    location = row["location"].ToString(),
                    country = row["country"].ToString(),
                    lat = row["latitude"].ToString(),
                    lon = row["longitude"].ToString()
                };
                dataList.Add(users);
            }

            return dataList;

        }
    }

}


    