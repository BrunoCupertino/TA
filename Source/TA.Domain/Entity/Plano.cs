using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Plano : EntidadeBase
    {
        public string Descricao { get; set; }
        public uint Prioridade { get; set; }
        public uint? Dias { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
    }
}
