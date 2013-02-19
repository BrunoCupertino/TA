using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoAnuncio
    {
        void Anunciar(Anuncio anuncio);
        void Atualizar(Anuncio anuncio);
        void Excluir(Anuncio anuncio);
        Anuncio ObterAnuncioPorId(ulong id);
        List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante);
        List<Anuncio> ObterAnunciosAprovadosPagosEmDestaque();
        List<Anuncio> ObterAnunciosAprovadosPagosMaisVisitados();
        List<Anuncio> ObterAnunciosAprovadosPagosRecentes();
        void AprovarAnuncio(Anuncio anuncio);
        void AprovarAnuncios(List<Anuncio> anuncios);
        void ReprovarAnuncio(Anuncio anuncio);
        void ReprovarAnuncios(List<Anuncio> anuncios);
        List<Anuncio> ObterAnunciosAguardandoAprovacao();   
        
        //TODO: Busca Simples e Avançada
    }
}
