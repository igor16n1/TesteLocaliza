using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    interface IUsuarioPosicao
    {
        Int64 ID { get; set; }
        string Usuario_Nome { get; set; }
        decimal Posicao_Latitude { get; set; }
        decimal Posicao_Longitude { get; set; }
    }
}
