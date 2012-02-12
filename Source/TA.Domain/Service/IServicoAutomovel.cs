using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoAutomovel
    {
        void Incluir(Automovel automovel);
        void Atualizar(Automovel automovel);
        void Excluir(Automovel automovel);
    }
}
