using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class FiltroAnuncioSimples
    {
        public Modelo Modelo { get; set; }
        public uint? AnoInicial { get; set; }
        public uint? AnoFinal { get; set; }
        public decimal? PrecoInicial { get; set; }
        public decimal? PrecoFinal { get; set; }
        public Cidade Cidade { get; set; }
        public uint? PaginaAtual { get; set; }
    }
}
