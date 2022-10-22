using HOLACODERCLASE14APIS.Models;
using HOLACODERCLASE14APIS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace HOLACODERCLASE14APIS.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void Crear([FromBody] Producto prod)
        {
            Ado_Producto.CrearProducto(prod);

        }
        [HttpPut]
        public void Modificar([FromBody] Producto prod)
        {
            Ado_Producto.ModificarProducto(prod);

        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            Ado_Producto.DeleteProducto(id);

        }
    }
}
