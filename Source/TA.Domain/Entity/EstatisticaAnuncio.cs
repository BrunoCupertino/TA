using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class EstatisticaAnuncio : EntidadeBase
    {
        public Anuncio Anuncio { get; set; }
        public uint VisualizacoesAnuncio { get; set; }
        public uint VisualizacoesTelefone { get; set; }

        public override string ToString()
        {
            return this.Anuncio.ToString();
        }
    }
}
