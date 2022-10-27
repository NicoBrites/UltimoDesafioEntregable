using HOLACODERCLASE14APIS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HOLACODERCLASE14APIS.Repository
{
    public class Ado_Venta
    {
        public static List<Venta> TraerVentas(int idUsuario)
        {
            var listaVenta = new List<Venta>();


            using (SqlConnection conecction = new SqlConnection(Connection.connectionString()))
            {
                conecction.Open();
                SqlCommand cmd = conecction.CreateCommand();
                cmd.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @idUsu";

                var paramIdUsu = new SqlParameter("idUsu", System.Data.SqlDbType.Int);
                paramIdUsu.Value = idUsuario;

                cmd.Parameters.Add(paramIdUsu);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var venta = new Venta();

                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    listaVenta.Add(venta);
                }

                reader.Close();

                return listaVenta;
            }
        }
        public static void CargarVenta(CrearVenta venta)
        {
            long idVenta;

            using (SqlConnection conecction = new SqlConnection(Connection.connectionString()))
            {
                conecction.Open();

                SqlCommand cmd = conecction.CreateCommand();
                cmd.CommandText = "Insert into Venta ( Comentarios, IdUsuario)" +
                                   "values (@comentariosVenta, @idUsuarioVenta);"+
                                   "Select scope_identity();";


                var paramComentariosVenta = new SqlParameter("comentariosVenta", System.Data.SqlDbType.VarChar);
                paramComentariosVenta.Value = venta.Venta.Comentarios;

                var paramIdUsuarioVenta = new SqlParameter("idUsuarioVenta", System.Data.SqlDbType.BigInt);
                paramIdUsuarioVenta.Value = venta.Venta.IdUsuario;

                cmd.Parameters.Add(paramComentariosVenta);
                cmd.Parameters.Add(paramIdUsuarioVenta);
                idVenta = Convert.ToInt64(cmd.ExecuteScalar());


                foreach ( ProductoVenta producto in venta.ProductosVendidos)
                {

                        SqlCommand cmd1 = conecction.CreateCommand();
                        cmd1.CommandText = "Insert into ProductoVendido(Stock, IdProducto, IdVenta)" +
                                           "values (@stockProdVendido, @idProd, @idVenta)\n" +
                                           "UPDATE Producto SET Stock = Stock - @stockProdVendido WHERE ID = @idProd";


                        var paramStockProdVendido = new SqlParameter("stockProdVendido", System.Data.SqlDbType.Int);
                        paramStockProdVendido.Value = producto.Stock;

                        var paramIdProd = new SqlParameter("idProd", System.Data.SqlDbType.BigInt);
                        paramIdProd.Value = producto.IdProducto;

                        var paramIdVenta = new SqlParameter("idVenta", System.Data.SqlDbType.BigInt);
                        paramIdVenta.Value = idVenta;


                        cmd1.Parameters.Add(paramStockProdVendido);
                        cmd1.Parameters.Add(paramIdProd);
                        cmd1.Parameters.Add(paramIdVenta);
                        cmd1.ExecuteNonQuery();

                    
                }
            }
        }
    }
}
