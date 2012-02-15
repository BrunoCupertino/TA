using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public class Automovel : EntidadeBase
    {
        public Automovel(Modelo modelo)
        {
            this.Modelo = modelo;
        }

        public uint AnoFabricacao { get; set; }
        public uint AnoModelo { get; set; }        
        public string Placa { get; set; }        
        public float Quilometragem { get; set; }
        public TipoAutomovel TipoAutomovel { get; set; }
        public uint ParcelasRestantes { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorParcela { get; set; }
        public uint? Portas { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public List<Opcional> Opcionais { get; set; }
        public Combustivel Combustivel { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}/{2}", this.Modelo.ToString(), this.AnoModelo, this.AnoFabricacao);
        }
    }
}
