using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioPagamento
    {
        Pagamento ObterPagamentoDoAnuncioDeId(ulong idAnuncio);
        Pagamento ObterPagamentoDoAnuncio(Anuncio anuncio);
        void Incluir(Pagamento pagamento);
        void Atualizar(Pagamento pagamento);
    }
}
