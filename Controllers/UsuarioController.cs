using HOLACODERCLASE14APIS.Models;
using HOLACODERCLASE14APIS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace HOLACODERCLASE14APIS.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("GetListUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return Ado_Usuario.TraerListaUsuarios();
        }
        
        [HttpGet("GetUsuarios")]
        public Usuario Get([FromBody] string nombreUsuario)
        {
            return Ado_Usuario.TraerUsuario(nombreUsuario);
        }
        
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            Ado_Usuario.DeleteUsuario(id);

        }

        [HttpPut]
        public void Modificar([FromBody] Usuario usu)
        {
            Ado_Usuario.ModificarUsuario(usu);

        }
        [HttpPost]
        public void Crear([FromBody] Usuario usu)
        {
            Ado_Usuario.CrearUsuario(usu);

        }




    }
}
