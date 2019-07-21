using BackEnd.Services;
using NUnit.Framework;
using BackEnd;
using BackEnd.DTO;
using System.Collections.Generic;

namespace NUnitTestProject
{
    class UsuarioTest
    {        
        private UsuarioService instance;
        private string databaseConnectionString = "Server=IGOR-PC;Database=Localiza;Trusted_Connection=Yes";

        [SetUp]
        public void Setup()
        {
            instance = new UsuarioService();
        }

        [Test]
        public void ConsultarUsuariosPosicoes()
        {
            if (BackEnd.Util.DBConfig.connectionString == null)
            {
                BackEnd.Util.DBConfig.connectionString = databaseConnectionString;
            }            
            List<UsuarioPosicaoDTO> usuarioPosicaoLista = instance.ConsultarTodosUsuarios();            
            Assert.IsTrue(usuarioPosicaoLista.Count > 0);
        }

        [Test]
        public void ConsultarUsuariosAmigos()
        {
            if (BackEnd.Util.DBConfig.connectionString == null)
            {
                BackEnd.Util.DBConfig.connectionString = databaseConnectionString;
            }
            long usuarioID = 1;
            List<UsuarioAmigosDTO> UsuarioAmigos = instance.ConsultarUsuarioAmigos(usuarioID);
            Assert.IsTrue(UsuarioAmigos.Count > 0);
        }

        [Test]
        public void ConsultarAmigosPosicoes()
        {
            if (BackEnd.Util.DBConfig.connectionString == null)
            {
                BackEnd.Util.DBConfig.connectionString = databaseConnectionString;
            }
            long usuarioID = 1;
            long usuarioAmigoID = 2;
            List<AmigoDTO> UsuarioAmigos = instance.ConsultarAmigosPosicoes(usuarioID, usuarioAmigoID);
            Assert.IsTrue(UsuarioAmigos.Count > 0);
        }
    }
}
