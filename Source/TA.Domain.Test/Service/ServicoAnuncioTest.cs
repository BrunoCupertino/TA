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
        private Mock<IRepositorioAutomovel> repositorioAutomovelMock;
        private Mock<IRepositorioEstatisticaAnuncio> repositorioEstatisticaAnuncioMock;
        private Mock<IServicoAnunciante> servicoAnuncianteMock;

        private IServicoAnuncio target;

        public ServicoAnuncioTest()
        {
            repositorioAnuncioMock = new Mock<IRepositorioAnuncio>();
            repositorioAutomovelMock = new Mock<IRepositorioAutomovel>();
            repositorioEstatisticaAnuncioMock = new Mock<IRepositorioEstatisticaAnuncio>();
            servicoAnuncianteMock = new Mock<IServicoAnunciante>();

            target = new ServicoAnuncio(repositorioAnuncioMock.Object, repositorioAutomovelMock.Object,
                repositorioEstatisticaAnuncioMock.Object, servicoAnuncianteMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Anunciar_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.Anunciar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Anunciar_Plano_Do_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            Anuncio anuncio = new Anuncio(new Anunciante(), new Automovel(null), null);
            target.Anunciar(anuncio);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Anunciar_Automovel_Do_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            Anuncio anuncio = new Anuncio(new Anunciante(), null, new Plano());
            target.Anunciar(anuncio);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Anunciar_Anuncio_Invalido_Dispara_Exception_4_Erros()
        {
            Anuncio anuncio = new Anuncio(new Anunciante(), new Automovel(null), new Plano() { Ativo = false });

            try
            {
                target.Anunciar(anuncio);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(4, ex.Message.Split('\n').Where(e => !string.IsNullOrEmpty(e)).Count());
                throw;
            }
        }

        [TestMethod]
        public void Anunciar_Anuncio_Valido_Chama_Servico_Incluir_Anunciante_Automovel__Estatistica_DataAnuncio_Atual_Status_AguardandoAprovacao()
        {
            Automovel automovel = new Automovel(new Modelo()) { ParcelasRestantes = 1, ValorParcela = 10.00M };
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });
            EstatisticaAnuncio estatisticaAnuncio = new EstatisticaAnuncio(anuncio);

            target.Anunciar(anuncio);

            servicoAnuncianteMock.Verify(s => s.Incluir(anunciante));
            repositorioAutomovelMock.Verify(s => s.Incluir(automovel));
            repositorioEstatisticaAnuncioMock.Verify(s => s.Incluir(estatisticaAnuncio));
            repositorioAnuncioMock.Verify(s => s.Anuciar(anuncio));

            Assert.AreEqual(DateTime.Now.ToShortDateString(), anuncio.Data.ToShortDateString());
            Assert.AreEqual(StatusAnuncio.AguardandoAprovacao, anuncio.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Atualizar_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.Atualizar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Atualizar_Plano_Do_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            Anuncio anuncio = new Anuncio(new Anunciante(), new Automovel(null), null);
            target.Atualizar(anuncio);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Atualizar_Automovel_Do_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            Anuncio anuncio = new Anuncio(new Anunciante(), null, new Plano());
            target.Atualizar(anuncio);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Atualizar_Anuncio_Invalido_Dispara_Exception_4_Erros()
        {
            Anuncio anuncio = new Anuncio(null, new Automovel(null), new Plano() { Ativo = false });

            try
            {
                target.Atualizar(anuncio);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(4, ex.Message.Split('\n').Where(e => !string.IsNullOrEmpty(e)).Count());
                throw;
            }
        }

        [TestMethod]
        public void Atualizar_Anuncio_Valido_Chama_Servico_Atualizar_Automovel_Repositorio_Atualizar()
        {
            Automovel automovel = new Automovel(new Modelo()) { ParcelasRestantes = 1, ValorParcela = 10.00M };
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });

            target.Atualizar(anuncio);

            repositorioAutomovelMock.Verify(s => s.Atualizar(automovel));
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
            Automovel automovel = new Automovel(new Modelo());
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });
            EstatisticaAnuncio estatisticaAnuncio = new EstatisticaAnuncio(anuncio);

            repositorioEstatisticaAnuncioMock.Setup(s => s.ObterEstatisticaDoAnuncio(anuncio)).Returns(estatisticaAnuncio);

            target.Excluir(anuncio);

            repositorioAutomovelMock.Verify(s => s.Excluir(automovel));            
            repositorioEstatisticaAnuncioMock.Verify(s => s.Excluir(estatisticaAnuncio));
            repositorioAnuncioMock.Verify(s => s.Excluir(anuncio));
        }

        [TestMethod]
        public void ObterAnuncioPorId_IdAnuncio_Invalido_Retorna_Nulo_Chama_Repositorio_ObterAnuncioPorId()
        {
            Anuncio anuncio = new Anuncio(null, null, null) { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            Assert.AreEqual(null, target.ObterAnuncioPorId(++anuncio.Id));
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));
        }

        [TestMethod]
        public void ObterAnuncioPorId_IdAnuncio_Valido_Retorna_Anuncio_Chama_Repositorio_ObterAnuncioPorId()
        {
            Anuncio anuncio = new Anuncio(null, null, null) { Id = 1 };

            repositorioAnuncioMock.Setup(r => r.ObterAnuncioPorId(anuncio.Id)).Returns(anuncio);

            Assert.AreEqual(anuncio, target.ObterAnuncioPorId(anuncio.Id));
            repositorioAnuncioMock.Verify(r => r.ObterAnuncioPorId(anuncio.Id));
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
        public void ObterAnunciosAprovadosPagosEmDestaque_Chama_Repositorio()
        {
            target.ObterAnunciosAprovadosPagosEmDestaque();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosAprovadosPagosEmDestaque());
        }

        [TestMethod]
        public void ObterAnunciosAprovadosPagosMaisVisitados_Chama_Repositorio()
        {
            target.ObterAnunciosAprovadosPagosMaisVisitados();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosAprovadosPagosMaisVisitados());
        }

        [TestMethod]
        public void ObterAnunciosAprovadosPagosRecentes_Chama_Repositorio()
        {
            target.ObterAnunciosAprovadosPagosRecentes();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosAprovadosPagosRecentes());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AprovarAnuncio_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.AprovarAnuncio(null);
        }

        [TestMethod]
        public void AprovarAnuncio_Anuncio_Valido_Chama_Atualizar_Automovel_Chama_Repositorio()
        {
            Automovel automovel = new Automovel(new Modelo()) { ParcelasRestantes = 1, ValorParcela = 10.00M };
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });
            
            target.AprovarAnuncio(anuncio);

            repositorioAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(StatusAnuncio.Aprovado, anuncio.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AprovarAnuncios_Anuncios_Nulo_Dispara_ArgumentNullException()
        {
            target.AprovarAnuncios(null);
        }

        [TestMethod]
        public void AprovarAnuncios_Anuncio_Valido_Chama_Atualizar_Automovel_Chama_Repositorio()
        {
            Automovel automovel = new Automovel(new Modelo()) { ParcelasRestantes = 1, ValorParcela = 10.00M };
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });

            target.AprovarAnuncios(new List<Anuncio> { anuncio });

            repositorioAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(StatusAnuncio.Aprovado, anuncio.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReprovarAnuncio_Anuncio_Nulo_Dispara_ArgumentNullException()
        {
            target.ReprovarAnuncio(null);
        }

        [TestMethod]
        public void ReprovarAnuncio_Anuncio_Valido_Chama_Atualizar_Automovel_Chama_Repositorio()
        {
            Automovel automovel = new Automovel(new Modelo()) { ParcelasRestantes = 1, ValorParcela = 10.00M };
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });

            target.ReprovarAnuncio(anuncio);

            repositorioAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(StatusAnuncio.Reprovado, anuncio.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReprovarAnuncios_Anuncios_Nulo_Dispara_ArgumentNullException()
        {
            target.ReprovarAnuncios(null);
        }

        [TestMethod]
        public void ReprovarAnuncios_Anuncio_Valido_Chama_Atualizar_Automovel_Chama_Repositorio()
        {
            Automovel automovel = new Automovel(new Modelo()) { ParcelasRestantes = 1, ValorParcela = 10.00M };
            Anunciante anunciante = new Anunciante();
            Anuncio anuncio = new Anuncio(anunciante, automovel, new Plano() { Ativo = true });

            target.ReprovarAnuncios(new List<Anuncio> { anuncio });

            repositorioAutomovelMock.Verify(s => s.Atualizar(automovel));
            repositorioAnuncioMock.Verify(s => s.Atualizar(anuncio));
            Assert.AreEqual(StatusAnuncio.Reprovado, anuncio.Status);
        }

        [TestMethod]
        public void ObterAnunciosAguardandoAprovacao_Chama_Repositorio()
        {
            target.ObterAnunciosAguardandoAprovacao();

            repositorioAnuncioMock.Verify(r => r.ObterAnunciosAguardandoAprovacao());
        }
    }
}
