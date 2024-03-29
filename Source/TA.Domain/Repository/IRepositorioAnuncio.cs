﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioAnuncio
    {
        void Anuciar(Anuncio anuncio);
        void Atualizar(Anuncio anuncio);
        void Excluir(Anuncio anuncio);
        Anuncio ObterAnuncioPorId(ulong id);
        List<Anuncio> ObterAnunciosDoAnunciante(Anunciante anunciante);
        List<Anuncio> ObterAnunciosAprovadosPagosEmDestaque();
        List<Anuncio> ObterAnunciosAprovadosPagosMaisVisitados();
        List<Anuncio> ObterAnunciosAprovadosPagosRecentes();
        List<Anuncio> ObterAnunciosAguardandoAprovacao(); 
    }
}
