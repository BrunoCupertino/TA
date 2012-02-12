using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioCidade
    {
        List<string> ObterTodosEstados();
        List<Cidade> ObterCidadesDoEstado(string estado);
    }
}
