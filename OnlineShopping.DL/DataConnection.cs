using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OnlineShoppingCommon;

namespace OnlineShopping.DL
{
    public class DataConnection
    {
        static string connectionString
        = "Data Source=DESKTOP-MGPD89C\SQLEXPRESS;Initial Catalog=OS.db;Integrated Security=True;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        static public int GetItemQuantity(string itemID)
        {
            var selectStatement = "SELECT ItemQuantity FROM Keyboard WHERE ItemID = @ItemID";
            SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@ItemID", itemID);
            sqlConnection.Open();
            SqlDataReader read = cmd.ExecuteReader();
            var quantity = read.Read() ? Convert.ToInt32(read["ItemQuantity"]) : 0;
            sqlConnection.Close();
            return quantity;
        }

        //SELECT ItemQuantity FROM DB
        static public List<Common> GetAllQuantity()
        {
            var selectStatement = "SELECT ItemID, ItemQuantity FROM Keyboard";
            SqlCommand sqlCmd = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader read = sqlCmd.ExecuteReader();

            var common = new List<Common>();

                while (read.Read())
                {
                common.Add(new Common
                {
                    ID = read["ItemID"].ToString(),
                    Quantity = Convert.ToInt32(read["ItemQuantity"])
                });              
            }
            read.Close();
            return common;
        }
        static public int UpdateItemQuantity(string itemID, int itemQuantity)
        {
            var updateStatement = $"UPDATE dbo.Keyboard SET ItemQuantity = @ItemQuantity WHERE ItemID = @ItemID";
            SqlCommand updateCmd = new SqlCommand(updateStatement, sqlConnection);
            updateCmd.Parameters.AddWithValue("@ItemID", itemID);
            updateCmd.Parameters.AddWithValue("@ItemQuantity", itemQuantity);
            sqlConnection.Open();
            var result = updateCmd.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}
