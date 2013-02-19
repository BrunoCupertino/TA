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
        private IRepositorioAutomovel repositorioDeAutomovel;
        private IRepositorioEstatisticaAnuncio repositorioEstatisticaAnuncio;
        private IServicoAnunciante servicoDeAnunciante;      

        public ServicoAnuncio(IRepositorioAnuncio repositorioDeAnuncios,
                              IRepositorioAutomovel repositorioDeAutomovel,
                              IRepositorioEstatisticaAnuncio repositorioEstatisticaAnuncio,
                              IServicoAnunciante servicoDeAnunciante)                              
        {
            this.repositorioDeAnuncios = repositorioDeAnuncios;
            this.servicoDeAnunciante = servicoDeAnunciante;
            this.repositorioEstatisticaAnuncio = repositorioEstatisticaAnuncio;
            this.repositorioDeAutomovel = repositorioDeAutomovel;
        }

        private void ValidarAnuncio(Anuncio anuncio)
        {
            if (anuncio == null || anuncio.Plano == null || anuncio.Automovel == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder erros = new StringBuilder();

            if (anuncio.Automovel.ValorParcela == 0)
            {
                erros.AppendLine("Valor de parcela inválida.");
            }

            if (anuncio.Automovel.ParcelasRestantes == 0)
            {
                erros.AppendLine("Parcelas restantes inválidas.");
            }

            if (anuncio.Automovel.Modelo == null)
            {
                erros.AppendLine("Modelo inválido.");
            }

            if (!anuncio.Plano.Ativo)
            {
                erros.AppendLine("Plano inválido.");
            }

            if (erros.Length > 0)
            {
                throw new Exception(erros.ToString());
            }
        }

        #region IServicoAnuncio Members

        public void Anunciar(Anuncio anuncio)
        {
            ValidarAnuncio(anuncio);

            repositorioDeAutomovel.Incluir(anuncio.Automovel);
            servicoDeAnunciante.Incluir(anuncio.Anunciante);            

            anuncio.Data = DateTime.Now;
            anuncio.Status = StatusAnuncio.AguardandoAprovacao;

            this.repositorioDeAnuncios.Anuciar(anuncio);
            this.repositorioEstatisticaAnuncio.Incluir(new EstatisticaAnuncio(anuncio));
        }

        public void Atualizar(Anuncio anuncio)
        {
            ValidarAnuncio(anuncio);

            this.repositorioDeAutomovel.Atualizar(anuncio.Automovel);
            this.repositorioDeAnuncios.Atualizar(anuncio);
        }

        public void Excluir(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            this.repositorioDeAutomovel.Excluir(anuncio.Automovel);
            this.repositorioEstatisticaAnuncio.Excluir(this.repositorioEstatisticaAnuncio.ObterEstatisticaDoAnuncio(anuncio));

            this.repositorioDeAnuncios.Excluir(anuncio);
        }

        public Anuncio ObterAnuncioPorId(ulong id)
        {
            return this.repositorioDeAnuncios.ObterAnuncioPorId(id);
        }

        public List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante)
        {
            if (anunciante == null)
            {
                throw new ArgumentNullException();
            }

            return this.repositorioDeAnuncios.ObterAnunciosDoAnunciante(anunciante);
        }

        public List<Anuncio> ObterAnunciosAprovadosPagosEmDestaque()
        {
            return this.repositorioDeAnuncios.ObterAnunciosAprovadosPagosEmDestaque();
        }

        public List<Anuncio> ObterAnunciosAprovadosPagosMaisVisitados()
        {
            return this.repositorioDeAnuncios.ObterAnunciosAprovadosPagosMaisVisitados();
        }

        public List<Anuncio> ObterAnunciosAprovadosPagosRecentes()
        {
            return this.repositorioDeAnuncios.ObterAnunciosAprovadosPagosRecentes();
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
