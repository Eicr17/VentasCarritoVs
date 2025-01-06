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
        public static List<MdlProducto> ObtenerProducto()
        {

            var lista = new List<MdlProducto>();
            SqlConnection cn = new SqlConnection("Data Source= 192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Producto");
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;


            using (IDataReader dr = cmd.ExecuteReader())
            {

                while (dr.Read())
                {
                    var item = new MdlProducto();
                    item.Id_Producto = int.Parse(dr.GetValue(0).ToString());
                    item.Nombre_Producto = dr.GetValue(1).ToString();
                    item.Marca = dr.GetValue(2).ToString();
                    item.Precio = double.Parse(dr.GetValue(3).ToString());
                    item.Existencia = decimal.Parse(dr.GetValue(4).ToString());
                    lista.Add(item);


                }

            }
            cn.Close();
            cn.Dispose();
            return lista;
        }


        public void Insertar(MdlCrearProducto item)
        {
            var conn = new SqlConnection("Data Source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();

            string sql = "Insert into Producto(Nombre_Producto,Marca,Precio,Existencia)  " +
                "Values(@nombre,@marca,@precio,@existencia)";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = item.Nombre_Producto;
            cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = item.Marca;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = item.Precio;
            cmd.Parameters.Add("@existencia", SqlDbType.Decimal).Value = item.Existencia;
            cmd.ExecuteNonQuery();


            conn.Close();
            conn.Dispose();
        }


        public void Actualizar(MdlProductoActualizar Item)
        {
            var conn = new SqlConnection("Data Source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();

            string sql = "Update Producto set   Nombre_Producto=@nombre, Marca=@marca, Precio=@Precio, Existencia = @existencia " +
                "Where Id_Producto=@IdProducto";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar).Value = Item.Id_Producto;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Item.Nombre_Producto;
            cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = Item.Marca;
            cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = Item.Precio;
            cmd.Parameters.Add("@existencia", SqlDbType.Decimal).Value = Item.Existencia;

            cmd.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();
        }


        public void Eliminar(MdlProductoEliminar Item)
        {
            var conn = new SqlConnection("Data Source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();
            string sql = "Delete From Producto " +
                "Where Id_Producto = @Id_Producto ";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Id_Producto", SqlDbType.Int).Value = Item.Id_Producto;
            cmd.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

    }
}
