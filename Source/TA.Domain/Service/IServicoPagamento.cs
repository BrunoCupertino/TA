using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoPagamento
    {
        Pagamento ObterPagamentoDoAnuncioDeId(ulong idAnuncio);
        Pagamento ObterPagamentoDoAnuncio(Anuncio anuncio);
        Uri IncluirPagamentoDoAnuncio(Anuncio anuncio);
        void EnviarParaAnalise(Pagamento pagamento);
        void Pagar(Pagamento pagamento);
        void Cancelar(Pagamento pagamento);
    }
}
