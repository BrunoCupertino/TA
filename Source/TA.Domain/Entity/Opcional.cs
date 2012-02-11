using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Opcional : EntidadeBase
    {
        public string Nome { get; set; }
        public TipoAutomovel TipoAutomovel { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
