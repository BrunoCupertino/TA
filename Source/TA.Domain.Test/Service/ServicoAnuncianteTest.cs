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

        //TODO: Testar Incluir e Atualizar
    }
}
