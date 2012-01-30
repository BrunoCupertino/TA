using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoModelo
    {
        List<Modelo> ObterModelosPorMarca(Marca marca);
    }
}
