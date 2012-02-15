using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoEstatisticaAnuncio
    {
        EstatisticaAnuncio ObterEstatisticaDoAnuncio(Anuncio anuncio);
        void VisualizarAnuncio(Anuncio anuncio);
        void VisualizarTelefoneDoAnuncio(Anuncio anuncio);
    }
}
