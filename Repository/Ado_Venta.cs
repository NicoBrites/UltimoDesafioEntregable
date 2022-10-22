using HOLACODERCLASE14APIS.Models;
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
        public static void CargarVenta(Venta venta)
        {
       

            using (SqlConnection conecction = new SqlConnection(Connection.connectionString()))
            {
                conecction.Open();

                SqlCommand cmd = conecction.CreateCommand();
                cmd.CommandText = "Insert into Venta ( Comentarios, IdUsuario)" +
                                   "values (@comentariosVenta, @idUsuarioVenta)";



                var paramComentariosVenta = new SqlParameter("comentariosVenta", System.Data.SqlDbType.VarChar);
                paramComentariosVenta.Value = venta.Comentarios;

                var paramIdUsuarioVenta = new SqlParameter("idUsuarioVenta", System.Data.SqlDbType.BigInt);
                paramIdUsuarioVenta.Value = venta.IdUsuario;


                cmd.Parameters.Add(paramComentariosVenta);
                cmd.Parameters.Add(paramIdUsuarioVenta);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
