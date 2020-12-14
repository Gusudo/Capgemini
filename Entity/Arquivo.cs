using System;
using System.Collections.Generic;

namespace projcapgemini
{
    public class Arquivo : Erros
    {
        public DateTime? DataEntrega { get; private set; }
        public string DataEntregaString { get { return Convert.ToDateTime(DataEntrega).ToString("dd/MM/yyyy");} }
        public DateTime? DataImportacao { get; private set; }
        public string DataImportacaoString { get { return Convert.ToDateTime(DataImportacao).ToString("dd/MM/yyyy");} }
        public string NomeProduto { get; private set; }
        public int? Quantidade { get; private set; }
        public float? ValorUnitario { get; private set; }

        public Arquivo(int linha, DateTime dataImportacao, DateTime? dataEntrega, string nomeProduto, int? quantidade, float? valorUnitario) : base(linha)
        {
            ListaErros = new List<string>();

            DataImportacao = dataImportacao;
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