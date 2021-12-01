using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelFileHandling.Models
{
    public class ItemDb 
    {
        public string connectionString = @"server=DESKTOP-7AKSS97\MSSQLSERVER02;Integrated Security=true;database=item";

        public void AddItem(Item item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("additem", connection);
            //SqlCommand cmd = new SqlCommand("Insert into ItemData(ItemName, ItemRate, ItemQuantity, Discount, Amount)"+ "select @ItemName, @ItemRate, @ItemQuantity, @Discount, @Amount", connection);
           

            //cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemRate", item.ItemRate);
            cmd.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);
            cmd.Parameters.AddWithValue("@Discount", item.Discount);
            cmd.Parameters.AddWithValue("@Amount", item.Amount);
            
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Item> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
           // SqlCommand cmd = new SqlCommand("select * from ItemData", connection);
            SqlCommand cmd = new SqlCommand("getitem", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var dt = ds.Tables[0];

            connection.Close();

            var ItemList = new List<Item>();
            foreach (DataRow row in dt.Rows)
            {
                var ad = new Item()
                {
                    ItemID = Convert.ToUInt16(row["ItemID"]),
                    ItemName = row["ItemName"].ToString(),
                    ItemQuantity = Convert.ToDecimal(row["ItemQuantity"]),
                    ItemRate = Convert.ToDecimal(row["ItemRate"]),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    Discount = Convert.ToDecimal(row["Discount"])
                   

                };
                ItemList.Add(ad);
            }
            return ItemList;
        }
    }
}
