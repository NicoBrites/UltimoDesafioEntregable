using HOLACODERCLASE14APIS.Models;
using HOLACODERCLASE14APIS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace HOLACODERCLASE14APIS.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void Crear([FromBody] CrearVenta venta)
        {
            Ado_Venta.CargarVenta(venta);

        }




    }
}
