using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Repository;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public class ServicoPagamento : IServicoPagamento
    {
        private IRepositorioPagamento repositorioPagamento;
        private IServicoPagamentoPagSeguro servicoPagamentoPagSeguro;

        public ServicoPagamento(IRepositorioPagamento repositorioPagamento,
                                IServicoPagamentoPagSeguro servicoPagamentoPagSeguro)
        {
            this.repositorioPagamento = repositorioPagamento;
            this.servicoPagamentoPagSeguro = servicoPagamentoPagSeguro;
        }

        #region IServicoPagamento Members

        public Pagamento ObterPagamentoDoAnuncioDeId(ulong idAnuncio)
        {
            return this.repositorioPagamento.ObterPagamentoDoAnuncioDeId(idAnuncio);
        }

        public Pagamento ObterPagamentoDoAnuncio(Anuncio anuncio)
        {
            if (anuncio == null)
            {
                throw new ArgumentNullException();
            }

            return this.repositorioPagamento.ObterPagamentoDoAnuncio(anuncio);
        }

        public Uri IncluirPagamentoDoAnuncio(Anuncio anuncio)
        {
            Uri uri = null;
            Pagamento pagamento = new Pagamento(anuncio);

            if (anuncio == null || anuncio.Plano == null)
            {
                throw new ArgumentNullException();
            }

            if (!anuncio.Plano.Ativo)
            {
                throw new Exception("Plano inválido");
            }

            pagamento.Status = StatusPagamento.AguardandoPagamento;

            repositorioPagamento.Incluir(pagamento);

            if (anuncio.Plano.Valor == 0)
            {
                this.Pagar(pagamento);
            }
            else
            {
                uri = this.servicoPagamentoPagSeguro.RequisitarPagamento(pagamento);
            }

            return uri;
        }

        public void EnviarParaAnalise(Pagamento pagamento)
        {
            if (pagamento == null || pagamento.Anuncio == null)
            {
                throw new ArgumentNullException();
            }

            pagamento.Status = StatusPagamento.EmAnalise;

            this.repositorioPagamento.Atualizar(pagamento);
        }

        public void Pagar(Pagamento pagamento)
        {
            if (pagamento == null || pagamento.Anuncio == null)
            {
                throw new ArgumentNullException();
            }

            pagamento.Status = StatusPagamento.Pago;
            pagamento.Data = DateTime.Now;

            this.repositorioPagamento.Atualizar(pagamento);
        }

        public void Cancelar(Pagamento pagamento)
        {
            if (pagamento == null || pagamento.Anuncio == null)
            {
                throw new ArgumentNullException();
            }

            pagamento.Status = StatusPagamento.Cancelado;

            this.repositorioPagamento.Atualizar(pagamento);
        }

        #endregion
    }
}
