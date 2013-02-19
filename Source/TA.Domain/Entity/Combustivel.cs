using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Combustivel : EntidadeBase
    {
        public string Descricao { get; set; }
        public TipoAutomovel TipoAutomovel { get; set; }
    }
}
