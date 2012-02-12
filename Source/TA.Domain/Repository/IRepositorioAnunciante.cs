using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioAnunciante
    {
        void Incluir(Anunciante anunciante);
        void Alterar(Anunciante anunciante);
    }
}
