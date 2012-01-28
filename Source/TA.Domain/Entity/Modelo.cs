using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Modelo : IEntidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Marca Marca { get; set; }
    }
}
