using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioAnunciante
    {
        Anunciante ObterAnuncianteDeEmail(string email);
        void Incluir(Anunciante anunciante);
        void Atualizar(Anunciante anunciante);
    }
}
