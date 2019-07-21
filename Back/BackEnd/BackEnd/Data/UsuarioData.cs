using BackEnd.DTO;
using BackEnd.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class UsuarioData
    {
        public List<T> ConsultarTodosUsuarios<T>()
        {
            return Util.DBConfig.GetData<T>("PR_ConsultarUsuario");
        }

        public List<T> ConsultarUsuarioAmigos<T>(Int64 usuarioID)
        {            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("usuarioID", usuarioID);
            return Util.DBConfig.GetData<T>("PR_ConsultarUsuarioAmigos", parameters);
        }
        
    }
}