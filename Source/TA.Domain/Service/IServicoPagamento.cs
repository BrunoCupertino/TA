using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoPagamentoPagSeguro
    {
        Pagamento ObterPagamentoDoAnuncio(Anuncio anuncio);
        Uri RequisitarPagamentoDoAnuncio(Anuncio anuncio);
        void AlterarStatusDoPagamento(string codigoNotificacao);
    }
}
