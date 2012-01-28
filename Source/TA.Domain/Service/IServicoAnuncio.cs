﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoAnuncio
    {
        void Anuciar(Anuncio anuncio);
        void EditarAnuncio(Anuncio anuncio);
        void ExcluirAnuncio(Anuncio anuncio);
        Anuncio ObterAnuncioPorId(int id);
        Anuncio DetalharAnuncioPorId(int id);
        Anuncio OberAnuncioPorAnunciante(Anunciante anunciante);
        List<Anuncio> ObterAnunciosEmDestaque();
        List<Anuncio> ObterAnunciosMaisVisitados();
        List<Anuncio> ObterAnunciosRecentes();
        void AprovarAnuncio(Anuncio anuncio);
        void AprovarAnunciosPorId(List<int> ids);
        void DesaprovarAnuncio(Anuncio anuncio);
        void DesaprovarAnunciosPorId(List<int> ids);
        List<Anuncio> ObterAnunciosParaAprovacao();               
    }
}
