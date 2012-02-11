using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioAnuncio
    {
        void Anuciar(Anuncio anuncio);
        void AtualizarAnuncio(Anuncio anuncio);
        void ExcluirAnuncio(Anuncio anuncio);
        Anuncio ObterAnuncioPorId(int id);
        List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante);
        List<Anuncio> ObterAnunciosPagosEmDestaque();
        List<Anuncio> ObterAnunciosPagosMaisVisitados();
        List<Anuncio> ObterAnunciosPagosRecentes();
        List<Anuncio> ObterAnunciosAguardandoAprovacao(); 
    }
}
