using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBridge
{
    public class ProductDAL
    {

        public static string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        public static IEnumerable<Product> GetAllProducts()
        {
            List<Product> lstContact = new List<Product>();
            SqlConnection con = new SqlConnection(conString);
            string qry = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"].ToString());
                    string Name = reader["Name"].ToString();
                    string Description = reader["Description"].ToString();
                    int Price = Convert.ToInt32(reader["Price"].ToString());

                    Product ct = new Product
                    {
                        id = ID,
                        Name = Name,
                        Description = Description,
                        Price = Price
                    };
                    lstContact.Add(ct);
                }
                reader.Close();
            }
            catch (Exception exp)
            { throw exp; }
            finally
            { con.Close(); }
            return lstContact;
        }

         public static Product GetProductById(int ID)
        {

            Product ct = new Product();
            //string conString = ConfigurationManager.ConnectionStrings["ContactEntities"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string cmdString = "SELECT * FROM Product WHERE ID=" + ID;

            SqlCommand cmd = new SqlCommand(cmdString, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"].ToString());
                    string Name = reader["Name"].ToString();
                    string Description = reader["Description"].ToString();
                    int Price = Convert.ToInt32(reader["Price"].ToString());

                    ct = new Product
                    {
                        id = id,
                        Name = Name,
                        Description = Description,
                        Price = Price
                    };
                }
                reader.Close();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                con.Close();
            }

            return ct;
        }
        public static void DeleteProduct(int ID)
        {

            SqlConnection con = new SqlConnection(conString);
            string cmdString = "DELETE FROM Product WHERE ID=" + ID;
            SqlCommand cmd = new SqlCommand(cmdString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            { throw exp; }
            finally
            { con.Close(); }
        }

        public static void Edit( int ID, Product product)
        {
            //Contact contact = new Contact();
            //   bool status = false;
            SqlConnection con = new SqlConnection(conString);
            try
            {
                using ( con)
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Contacts SET Name=@Name, " +
                        "Description=@Description " +
                        "Price=@Price " +
                        "WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@id", product.id));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", product.Name));
                    cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                    cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                    cmd.ExecuteNonQuery();


                }
              

                    }
                    catch (Exception ex)
            { throw ex; }

            finally
            { con.Close(); }

           


        }
        public static void AddProduct(Product product)
        {
            // contact = new Contact();
            using (SqlConnection con = new SqlConnection(conString))
            {

                string cmdString = "Insert into Product (ID,Name,Description,Price) VALUES(@ID,@Name,@Description,@Price)";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", product.id.ToString());
                    cmd.Parameters.AddWithValue("@FirstName", product.Name.ToString());
                    cmd.Parameters.AddWithValue("@LastName", product.Description.ToString());
                    cmd.Parameters.AddWithValue("@Password", product.Price.ToString());

                    cmd.ExecuteNonQuery();
                    //  Contact.Savechanges();
                }
                catch (Exception exp)
                { throw exp; }
                finally
                { con.Close(); }


            }
        }



    }
}