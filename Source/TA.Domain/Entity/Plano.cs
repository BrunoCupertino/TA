using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Plano : EntidadeBase
    {
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public int? Dias { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
