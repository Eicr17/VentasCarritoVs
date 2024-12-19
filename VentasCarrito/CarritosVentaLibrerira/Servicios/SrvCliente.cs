using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarritosVentaLibrerira.Modelos;


namespace CarritosVentaLibrerira.Servicios
{
    public class SrvCliente
    {
        public  static List<MdlCliente> ObtenerCliente()
        {
            var lista = new List<MdlCliente>();

            SqlConnection cn = new SqlConnection("Data Source=192.168.1.97; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Cliente");
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;

            using (IDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var item = new MdlCliente();
                    item.Id_Cliente = int.Parse(dr.GetValue(0).ToString());
                    item.Nombre = dr.GetValue(1).ToString();
                    item.Apellido = dr.GetValue(2).ToString();
                    item.Dpi = dr.GetValue(3).ToString();
                    item.Telefono = dr.GetValue(4).ToString();
                    item.TotalVentas = double.Parse(dr.GetValue(5).ToString());
                    lista.Add(item);

                }

            }
            cn.Close();
            cn.Dispose();
            return lista;


        }

        public void Insertar(MdlClienteCrear item)
        {

            var conn = new SqlConnection("Data Source=192.168.1.97; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();

            string sql = "INSERT INTO Cliente(nombre, apellido, dpi, telefono, totalventas) " +
           "VALUES (@nombre, @apellido, @dpi, @telefono, @totalventas)";


            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = item.Nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = item.Apellido;
            cmd.Parameters.Add("@dpi", SqlDbType.VarChar).Value = item.Dpi;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = item.Telefono;
            cmd.Parameters.Add("@totalventas", SqlDbType.Decimal).Value = item.TotalVentas;
            cmd.ExecuteNonQuery();


            conn.Dispose();
            conn.Close();
        }


        public void Actualizar(MdlClienteActualizar item) 
        
        {
            var conn = new SqlConnection("Data Source=192.168.1.97; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            conn.Open();

            string sql = "Update Cliente set  Nombre=@Nombre, Apellido=@Apellido, Dpi=@Dpi, Telefono = @Telefono, TotalVentas=@Totalventas " +
                "Where Id_cliente=@Idcliente";

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Idcliente", SqlDbType.Int).Value = item.Id_Cliente;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = item.Nombre;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = item.Apellido;
            cmd.Parameters.Add("@Dpi", SqlDbType.VarChar).Value = item.Dpi;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = item.Telefono;
            cmd.Parameters.Add("@Totalventas", SqlDbType.Decimal).Value = item.TotalVentas;
            cmd.ExecuteNonQuery();


            conn.Dispose();
            conn.Close();
        }

        public void Eliminar(MdlClienteEliminar item)
        {
            var conn = new SqlConnection("Data Source=192.168.1.97; Initial Catalog=dbCarritoCompras; User=sa; Password= Admin10;");
            conn.Open();

            string sql = "DELETE FROM Cliente " +
               "WHERE Id_Cliente = @Id_Cliente";


            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = item.Id_Cliente;
            cmd.ExecuteNonQuery();

            conn.Dispose();
            conn.Close();


        }

    }
}
