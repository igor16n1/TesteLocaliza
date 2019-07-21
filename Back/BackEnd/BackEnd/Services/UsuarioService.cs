using BackEnd.Classes;
using BackEnd.Data;
using BackEnd.DTO;
using BackEnd.Interfaces;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class UsuarioService
    {
        private static UsuarioData instance;        
        public static UsuarioData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsuarioData();
                }
                return instance;
            }
        }

        public List<UsuarioPosicaoDTO> ConsultarTodosUsuarios()
        {
            try
            {
                List<UsuarioPosicao> usuarioPosicaoLista = Instance.ConsultarTodosUsuarios<UsuarioPosicao>();
                List<UsuarioPosicaoDTO> retorno = new List<UsuarioPosicaoDTO>();
                foreach (UsuarioPosicao usuarioPosicao in usuarioPosicaoLista)
                {
                    retorno.Add(
                        new UsuarioPosicaoDTO
                        {
                            ID = usuarioPosicao.ID,
                            Usuario_Nome = usuarioPosicao.Usuario_Nome,
                            Posicao_Latitude = usuarioPosicao.Posicao_Latitude,
                            Posicao_Longitude = usuarioPosicao.Posicao_Longitude,
                        }
                    );
                }
                return retorno;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<UsuarioAmigosDTO> ConsultarUsuarioAmigos(Int64 usuarioID)
        {
            try
            {
                List<UsuarioAmigos> usuarioAmigosLista = Instance.ConsultarUsuarioAmigos<UsuarioAmigos>(usuarioID);
                List<UsuarioAmigosDTO> retorno = new List<UsuarioAmigosDTO>();
                foreach (UsuarioAmigos usuarioAmigos in usuarioAmigosLista)
                {
                    retorno.Add(
                        new UsuarioAmigosDTO
                        {
                            IDAmigo = usuarioAmigos.IDAmigo,
                            Usuario_Nome = usuarioAmigos.Usuario_Nome,
                            Posicao_Latitude = usuarioAmigos.Posicao_Latitude,
                            Posicao_Longitude = usuarioAmigos.Posicao_Longitude,
                        }
                    );
                }
                return retorno;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<AmigoDTO> ConsultarAmigosPosicoes(Int64 usuarioID, Int64 usuarioAmigoID)
        {
            try
            {
                List<UsuarioAmigos> usuarioAmigosLista = Instance.ConsultarUsuarioAmigos<UsuarioAmigos>(usuarioID);
                UsuarioAmigos usuario = usuarioAmigosLista.Where(x => x.IDAmigo == usuarioID).FirstOrDefault();
                usuarioAmigosLista.Remove(usuario);
                List<Amigo> amigosList = new List<Amigo>();
                foreach (UsuarioAmigos UsuarioAmigo in usuarioAmigosLista)
                {
                    double res = Math.Sqrt(Math.Pow(((double)UsuarioAmigo.Posicao_Longitude - (double)usuario.Posicao_Longitude), 2) +
                                  Math.Pow(((double)UsuarioAmigo.Posicao_Latitude - (double)usuario.Posicao_Latitude), 2));
                    amigosList.Add(
                        new Amigo()
                        {
                            distancia = res,
                            IDAmigo = UsuarioAmigo.IDAmigo,
                            Usuario_Nome = UsuarioAmigo.Usuario_Nome,
                            Posicao_Latitude = UsuarioAmigo.Posicao_Latitude,
                            Posicao_Longitude = UsuarioAmigo.Posicao_Longitude,
                        }
                    );
                }
                List<Amigo> amigosListOrdenado = amigosList.OrderBy(x => x.distancia).ToList();
                List<AmigoDTO> amigosDTOList = new List<AmigoDTO>();
                for (int i = 0; i < 3; i++)
                {
                    amigosDTOList.Add(
                        new AmigoDTO()
                        {
                            distancia = amigosListOrdenado[i].distancia,
                            IDAmigo = amigosListOrdenado[i].IDAmigo,
                            Usuario_Nome = amigosListOrdenado[i].Usuario_Nome,
                            Posicao_Latitude = amigosListOrdenado[i].Posicao_Latitude,
                            Posicao_Longitude = amigosListOrdenado[i].Posicao_Longitude,
                        }
                    );
                }

                return amigosDTOList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
