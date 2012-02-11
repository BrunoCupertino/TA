﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using TA.Domain.Repository;

namespace TA.Domain.Service
{
    public class ServicoAnuncio : IServicoAnuncio
    {
        private IRepositorioAnuncio repositorioDeAnuncios;

        public ServicoAnuncio(IRepositorioAnuncio repositorioDeAnuncios)
        {
            this.repositorioDeAnuncios = repositorioDeAnuncios;
        }

        #region IServicoAnuncio Members

        public void Anuciar(Anuncio anuncio)
        {
            //validar
            anuncio.Data = DateTime.Now;
            this.repositorioDeAnuncios.Anuciar(anuncio);
        }

        public void AtualizarAnuncio(Anuncio anuncio)
        {
            //validar
            this.repositorioDeAnuncios.AtualizarAnuncio(anuncio);
        }

        public void ExcluirAnuncio(Anuncio anuncio)
        {
            //validar
            this.repositorioDeAnuncios.ExcluirAnuncio(anuncio);
        }

        public Anuncio ObterAnuncioPorId(int id)
        {
            return this.repositorioDeAnuncios.ObterAnuncioPorId(id);
        }

        public Anuncio IncrementarVisitasDoAnuncio(Anuncio anuncio)
        {
            anuncio.Visitas++;
            this.AtualizarAnuncio(anuncio);
            return anuncio;
        }

        public List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante)
        {
            return this.repositorioDeAnuncios.ObterAnunciosDoAnunciante(anunciante);
        }

        public List<Anuncio> ObterAnunciosPagosEmDestaque()
        {
            return this.repositorioDeAnuncios.ObterAnunciosPagosEmDestaque();
        }

        public List<Anuncio> ObterAnunciosPagosMaisVisitados()
        {
            return this.repositorioDeAnuncios.ObterAnunciosPagosMaisVisitados();
        }

        public List<Anuncio> ObterAnunciosPagosRecentes()
        {
            return this.ObterAnunciosPagosRecentes();
        }

        public void AprovarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = StatusAnuncio.Aprovado;
            this.AtualizarAnuncio(anuncio);
        }

        public void AprovarAnuncios(List<Anuncio> anuncios)
        {
            anuncios.ForEach(e => this.AprovarAnuncio(e));
        }

        public void ReprovarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = StatusAnuncio.Reprovado;
            this.AtualizarAnuncio(anuncio);
        }

        public void ReprovarAnuncios(List<Anuncio> anuncios)
        {
            anuncios.ForEach(e => this.ReprovarAnuncio(e));
        }

        public List<Anuncio> ObterAnunciosAguardandoAprovacao()
        {
            return this.repositorioDeAnuncios.ObterAnunciosAguardandoAprovacao();
        }

        #endregion
    }
}
