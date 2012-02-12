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
        private Mock<IRepositorioAnuncio> repositorioAnuncioMock;
        private Mock<IServicoAnunciante> servicoAnuncianteMock;
        private Mock<IServicoAutomovel> servicoAutomovelMock;

        private IServicoAnuncio target;

        public ServicoAnuncioTest()
        {
            repositorioAnuncioMock = new Mock<IRepositorioAnuncio>();
            servicoAnuncianteMock = new Mock<IServicoAnunciante>();
            servicoAutomovelMock = new Mock<IServicoAutomovel>();
            target = new ServicoAnuncio(repositorioAnuncioMock.Object, servicoAnuncianteMock.Object,
                servicoAutomovelMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Anunciar_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.Anuciar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Anunciar_Plano_Do_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            Anuncio anuncio = new Anuncio() { Plano = null };
            target.Anuciar(anuncio);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Anunciar_Plano_Do_Anuncio_Inativo_Dispara_Exception()
        {
            Anuncio anuncio = new Anuncio() { Plano = new Plano() { Ativo = false } };
            target.Anuciar(anuncio);
        }

        [TestMethod]
        public void Anunciar_Valido_Chama_Incluir_AnuncianteAutomovel_DataAnuncio_Atual_Status_AguardandoAprovacao()
        {
            Automovel automovel = new Automovel();
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio()
            {
                Plano = new Plano() { Ativo = true },
                Automovel = automovel,
                Anunciante = anunciante
            };

            target.Anuciar(anuncio);

            servicoAnuncianteMock.Verify(s => s.Incluir(anunciante));
            servicoAutomovelMock.Verify(s => s.Incluir(automovel));
            repositorioAnuncioMock.Verify(s => s.Anuciar(anuncio));

            Assert.AreEqual(anuncio.Data.ToShortDateString(), DateTime.Now.ToShortDateString());
            Assert.AreEqual(anuncio.Status, StatusAnuncio.AguardandoAprovacao);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Atualizar_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.Atualizar(null);
        }

        [TestMethod]
        public void Atualizar_Anuncio_Valido_Chama_Atualizar_Automovel()
        {
            Automovel automovel = new Automovel();
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio()
            {
                Plano = new Plano() { Ativo = true },
                Automovel = automovel,
                Anunciante = anunciante
            };

            target.Atualizar(anuncio);

            servicoAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Excluir_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.Excluir(null);
        }

        [TestMethod]
        public void Excluir_Anuncio_Valido_Chama_Atualizar_Automovel()
        {
            Automovel automovel = new Automovel();
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio()
            {
                Plano = new Plano() { Ativo = true },
                Automovel = automovel,
                Anunciante = anunciante
            };

            target.Excluir(anuncio);

            servicoAutomovelMock.Verify(s => s.Excluir(automovel));
            repositorioAnuncioMock.Verify(s => s.Excluir(anuncio));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ObterAnuncioPorId_idAnuncio_Invalido_Dispara_Exception()
        {
            Anuncio anuncio = new Anuncio() { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            target.ObterAnuncioPorId(2);
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));            
        }

        [TestMethod]
        public void ObterAnuncioPorId_idAnuncio_Valido_Retorna_Anuncio()
        {
            Anuncio anuncio = new Anuncio() { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            Assert.AreEqual(anuncio, target.ObterAnuncioPorId(1));
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));            
        }
    }
}
