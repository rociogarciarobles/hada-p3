using System;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        private string constring;
        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
        public bool Create(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            string comando = "Insert Into Products (code, name, amount, price, creationDate, category) " + "VALUES ('" + en.code + "', '" + en.name + "', '" + en.amount + "', '" + en.price + "','" + en.creationDate + "','" + en.category + "')";
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(comando, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                conexion.Close();
                Console.WriteLine("Error: " + e);
                return false;
            }
            return true;
        }
        public bool Read(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            String s = "select * from [dbo].[Products] where code='" + en.code + "'";
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand(s, conexion);
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr["code"].ToString() == en.code)
                {
                    en.name = dr["name"].ToString();
                    en.code = dr["code"].ToString();
                    en.amount = int.Parse(dr["amount"].ToString());
                    en.price = float.Parse(dr["price"].ToString());
                    en.creationDate = DateTime.Parse(dr["creationDate"].ToString());
                    en.category = int.Parse(dr["category"].ToString());
                    dr.Close();
                    conexion.Close();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        public bool ReadFirst(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            string s = "SELECT * " + "FROM [dbo].[Products]";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(s, conexion);
                SqlDataReader datareader = comando.ExecuteReader();
                datareader.Read();
                en.amount = int.Parse(datareader["amount"].ToString());
                en.name = datareader["name"].ToString();
                en.code = datareader["code"].ToString();
                en.price = float.Parse(datareader["price"].ToString());
                en.creationDate = DateTime.Parse(datareader["creationDate"].ToString());
                en.category = int.Parse(datareader["category"].ToString());
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool ReadNext(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            string s = "SELECT * " + "FROM [dbo].[Products]";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(s, conexion);
                SqlDataReader datareader = comando.ExecuteReader();
                bool encontrado = false;
                while (datareader.Read())
                {
                    if (encontrado)
                    {
                        en.amount = int.Parse(datareader["amount"].ToString());
                        en.name = datareader["name"].ToString();
                        en.code = datareader["code"].ToString();
                        en.price = float.Parse(datareader["price"].ToString());
                        en.creationDate = DateTime.Parse(datareader["creationDate"].ToString());
                        en.category = int.Parse(datareader["category"].ToString());
                        conexion.Close();
                        return true;
                    }
                    else if (datareader["code"].ToString() == en.code)
                    {
                        encontrado = true;
                    }
                }
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
            finally
            {
                conexion.Close();
            }

            return false;
        }
        public bool ReadPrev(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            string s = "SELECT * " + "FROM [dbo].[Products]";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(s, conexion);
                SqlDataReader datareader = comando.ExecuteReader();
                ENProduct pro = new ENProduct();
                while (datareader.Read())
                {
                    if (datareader["code"].ToString() == en.code.ToString())
                    {
                        en.amount = pro.amount;
                        en.name = pro.name;
                        en.code = pro.code;
                        en.price = pro.price;
                        en.creationDate = pro.creationDate;
                        en.category = en.category;
                        return true;
                    }
                    else
                    {
                        pro.amount = int.Parse(datareader["amount"].ToString());
                        pro.name = datareader["name"].ToString();
                        pro.code = datareader["code"].ToString();
                        pro.price = int.Parse(datareader["price"].ToString());
                        pro.creationDate = DateTime.Parse(datareader["creationDate"].ToString());
                        pro.category = int.Parse(datareader["category"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
            finally
            {
                conexion.Close();
            }

            return false;
        }
        public bool Update(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            string s = "UPDATE [dbo].[Products] " + "SET name = '" + en.name + "',  amount = " + en.amount + "',  price = " + en.price + "',  creationDAte = " + en.creationDate + "',  category = " + en.category + "where code ='" + en.code + "'";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(s, conexion);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
            finally
            {
                conexion.Close();
            }

            return true;
        }
        public bool Delete(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring); ;
            string s = "Delete from [dbo].[Products] where code = '" + en.code + "'";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(s, conexion);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
            finally
            {
                conexion.Close();
            }
            return true;
        }
    }
}