using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace TA.Domain.Entity
{
    public class Anunciante : EntidadeBase
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Cidade Cidade { get; set; }
        public string CEP { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool AceitaBoletim { get; set; }
        public bool AceitaTermosDeUso { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
