using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.Domain.Repository
{
    public interface IRepositorioModelo
    {
        List<Modelo> ObterModelosDaMarca(Marca marca);
    }
}
