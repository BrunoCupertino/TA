using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Anuncio : IEntidade
    {
        public int Id { get; set; }
        public int Visitas { get; set; }
        public StatusAnuncio Status { get; set; }
        public DateTime Data { get; set; }
    }
}
