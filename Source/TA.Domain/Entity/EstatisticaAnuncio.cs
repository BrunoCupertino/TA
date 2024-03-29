﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class EstatisticaAnuncio : EntidadeBase
    {
        public EstatisticaAnuncio(Anuncio anuncio)
        {
            this.Anuncio = anuncio;
        }

        public Anuncio Anuncio { get; set; }
        public uint VisualizacoesAnuncio { get; set; }
        public uint VisualizacoesTelefone { get; set; }
    }
}
