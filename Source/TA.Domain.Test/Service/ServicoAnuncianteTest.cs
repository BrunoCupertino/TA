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
    public class ServicoAnuncianteTest
    {
        private Mock<IRepositorioAnunciante> repositorioAnuncianteMock;

        private IServicoAnunciante target;

        public ServicoAnuncianteTest()
        {
            this.repositorioAnuncianteMock = new Mock<IRepositorioAnunciante>();

            target = new ServicoAnunciante(repositorioAnuncianteMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Incluir_Anunciante_Nulo_Dispara_ArgumentNullException()
        {
            target.Incluir(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Incluir_Anunciante_Invalido_Dispara_Exception_5_Erros()
        {
            try
            {
                Anunciante anunciante = new Anunciante();
                target.Incluir(anunciante);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(5, ex.Message.Split('\n').Where(e => !string.IsNullOrWhiteSpace(e)).Count());
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Incluir_Anunciante_Valido_Menor_18_Anos_Dispara_Exception_1_Erro()
        {
            try
            {
                Anunciante anunciante = new Anunciante()
                {
                    Nome = "Teste",
                    Email = "teste@teste.com",
                    Telefone = "(11)1234-4321",
                    DataNascimento = DateTime.Now,
                    Cidade = new Cidade()
                };

                target.Incluir(anunciante);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(1, ex.Message.Split('\n').Where(e => !string.IsNullOrWhiteSpace(e)).Count());
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Incluir_Anunciante_Valido_Email_Ja_Existente_Chamar_Repositorio_ObterObterAnuncianteDeEmail_Dispara_Exception()
        {
            Anunciante anunciante = new Anunciante()
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Telefone = "(11)1234-4321",
                DataNascimento = new DateTime(1988, 5, 12),
                Cidade = new Cidade()
            };

            repositorioAnuncianteMock.Setup(r => r.ObterAnuncianteDeEmail(anunciante.Email)).Returns(anunciante);

            target.Incluir(anunciante);
            repositorioAnuncianteMock.Verify(r => r.ObterAnuncianteDeEmail(anunciante.Email));
        }

        [TestMethod]
        public void Incluir_Anunciante_Valido_Data_Cadastro_DataAtual_Chama_Repositorio_ObterAnuncianteDeEmail_Incluir()
        {
            Anunciante anunciante = new Anunciante()
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Telefone = "(11)1234-4321",
                DataNascimento = new DateTime(1988, 5, 12),
                Cidade = new Cidade()
            };

            target.Incluir(anunciante);
            repositorioAnuncianteMock.Verify(r => r.ObterAnuncianteDeEmail(anunciante.Email));
            repositorioAnuncianteMock.Verify(r => r.Incluir(anunciante));
            Assert.AreEqual(DateTime.Now.ToShortDateString(), anunciante.DataCadastro.ToShortDateString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Atualizar_Anunciante_Nulo_Dispara_ArgumentNullException()
        {
            target.Atualizar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Atualizar_Anunciante_Invalido_Dispara_Exception_5_Erros()
        {
            try
            {
                Anunciante anunciante = new Anunciante();
                target.Atualizar(anunciante);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(5, ex.Message.Split('\n').Where(e => !string.IsNullOrWhiteSpace(e)).Count());
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Atualizar_Anunciante_Valido_Menor_18_Anos_Dispara_Exception_1_Erro()
        {
            try
            {
                Anunciante anunciante = new Anunciante()
                {
                    Nome = "Teste",
                    Email = "teste@teste.com",
                    Telefone = "(11)1234-4321",
                    DataNascimento = DateTime.Now,
                    Cidade = new Cidade()
                };

                target.Atualizar(anunciante);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(1, ex.Message.Split('\n').Where(e => !string.IsNullOrWhiteSpace(e)).Count());
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Atualizar_Anunciante_Valido_Email_Ja_Existente_Chamar_Repositorio_ObterObterAnuncianteDeEmail_Dispara_Exception()
        {
            Anunciante anunciante = new Anunciante()
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Telefone = "(11)1234-4321",
                DataNascimento = new DateTime(1988, 5, 12),
                Cidade = new Cidade()
            };

            repositorioAnuncianteMock.Setup(r => r.ObterAnuncianteDeEmail(anunciante.Email)).Returns(anunciante);

            target.Atualizar(anunciante);
            repositorioAnuncianteMock.Verify(r => r.ObterAnuncianteDeEmail(anunciante.Email));
        }

        [TestMethod]
        public void Atualizar_Anunciante_Valido_Chama_Repositorio_ObterAnuncianteDeEmail_Atualizar()
        {
            Anunciante anunciante = new Anunciante()
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Telefone = "(11)1234-4321",
                DataNascimento = new DateTime(1988, 5, 12),
                Cidade = new Cidade()
            };

            target.Atualizar(anunciante);
            repositorioAnuncianteMock.Verify(r => r.ObterAnuncianteDeEmail(anunciante.Email));
            repositorioAnuncianteMock.Verify(r => r.Atualizar(anunciante));
        }
    }
}
