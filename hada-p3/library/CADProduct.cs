using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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
            string comando = "Insert Into Products (code, name, amount) " + "VALUES ('" + en.code + "', '" + en.name + "', '" + en.amount + "')";
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
                ENProduct usu = new ENProduct();
                while (datareader.Read())
                {
                    if (datareader["code"].ToString() == en.code.ToString())
                    {
                        en.amount = usu.amount;
                        en.name = usu.name;
                        en.code = usu.code;
                        return true;
                    }
                    else
                    {
                        usu.amount = int.Parse(datareader["amount"].ToString());
                        usu.name = datareader["name"].ToString();
                        usu.code = datareader["code"].ToString();
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
            string s = "UPDATE [dbo].[Products] " + "SET name = '" + en.name + "',  amount = " + en.amount + "where code ='" + en.code + "'";
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