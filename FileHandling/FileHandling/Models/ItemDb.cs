using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandling.Models
{
    public class ItemDb
    {
        public string connectionString = @"server=DESKTOP-7AKSS97\MSSQLSERVER02;Integrated Security=true;database=ItemDB";

        public void AddItem(Item item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("addItem", connection);
            //SqlCommand cmd = new SqlCommand("Insert into ItemData(ItemName, ItemRate, ItemQuantity, Discount, Amount)"+ "select @ItemName, @ItemRate, @ItemQuantity, @Discount, @Amount", connection);
         

        //cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
        cmd.Parameters.AddWithValue("@name", item.item_name);
            cmd.Parameters.AddWithValue("@quantity", item.item_quantity);
            cmd.Parameters.AddWithValue("@amount", item.item_amount);
            cmd.Parameters.AddWithValue("@discount", item.item_discount);
            cmd.Parameters.AddWithValue("@rate", item.item_rate);

            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Item> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            // SqlCommand cmd = new SqlCommand("select * from ItemData", connection);
            SqlCommand cmd = new SqlCommand("getItems", connection);
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
                    id = Convert.ToUInt16(row["id"]),
                    item_name = row["item_name"].ToString(),
                    item_quantity = Convert.ToDecimal(row["item_quantity"]),
                    item_amount = Convert.ToDecimal(row["item_amount"]),
                    item_discount = Convert.ToDecimal(row["item_discount"]),
                    item_rate = Convert.ToDecimal(row["item_rate"])


                };
                ItemList.Add(ad);
            }
            return ItemList;
        }
    }
}
