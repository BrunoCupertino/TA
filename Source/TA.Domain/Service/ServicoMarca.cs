using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using TA.Domain.Repository;

namespace TA.Domain.Service
{
    public class ServicoMarca : IServicoMarca
    {
        private IRepositorioMarca repositorioMarca;

        public ServicoMarca(IRepositorioMarca repositorioMarca)
        {
            this.repositorioMarca = repositorioMarca;
        }

        #region IServicoMarca Members

        public List<Marca> ObterMarcasDeCarro()
        {
            return this.repositorioMarca.ObterMarcasDeCarro();
        }

        public List<Marca> ObterMarcasDeMoto()
        {
            return this.repositorioMarca.ObterMarcasDeMoto();
        }

        #endregion
    }
}
