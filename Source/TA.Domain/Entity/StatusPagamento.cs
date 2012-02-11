using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public enum StatusPagamento
    {
        AguardandoPagamento = 1,
        EmAnalise = 2,
        Paga = 3,
        Cancelada = 4
    }
}
