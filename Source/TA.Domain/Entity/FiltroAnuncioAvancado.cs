using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class FiltroAnuncioAvancado : FiltroAnuncioSimples
    {
        public List<Opcional> Opcionais { get; set; }
        public string Cor { get; set; }
    }
}
