using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TA.Domain.Service;
using Moq;
using TA.Domain.Repository;
using TA.Domain.Entity;

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObterEstatisticaDoAnuncio_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.ObterEstatisticaDoAnuncio(null);
        }

        [TestMethod]
        public void ObterEstatisticaDoAnuncio_Anuncio_Valido_Chama_Repositorio_ObterEstatisticaDoAnuncio_Retorna_Estatistica()
        {
            Anuncio anuncio = new Anuncio(null, new Automovel(new Modelo()), null);
            EstatisticaAnuncio estatistaAnuncio = new EstatisticaAnuncio(anuncio);

            repositorioEstatisticaAnuncioMock.Setup(r => r.ObterEstatisticaDoAnuncio(anuncio)).Returns(estatistaAnuncio);

            Assert.AreEqual(estatistaAnuncio, target.ObterEstatisticaDoAnuncio(anuncio));
            repositorioEstatisticaAnuncioMock.Verify(r => r.ObterEstatisticaDoAnuncio(anuncio));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VisualizarAnuncio_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.VisualizarAnuncio(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void VisualizarAnuncio_Anuncio_Sem_Estatistica_Dispara_Exception()
        {
            target.VisualizarAnuncio(new Anuncio(null, null, null));
        }

        [TestMethod]
        public void VisualizarAnuncio_Anuncio_Com_Estatistica_Incrementa_VisualizacoesAnuncio_Chama_Repositorio_Incluir_Atualizar()
        {
            uint visitas = 10;
            Anuncio anuncio = new Anuncio(null, new Automovel(new Modelo()), null);
            EstatisticaAnuncio estatistaAnuncio = new EstatisticaAnuncio(anuncio) { VisualizacoesAnuncio = visitas } ;

            repositorioEstatisticaAnuncioMock.Setup(r => r.ObterEstatisticaDoAnuncio(anuncio)).Returns(estatistaAnuncio);

            target.VisualizarAnuncio(anuncio);

            repositorioEstatisticaAnuncioMock.Verify(r => r.ObterEstatisticaDoAnuncio(anuncio));
            repositorioEstatisticaAnuncioMock.Verify(r => r.Atualizar(estatistaAnuncio));
            Assert.AreEqual(++visitas, estatistaAnuncio.VisualizacoesAnuncio);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VisualizarTelefoneDoAnuncio_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.VisualizarTelefoneDoAnuncio(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void VisualizarTelefoneDoAnuncio_Anuncio_Sem_Estatistica_Dispara_Exception()
        {
            target.VisualizarTelefoneDoAnuncio(new Anuncio(null, null, null));
        }

        [TestMethod]
        public void VisualizarTelefoneDoAnuncio_Anuncio_Com_Estatistica_Incrementa_VisualizacoesTelefone_Chama_Repositorio_Incluir_Atualizar()
        {
            uint visitas = 10;
            Anuncio anuncio = new Anuncio(null, new Automovel(new Modelo()), null);
            EstatisticaAnuncio estatistaAnuncio = new EstatisticaAnuncio(anuncio) { VisualizacoesTelefone = visitas };

            repositorioEstatisticaAnuncioMock.Setup(r => r.ObterEstatisticaDoAnuncio(anuncio)).Returns(estatistaAnuncio);

            target.VisualizarTelefoneDoAnuncio(anuncio);

            repositorioEstatisticaAnuncioMock.Verify(r => r.ObterEstatisticaDoAnuncio(anuncio));
            repositorioEstatisticaAnuncioMock.Verify(r => r.Atualizar(estatistaAnuncio));
            Assert.AreEqual(++visitas, estatistaAnuncio.VisualizacoesTelefone);
        }
    }
}
