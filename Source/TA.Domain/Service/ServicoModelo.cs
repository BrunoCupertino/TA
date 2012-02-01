using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Repository;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public class ServicoModelo : IServicoModelo
    {
        private IRepositorioModelo repositorioModelo;

        public ServicoModelo(IRepositorioModelo repositorioModelo)
        {
            this.repositorioModelo = repositorioModelo;
        }

        #region IServicoModelo Members

        public List<Modelo> ObterModelosDaMarca(Marca marca)
        {
            return this.repositorioModelo.ObterModelosDaMarca(marca);
        }

        #endregion
    }
}
