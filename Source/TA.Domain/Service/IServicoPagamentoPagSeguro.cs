using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoPagamentoPagSeguro
    {
        Uri RequisitarPagamento(Pagamento pagamento);
        void AlterarStatusDoPagamento(string codigoNotificacao);
    }
}
