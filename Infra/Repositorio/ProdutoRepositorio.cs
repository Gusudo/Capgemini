using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace projcapgemini
{
    public class ProdutoRepositorio
    {
        public IEnumerable<Arquivo> GetImportacoesFake(int qtd)
        {
            var arquivos = new List<Arquivo>();

            for (int i = 1; i < qtd + 1; i++)
            {
                var nomeProduto = i > 4 ? $"Teste {i}" : "Teste 1";

                var arquivo = new Arquivo(i, DateTime.Now.AddDays(i), nomeProduto, 4+i, i);
                
                arquivos.Add(arquivo); 

            }
            return arquivos;
        }
    }
}