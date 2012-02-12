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
        public void Anunciar_Valido_Chama_Servico_Incluir_Anunciante_Automovel_DataAnuncio_Atual_Status_AguardandoAprovacao()
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
        public void Atualizar_Anuncio_Valido_Chama_Servico_Atualizar_Automovel_Repositorio_Atualizar()
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
        public void Excluir_Anuncio_Valido_Chama_Servico_Excluir_Automovel_Repositorio_Excluir()
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
        public void ObterAnuncioPorId_IdAnuncio_Invalido_Dispara_Exception()
        {
            Anuncio anuncio = new Anuncio() { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            target.ObterAnuncioPorId(++anuncio.Id);
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));
        }

        [TestMethod]
        public void ObterAnuncioPorId_IdAnuncio_Valido_Retorna_Anuncio_Chama_Repositorio_ObterAnuncioPorId()
        {
            Anuncio anuncio = new Anuncio() { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            Assert.AreEqual(anuncio, target.ObterAnuncioPorId(anuncio.Id));
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IncrementarVisitasDoAnuncio_IdAnuncio_Invalido_Dispara_Exception()
        {
            Anuncio anuncio = new Anuncio() { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            target.IncrementarVisitasDoAnuncio(++anuncio.Id);
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));
        }

        [TestMethod]
        public void IncrementarVisitasDoAnuncio_IdAnuncio_Valido_Retorna_Anuncio_Com_Visitas_Incrementadas_E_Atualizado()
        {
            int visitas = 10;
            Automovel automovel = new Automovel();
            Anuncio anuncio = new Anuncio()
            {
                Id = 1,
                Visitas = visitas,
                Plano = new Plano() { Ativo = true },
                Automovel = automovel
            };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            Assert.AreEqual(anuncio, target.IncrementarVisitasDoAnuncio(anuncio.Id));
            Assert.AreEqual(++visitas, anuncio.Visitas);
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));
            servicoAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObterAnunciosDoAnunciante_Anunciante_Nulo_Dispara_AgumentNullException()
        {
            target.ObterAnunciosDoAnunciante(null);
        }

        [TestMethod]
        public void ObterAnunciosDoAnunciante_Anunciante_Valido_Chama_Repositorio()
        {
            Anunciante anunciante = new Anunciante();

            target.ObterAnunciosDoAnunciante(anunciante);

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosDoAnunciante(anunciante));
        }

        [TestMethod]
        public void ObterAnunciosPagosEmDestaque_Chama_Repositorio()
        {
            target.ObterAnunciosPagosEmDestaque();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosPagosEmDestaque());
        }

        [TestMethod]
        public void ObterAnunciosPagosMaisVisitados_Chama_Repositorio()
        {
            target.ObterAnunciosPagosMaisVisitados();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosPagosMaisVisitados());
        }

        [TestMethod]
        public void ObterAnunciosPagosRecentes_Chama_Repositorio()
        {
            target.ObterAnunciosPagosRecentes();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosPagosRecentes());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AprovarAnuncio_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.AprovarAnuncio(null);
        }

        [TestMethod]
        public void AprovarAnuncio_Anuncio_Valido_Chama_Atualizar_Automovel()
        {
            Automovel automovel = new Automovel();
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio()
            {
                Plano = new Plano() { Ativo = true },
                Automovel = automovel,
                Anunciante = anunciante
            };

            target.AprovarAnuncio(anuncio);

            servicoAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(anuncio.Status, StatusAnuncio.Aprovado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AprovarAnuncios_Anuncios_Nulo_Dispara_ArgumentNullException()
        {
            target.AprovarAnuncios(null);
        }

        [TestMethod]
        public void AprovarAnuncios_Anuncio_Valido_Chama_Atualizar_Automovel()
        {
            Automovel automovel = new Automovel();
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio()
            {
                Plano = new Plano() { Ativo = true },
                Automovel = automovel,
                Anunciante = anunciante
            };

            target.AprovarAnuncios(new List<Anuncio> { anuncio });

            servicoAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(anuncio.Status, StatusAnuncio.Aprovado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReprovarAnuncios_Anuncios_Nulo_Dispara_ArgumentNullException()
        {
            target.ReprovarAnuncios(null);
        }

        [TestMethod]
        public void ReprovarAnuncios_Anuncio_Valido_Chama_Atualizar_Automovel()
        {
            Automovel automovel = new Automovel();
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio()
            {
                Plano = new Plano() { Ativo = true },
                Automovel = automovel,
                Anunciante = anunciante
            };

            target.ReprovarAnuncios(new List<Anuncio> { anuncio });

            servicoAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(anuncio.Status, StatusAnuncio.Reprovado);
        }

        [TestMethod]
        public void ObterAnunciosAguardandoAprovacao_Chama_Repositorio()
        {
            target.ObterAnunciosAguardandoAprovacao();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosAguardandoAprovacao());
        }
    }
}
