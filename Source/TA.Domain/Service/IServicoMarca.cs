using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Service
{
    public interface IServicoMarca
    {
        List<Marca> ObterTodasMarcasDeCarro();
        List<Marca> ObterTodaMarcasDeMoto();
    }
}
