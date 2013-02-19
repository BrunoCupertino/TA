using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Modelo : EntidadeBase
    {
        public string Nome { get; set; }
        public Marca Marca { get; set; }
    }
}
