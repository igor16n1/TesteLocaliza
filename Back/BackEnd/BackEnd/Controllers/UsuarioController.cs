using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DTO;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private static UsuarioService instance;
        public static UsuarioService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsuarioService();
                }
                return instance;
            }
        }
        [HttpGet]
        public List<UsuarioPosicaoDTO> ConsultarTodosUsuarios()
        {
            return Instance.ConsultarTodosUsuarios();
        }

        [HttpGet("{usuarioID}")]
        public List<UsuarioAmigosDTO> ConsultarUsuarioAmigos(Int64 usuarioID)
        {
            return Instance.ConsultarUsuarioAmigos(usuarioID);
        }

        [HttpGet("{usuarioID}/{usuarioAmigoID}")]
        public List<AmigoDTO> ConsultarAmigosPosicoes(Int64 usuarioID, Int64 usuarioAmigoID)
        {
            return Instance.ConsultarAmigosPosicoes(usuarioID, usuarioAmigoID);
        }
    }
}