using System;

namespace projcapgemini
{
    public class ArquivoConsolidadoViewModel
    {
        public string NomeProduto { get; set; }
        public DateTime MenorDataEntrega { get; set; }
        public int QuantidadeTotal { get; set; }
        public float ValorTotal { get; set; }
    }
}