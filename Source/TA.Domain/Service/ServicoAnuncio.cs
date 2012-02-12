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
        private IServicoAnunciante servicoDeAnunciante;
        private IServicoAutomovel servicoDeAutomovel;

        public ServicoAnuncio(IRepositorioAnuncio repositorioDeAnuncios,
                              IServicoAnunciante servicoDeAnunciante,
                              IServicoAutomovel servicoDeAutomovel)
        {
            this.repositorioDeAnuncios = repositorioDeAnuncios;
            this.servicoDeAnunciante = servicoDeAnunciante;
            this.servicoDeAutomovel = servicoDeAutomovel;
        }

        #region IServicoAnuncio Members

        public void Anuciar(Anuncio anuncio)
        {
            if (anuncio == null || anuncio.Plano == null)
            {
                throw new ArgumentNullException();
            }

            if (!anuncio.Plano.Ativo)
            {
                throw new Exception("Plano inválido.");
            }

            servicoDeAnunciante.Incluir(anuncio.Anunciante);
            servicoDeAutomovel.Incluir(anuncio.Automovel);

            anuncio.Data = DateTime.Now;
            anuncio.Status = StatusAnuncio.AguardandoAprovacao;

            this.repositorioDeAnuncios.Anuciar(anuncio);
        }

        public void Atualizar(Anuncio anuncio)
        {
            if (anuncio == null || anuncio.Plano == null)
            {
                throw new ArgumentNullException();
            }

            this.servicoDeAutomovel.Atualizar(anuncio.Automovel);

            this.repositorioDeAnuncios.Atualizar(anuncio);
        }

        public void Excluir(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            this.servicoDeAutomovel.Excluir(anuncio.Automovel);

            this.repositorioDeAnuncios.Excluir(anuncio);
        }

        public Anuncio ObterAnuncioPorId(ulong id)
        {
            Anuncio anuncio = this.repositorioDeAnuncios.ObterAnuncioPorId(id);

            if (anuncio == null)
            {
                throw new Exception("Anúncio inexistente.");
            }

            return anuncio;
        }

        public Anuncio IncrementarVisitasDoAnuncio(ulong idAnuncio)
        {
            Anuncio anuncio = this.ObterAnuncioPorId(idAnuncio);

            anuncio.Visitas++;

            this.Atualizar(anuncio);

            return anuncio;
        }

        public List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante)
        {
            if (anunciante == null)
            {
                throw new ArgumentNullException();
            }

            return this.repositorioDeAnuncios.ObterAnunciosDoAnunciante(anunciante);
        }

        public List<Anuncio> ObterAnunciosPagosEmDestaque()
        {
            return this.repositorioDeAnuncios.ObterAnunciosPagosEmDestaque();
        }

        public List<Anuncio> ObterAnunciosPagosMaisVisitados()
        {
            return this.repositorioDeAnuncios.ObterAnunciosPagosMaisVisitados();
        }

        public List<Anuncio> ObterAnunciosPagosRecentes()
        {
            return this.repositorioDeAnuncios.ObterAnunciosPagosRecentes();
        }

        public void AprovarAnuncio(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            anuncio.Status = StatusAnuncio.Aprovado;

            this.Atualizar(anuncio);
        }

        public void AprovarAnuncios(List<Anuncio> anuncios)
        {
            if (anuncios == null)
            {
                throw new ArgumentNullException();
            }

            anuncios.ForEach(e => this.AprovarAnuncio(e));
        }

        public void ReprovarAnuncio(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            anuncio.Status = StatusAnuncio.Reprovado;

            this.Atualizar(anuncio);
        }

        public void ReprovarAnuncios(List<Anuncio> anuncios)
        {
            if (anuncios == null)
            {
                throw new ArgumentNullException();
            }

            anuncios.ForEach(e => this.ReprovarAnuncio(e));
        }

        public List<Anuncio> ObterAnunciosAguardandoAprovacao()
        {
            return this.repositorioDeAnuncios.ObterAnunciosAguardandoAprovacao();
        }

        #endregion
    }
}
