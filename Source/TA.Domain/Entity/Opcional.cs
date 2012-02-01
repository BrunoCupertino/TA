using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Opcional : IEntidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public CategoriaAutomovel CategoriaAutomovel { get; set; }
    }
}
