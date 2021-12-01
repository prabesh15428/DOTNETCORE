using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class UserDb
    {

            string connectionstring = @"server=DESKTOP-7AKSS97\MSSQLSERVER02;Integrated Security = true; database=myproject";
            public void createUser(User u)
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("addUser", con);
                
               // cmd.Parameters.AddWithValue("@id", u._id);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Mobile", u.Mobile);
            cmd.Parameters.AddWithValue("@Gender", u._gender);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
               
            }
            public List<User> GetAll()
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("select * from UserData", con);
           // cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                var dt = ds.Tables[0];
                
                
                con.Close();

                var UserList = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    var ud = new User()
                    {
                        _id = Convert.ToUInt16(row["id"]),
                        Name = row["Name"].ToString(),
                        Address = row["Address"].ToString(),
                        Email = row["Email"].ToString(),
                        Mobile = row["Mobile"].ToString(),
                        _gender = row["Gender"].ToString(),
                        Password = row["Password"].ToString()
                       
                    };
                    UserList.Add(ud);

                }
                return UserList;

            }

            public void editUser(User u)
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                SqlCommand cd = new SqlCommand("editUser", connection);
                
                cd.Parameters.AddWithValue("@id", u._id);
                cd.Parameters.AddWithValue("@Name", u.Name);
                cd.Parameters.AddWithValue("@Address", u.Address);
                cd.Parameters.AddWithValue("@Email", u.Email);
                cd.Parameters.AddWithValue("@Mobile", u.Mobile);
            cd.Parameters.AddWithValue("@Gender", u._gender);
            cd.Parameters.AddWithValue("@Password", u.Password);
            cd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cd.ExecuteNonQuery();
                connection.Close();
            }

        public List<Image> GetImgUrl()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from imageurl", connection);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];
            connection.Close();
            List<Image> urlList = new List<Image>();
            foreach (DataRow row in dt.Rows)
            {
                var users = new Image()
                {
                    id = Convert.ToUInt16(row["Customer_id"]),
                    ImageUrl = row["First_name"].ToString(),
                };
                urlList.Add(users);
            }
            return urlList;
        }

        public void AddUrl(Image objImage)
        {
            SqlConnection SqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("addurl", SqlConnection);
            cmd.Parameters.AddWithValue("@url", objImage.ImageUrl);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection.Open();
            cmd.ExecuteNonQuery();
            SqlConnection.Close();
        }
       
            public void LoginCheck(User user)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("select * from userData where [Name]=@Name and [Password]= @Password", con);
           
            // cmd.Parameters.AddWithValue("@id", u._id);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            //cmd.CommandType = CommandType.StoredProcedure;


            con.Open();
             cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
    }


