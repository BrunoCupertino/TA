using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class FiltroAnuncioSimples
    {
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public int? AnoInicial { get; set; }
        public int? AnoFinal { get; set; }
        public decimal? PrecoInicial { get; set; }
        public decimal? PrecoFinal { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
