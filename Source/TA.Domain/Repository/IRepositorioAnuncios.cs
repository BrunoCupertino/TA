using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioAnuncios
    {
        void Anuciar(Anuncio anuncio);
        void AtualizarAnuncio(Anuncio anuncio);
        void ExcluirAnuncio(Anuncio anuncio);
        Anuncio ObterAnuncioPorId(int id);
        List<Anuncio> ObterAnunciosPorIds(List<int> id);
        List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante);
        List<Anuncio> ObterAnunciosEmDestaque();
        List<Anuncio> ObterAnunciosMaisVisitados();
        List<Anuncio> ObterAnunciosRecentes();
        void AprovarAnuncio(Anuncio anuncio);
        void AprovarAnunciosPorId(List<int> ids);
        void DesaprovarAnuncio(Anuncio anuncio);
        void DesaprovarAnunciosPorId(List<int> ids);
        List<Anuncio> ObterAnunciosAguardandoAprovacao(); 
    }
}
