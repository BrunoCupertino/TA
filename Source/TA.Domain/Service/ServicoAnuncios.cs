using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using TA.Domain.Repository;

namespace TA.Domain.Service
{
    public class ServicoAnuncios : IServicoAnuncio
    {
        private IRepositorioAnuncios repositorioDeAnuncios;

        public ServicoAnuncios(IRepositorioAnuncios repositorioDeAnuncios)
        {
            this.repositorioDeAnuncios = repositorioDeAnuncios;
        }

        #region IServicoAnuncio Members

        public void Anuciar(Anuncio anuncio)
        {
            //validar
            this.repositorioDeAnuncios.Anuciar(anuncio);
        }

        public void EditarAnuncio(Anuncio anuncio)
        {
            //validar
            this.repositorioDeAnuncios.EditarAnuncio(anuncio);
        }

        public void ExcluirAnuncio(Anuncio anuncio)
        {
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
            this.EditarAnuncio(anuncio);
            return anuncio;
        }

        public Anuncio OberAnuncioPorAnunciante(Anunciante anunciante)
        {
            return this.repositorioDeAnuncios.OberAnuncioPorAnunciante(anunciante);
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
            this.EditarAnuncio(anuncio);
        }

        public void AprovarAnunciosPorId(List<int> ids)
        {
            this.repositorioDeAnuncios.ObterAnunciosPorIds(ids).ForEach(e => this.AprovarAnuncio(e));
        }

        public void DesaprovarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = StatusAnuncio.Desaprovado;
            this.EditarAnuncio(anuncio);
        }

        public void DesaprovarAnunciosPorId(List<int> ids)
        {
            this.repositorioDeAnuncios.ObterAnunciosPorIds(ids).ForEach(e => this.DesaprovarAnuncio(e));
        }

        public List<Anuncio> ObterAnunciosParaAprovacao()
        {
            return this.repositorioDeAnuncios.ObterAnunciosParaAprovacao();
        }

        #endregion
    }
}
