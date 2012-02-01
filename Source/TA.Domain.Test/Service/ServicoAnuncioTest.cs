using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TA.Domain.Service;
using TA.Domain.Entity;
using Moq;
using TA.Domain.Repository;

namespace TA.Domain.Test.Service
{
    [TestClass]
    public class ServicoAnuncioTest
    {
        private Mock<IRepositorioAnuncio> repositorioMock;
        private IServicoAnuncio target;

        public ServicoAnuncioTest()
        {
            repositorioMock = new Mock<IRepositorioAnuncio>();
            target = new ServicoAnuncio(repositorioMock.Object);
        }

        #region IServicoAnuncio Members

        [TestMethod]
        public void Anuciar_Deve_Chamar_Anunciar_Do_Repositorio()
        {
            var anuncio = new Anuncio();
            

            target.Anuciar(anuncio);
            repositorioMock.Verify(r => r.Anuciar(anuncio), Times.Once());
        }

        [TestMethod]
        public void AtualizarAnuncio(Anuncio anuncio)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ExcluirAnuncio(Anuncio anuncio)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public Anuncio ObterAnuncioPorId(int id)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Detalhar_Anuncio_Por_Id_Valido_Deve_Incrementar_Visitas_E_Atualizar()
        {
            var visitas = 50;
            var anuncio = new Anuncio() { Id = 1, Status = StatusAnuncio.Aprovado, Visitas = visitas };
            repositorioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            var anuncioSalvo = target.DetalharAnuncioPorId(anuncio.Id);

            Assert.IsTrue(visitas + 1 == anuncioSalvo.Visitas);
            repositorioMock.Verify(r => r.AtualizarAnuncio(anuncio));
        }

        [TestMethod]
        public void ObterAnunciosDoAnunciante(Anunciante anunciante)
        {
        }

        [TestMethod]
        public List<Anuncio> ObterAnunciosEmDestaque()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public List<Anuncio> ObterAnunciosMaisVisitados()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public List<Anuncio> ObterAnunciosRecentes()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void AprovarAnuncio(Anuncio anuncio)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void AprovarAnunciosPorId(List<int> ids)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DesaprovarAnuncio(Anuncio anuncio)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DesaprovarAnunciosPorId(List<int> ids)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public List<Anuncio> ObterAnunciosAguardandoAprovacao()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
