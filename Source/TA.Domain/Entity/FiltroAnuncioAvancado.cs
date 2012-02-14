using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class FiltroAnuncioAvancado : FiltroAnuncioSimples
    {
        public List<Opcional> Opcionais { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public decimal? ValorEntradaInicial { get; set; }
        public decimal? ValorEntradaFinal { get; set; }
        public decimal? ValorParcelaInicial { get; set; }
        public decimal? ValorParcelaFinal { get; set; }
        public uint? Portas { get; set; }
        public List<Char> FinaisPlaca { get; set; }
    }
}
