using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioEstatisticaAnuncio
    {
        EstatisticaAnuncio ObterEstatisticaDoAnuncio(Anuncio anuncio);
        void Incluir(EstatisticaAnuncio estatisticaAnuncio);
        void Atualizar(EstatisticaAnuncio estatisticaAnuncio);        
        void Excluir(EstatisticaAnuncio estatisticaAnuncio);
    }
}
