using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Anuncio : EntidadeBase
    {
        public Anuncio(Anunciante anunciante, Automovel automovel, Plano plano)
        {
            this.Anunciante = anunciante;
            this.Automovel = automovel;
            this.Plano = plano;
        }

        public StatusAnuncio Status { get; set; }
        public DateTime Data { get; set; }
        public Anunciante Anunciante { get; set; }
        public Automovel Automovel { get; set; }
        public Plano Plano { get; set; }
        public string Observacao { get; set; }
    }
}
