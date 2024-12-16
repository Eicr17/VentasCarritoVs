using CarritosVentaLibrerira.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Servicios
{
    public class SrvProducto
    {
        public static List<MdlProductoDb> ObtenerProducto()
        {

            var lista = new List<MdlProductoDb>();
            SqlConnection cn = new SqlConnection("Data Source= Eicr; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Producto");
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;


            using (IDataReader dr = cmd.ExecuteReader())
            {

                while (dr.Read())
                {
                    var item = new MdlProductoDb();
                    item.Id_Producto = int.Parse(dr.GetValue(0).ToString());
                    item.Nombre_Producto = dr.GetValue(1).ToString();
                    item.Existencia = int.Parse(dr.GetValue(2).ToString());
                    item.Marca = dr.GetValue(3).ToString();
                    item.Precio = int.Parse(dr.GetValue(4).ToString());
                    lista.Add(item);


                }

            }
            cn.Close();
            cn.Dispose();
            return lista;
        }


        public void Insertar(MdlCrearProductoDb item)
        {
            var conn = new SqlConnection("Data Source=Eicr; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();

            string sql = "Insert into Producto(Nombre_Producto,Existencia,Marca,Precio)  " +
                "Values(@nombre,@existencia,@marca,@precio)";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = item.Nombre_Producto;
            cmd.Parameters.Add("@existencia", SqlDbType.Int).Value = item.Existencia;
            cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = item.Marca;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = item.Precio;
            cmd.ExecuteNonQuery();


            conn.Close();
            conn.Dispose();
        }


        public void Actualziar(MdlProductoDb Item)
        {
            var conn = new SqlConnection("Data Source=Eicr; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();

            string sql = "Update Producto set   Nombre_Producto=@nombre, Existencia=@existencia, Marca=@marca, Precio=@Precio  " +
                "Where Id_Producto=@IdProducto";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar).Value = Item.Id_Producto;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Item.Nombre_Producto;
            cmd.Parameters.Add("@existencia", SqlDbType.Int).Value = Item.Existencia;
            cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = Item.Marca;
            cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = Item.Precio;
            cmd.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();
        }


        public void Eliminar(MdlProductoDb Item)
        {
            var conn = new SqlConnection("Data Source=Eicr; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();
            string sql = "Delete From Producto " +
                "Where Id_Producto = @Id_Producto ";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Id_Producto", SqlDbType.Int).Value = Item.Id_Producto;
            cmd.Parameters.Add("@");
            cmd.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

    }
}
