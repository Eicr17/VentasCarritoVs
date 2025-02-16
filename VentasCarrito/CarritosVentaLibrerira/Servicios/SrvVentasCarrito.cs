﻿using CarritosVentaLibrerira.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Servicios
{
    public class SrvVentasCarrito
    {
        public static List<MdlVentas> ObtenerVentas()
        {
            var lista = new List<MdlVentas>();
            SqlConnection cn = new SqlConnection("Data source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * From VentasCarrito");
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;

            using (IDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var item = new MdlVentas();
                    item.IdProducto = int.Parse(dr.GetValue(0).ToString());
                    item.IdCliente = int.Parse(dr.GetValue(1).ToString());
                    item.IdVenta = int.Parse(dr.GetValue(2).ToString());
                    item.Establecimiento = dr.GetValue(3).ToString();
                    item.Precio = decimal.Parse(dr.GetValue(4).ToString());
                    item.CantidadProducto = int.Parse(dr.GetValue(5).ToString());
                    item.Fecha_Venta = DateTime.Parse(dr.GetValue(6).ToString());
                    item.Descuento = decimal.Parse(dr.GetValue(7).ToString());

                    lista.Add(item);


                }
                cn.Close();
                cn.Dispose();
                return lista;

            }

        }
        

        public void Insertar(MdlVentasCrear item)
        {
            var cn = new SqlConnection("Data Source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10");
            cn.Open();

            string sql = "Insert into VentasCarrito(id_producto,id_cliente,Establecimiento,Precio,Cantidad_Producto,Descuento)  " +
                "Values(@id_producto,@id_cliente,@Establecimiento,@Precio,@Cantidad,@Descuento)";

            var cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@id_producto", SqlDbType.VarChar).Value = item.Id_Producto;
            cmd.Parameters.Add("@id_cliente", SqlDbType.VarChar).Value = item.Id_Cliente;
            cmd.Parameters.Add("@Establecimiento", SqlDbType.VarChar).Value = item.Establecimiento;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = item.Precio;   
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad_Producto;
            cmd.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = item.Descuento;
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();

        }

        public void Actualizar(MdlVentasActualizar Item) {

            var cn = new SqlConnection("Data Source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10");
            cn.Open();

            string sql = "Update VentasCarrito set  Establecimiento = @Establecimiento,  Precio=@Precio, Cantidad_Producto=@Cantidad,  Descuento=@Descuento  "  +
                "Where Id_Venta= @IdVenta";

            var cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;

            cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = Item.IdVenta;
            cmd.Parameters.Add("@Establecimiento", SqlDbType.VarChar).Value = Item.Establecimiento;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Item.Precio;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Item.CantidadProducto;
            cmd.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Item.Descuento;
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        
        }


        public void Delete(MdlVentasEliminar Item) {

            var cn = new SqlConnection("Data Source=192.168.1.98; Initial Catalog=dbCarritoCompras; User=sa; Password=Admin10;");
            cn.Open();

            string sql = "Delete From VentasCarrito " +
                "Where Id_Venta = @IdVenta";

            var cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = Item.Id_Venta;
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }
    }
}
    