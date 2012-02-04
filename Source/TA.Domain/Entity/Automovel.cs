using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Automovel : IEntidade
    {
        public int Id { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }        
        public string Placa { get; set; }        
        public float Quilometragem { get; set; }
        public TipoAutomovel TipoAutomovel { get; set; }
        public int ParcelasRestantes { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorParcela { get; set; }
        public int? Portas { get; set; }
        public Modelo Modelo { get; set; }
        public Marca Marca { get; set; }
        public Cor Cor { get; set; }
        public List<Opcional> Opcionais { get; set; }
        public Combustivel Combustivel { get; set; }
    }
}
