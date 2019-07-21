﻿using BackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public class UsuarioAmigosDTO : IUsuarioAmigosDTO
    {
        public Int64 IDAmigo { get; set; }
        public string Usuario_Nome { get; set; }
        public decimal Posicao_Latitude { get; set; }
        public decimal Posicao_Longitude { get; set; }
    }
}
