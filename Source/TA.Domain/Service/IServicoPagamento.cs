using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoPagamento
    {
        Pagamento ObterPagamentoDoAnuncio(Anuncio anuncio);
        void Incluir(Pagamento pagamento);
        void Atualizar(Pagamento pagamento);
    }
}
