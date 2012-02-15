using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TA.Domain.Service;
using Moq;
using TA.Domain.Repository;

namespace TA.Domain.Test.Service
{
    [TestClass]
    public class ServicoEstatisticaAnuncioTest
    {
        private Mock<IRepositorioEstatisticaAnuncio> repositorioEstatisticaAnuncioMock;

        private IServicoEstatisticaAnuncio target;

        public ServicoEstatisticaAnuncioTest()
        {
            this.repositorioEstatisticaAnuncioMock = new Mock<IRepositorioEstatisticaAnuncio>();

            target = new ServicoEstatisticaAnuncio(repositorioEstatisticaAnuncioMock.Object);
        }

        //TODO: Testar ObterEstatisticaDoAnuncio, VisualizarAnuncio e VisualizarTelefoneDoAnuncio
    }
}
