using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Pagamento : EntidadeBase
    {
        public Pagamento(Anuncio anuncio)
        {
            this.Anuncio = anuncio;
        }

        public DateTime? Data { get; set; }
        public Anuncio Anuncio { get; set; }
        public StatusPagamento Status { get; set; }

        public override string ToString()
        {
            return this.Status.ToString();
        }
    }
}
