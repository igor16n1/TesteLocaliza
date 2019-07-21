using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    interface IAmigoDTO
    {
        double distancia { get; set; }
        Int64 IDAmigo { get; set; }
        string Usuario_Nome { get; set; }
        decimal Posicao_Latitude { get; set; }
        decimal Posicao_Longitude { get; set; }
    }
}
