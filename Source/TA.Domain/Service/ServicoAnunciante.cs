using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Repository;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public class ServicoAnunciante : IServicoAnunciante
    {
        private IRepositorioAnunciante repositorioAnunciante;

        public ServicoAnunciante(IRepositorioAnunciante repositorioAnunciante)
        {
            this.repositorioAnunciante = repositorioAnunciante;
        }

        private void ValidarAnunciante(Anunciante anunciante)
        {
            if (anunciante == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(anunciante.Nome))
            {
                erros.AppendLine("Nome inválido");
            }

            if (string.IsNullOrWhiteSpace(anunciante.Email))
            {
                erros.AppendLine("Email inválido.");
            }

            if (string.IsNullOrWhiteSpace(anunciante.Telefone))
            {
                erros.AppendLine("Telefone inválido.");
            }

            if (anunciante.DataNascimento == DateTime.MinValue)
            {
                erros.AppendLine("Data de nascimento inválida");
            }

            if (DateTime.Now.Year - anunciante.DataNascimento.Year < 18)
            {
                erros.AppendLine("O anunciante deve no mínimo 18 anos de idade.");
            }

            if (anunciante.Cidade == null)
            {
                erros.AppendLine("Cidade inválida.");
            }

            if (erros.Length > 0)
            {
                throw new Exception(erros.ToString());
            }
        }

        private void ValidarSeEmailExiste(string email)
        {
            if (this.repositorioAnunciante.ObterAnuncianteDeEmail(email) != null)
            {
                throw new Exception("Já existe um anunciante com o mesmo email.");
            }
        }

        #region IServicoAnunciante Members

        public void Incluir(Anunciante anunciante)
        {
            this.ValidarAnunciante(anunciante);
            this.ValidarSeEmailExiste(anunciante.Email);

            anunciante.DataCadastro = DateTime.Now;

            this.repositorioAnunciante.Incluir(anunciante);
        }

        public void Atualizar(Anunciante anunciante)
        {
            this.ValidarAnunciante(anunciante);
            this.ValidarSeEmailExiste(anunciante.Email);

            this.repositorioAnunciante.Atualizar(anunciante);
        }

        #endregion
    }
}
