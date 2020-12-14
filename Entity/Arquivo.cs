using System;
using System.Collections.Generic;

namespace projcapgemini
{
    public class Arquivo : Erros
    {
        public DateTime? DataEntrega { get; private set; }
        public string NomeProduto { get; private set; }
        public int? Quantidade { get; private set; }
        public float? ValorUnitario { get; private set; }

        public Arquivo(int linha, DateTime? dataEntrega, string nomeProduto, int? quantidade, float? valorUnitario) : base(linha)
        {
            ListaErros = new List<string>();

            DataEntrega = dataEntrega;
            NomeProduto = nomeProduto;
            Quantidade = (int)quantidade;
            ValorUnitario = (float)valorUnitario;

            if (dataEntrega <= DateTime.Now)
                ListaErros.Add("Campo data é menor ou igual a data atual.");

            if (nomeProduto.Length > 50)
                ListaErros.Add("Campo nome possui mais de 50 caracteres.");

            if (quantidade == null || quantidade == 0)
                ListaErros.Add("Campo quantidade tem que ser maior que zero.");
            
            if(valorUnitario == null || valorUnitario == 0)
                ListaErros.Add("Campo valor unitário tem que ser maior que zero.");
        }
    }
}