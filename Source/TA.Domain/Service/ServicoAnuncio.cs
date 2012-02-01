using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using TA.Domain.Repository;

namespace TA.Domain.Service
{
    public class ServicoAnuncio : IServicoAnuncio
    {
        private IRepositorioAnuncio repositorioDeAnuncios;

        public ServicoAnuncio(IRepositorioAnuncio repositorioDeAnuncios)
        {
            this.repositorioDeAnuncios = repositorioDeAnuncios;
        }

        #region IServicoAnuncio Members

        public void Anuciar(Anuncio anuncio)
        {
            //validar
            anuncio.Data = DateTime.Now;
            this.repositorioDeAnuncios.Anuciar(anuncio);
        }

        public void AtualizarAnuncio(Anuncio anuncio)
        {
            //validar
            this.repositorioDeAnuncios.AtualizarAnuncio(anuncio);
        }

        public void ExcluirAnuncio(Anuncio anuncio)
        {
            //validar
            this.repositorioDeAnuncios.ExcluirAnuncio(anuncio);
        }

        public Anuncio ObterAnuncioPorId(int id)
        {
            return this.repositorioDeAnuncios.ObterAnuncioPorId(id);
        }

        public Anuncio DetalharAnuncioPorId(int id)
        {
            Anuncio anuncio = this.ObterAnuncioPorId(id);
            anuncio.Visitas++;
            this.AtualizarAnuncio(anuncio);
            return anuncio;
        }

        public List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante)
        {
            return this.repositorioDeAnuncios.ObterAnunciosDoAnunciante(anunciante);
        }

        public List<Anuncio> ObterAnunciosEmDestaque()
        {
            return this.repositorioDeAnuncios.ObterAnunciosEmDestaque();
        }

        public List<Anuncio> ObterAnunciosMaisVisitados()
        {
            return this.repositorioDeAnuncios.ObterAnunciosMaisVisitados();
        }

        public List<Anuncio> ObterAnunciosRecentes()
        {
            return this.ObterAnunciosRecentes();
        }

        public void AprovarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = StatusAnuncio.Aprovado;
            this.AtualizarAnuncio(anuncio);
        }

        public void AprovarAnuncios(List<Anuncio> anuncios)
        {
            anuncios.ForEach(e => this.AprovarAnuncio(e));
        }

        public void DesaprovarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = StatusAnuncio.Desaprovado;
            this.AtualizarAnuncio(anuncio);
        }

        public void DesaprovarAnuncios(List<Anuncio> anuncios)
        {
            anuncios.ForEach(e => this.DesaprovarAnuncio(e));
        }

        public List<Anuncio> ObterAnunciosAguardandoAprovacao()
        {
            return this.repositorioDeAnuncios.ObterAnunciosAguardandoAprovacao();
        }

        #endregion
    }
}
