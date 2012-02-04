using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Marca : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoAutomovel TipoAutomovel { get; set; }
    }
}
