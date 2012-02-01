using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoAnuncio
    {
        void Anuciar(Anuncio anuncio);
        void AtualizarAnuncio(Anuncio anuncio);
        void ExcluirAnuncio(Anuncio anuncio);
        Anuncio ObterAnuncioPorId(int id);
        Anuncio DetalharAnuncioPorId(int id);
        List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante);
        List<Anuncio> ObterAnunciosEmDestaque();
        List<Anuncio> ObterAnunciosMaisVisitados();
        List<Anuncio> ObterAnunciosRecentes();
        void AprovarAnuncio(Anuncio anuncio);
        void AprovarAnuncios(List<Anuncio> anuncios);
        void DesaprovarAnuncio(Anuncio anuncio);
        void DesaprovarAnuncios(List<Anuncio> anuncios);
        List<Anuncio> ObterAnunciosAguardandoAprovacao();               
    }
}
