using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using TA.Domain.Repository;

namespace TA.Domain.Service
{
    public class ServicoEstatisticaAnuncio : IServicoEstatisticaAnuncio
    {
        private IRepositorioEstatisticaAnuncio repositorioEstatisticaAnuncio;

        public ServicoEstatisticaAnuncio(IRepositorioEstatisticaAnuncio repositorioEstatisticaAnuncio)
        {
            this.repositorioEstatisticaAnuncio = repositorioEstatisticaAnuncio;
        }

        #region IServicoEstatisticaAnuncio Members

        public EstatisticaAnuncio ObterEstatisticaDoAnuncio(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            return this.repositorioEstatisticaAnuncio.ObterEstatisticaDoAnuncio(anuncio);
        }

        public void VisualizarAnuncio(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            EstatisticaAnuncio estatisticaAnuncio = this.ObterEstatisticaDoAnuncio(anuncio);

            if (estatisticaAnuncio == null)
            {
                throw new Exception("Anúncio inválido.");
            }

            estatisticaAnuncio.VisualizacoesAnuncio++;

            this.repositorioEstatisticaAnuncio.Atualizar(estatisticaAnuncio);
        }

        public void VisualizarTelefoneDoAnuncio(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            EstatisticaAnuncio estatisticaAnuncio = this.ObterEstatisticaDoAnuncio(anuncio);

            if (estatisticaAnuncio == null)
            {
                throw new Exception("Anúncio inválido.");
            }

            estatisticaAnuncio.VisualizacoesTelefone++;

            this.repositorioEstatisticaAnuncio.Atualizar(estatisticaAnuncio);
        }

        #endregion
    }
}
