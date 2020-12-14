using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace projcapgemini
{
    public class ProdutoService
    {
        public IEnumerable<ArquivoConsolidadoViewModel> GetImportacoesConsolidado()
        {
            var arquivos = new List<Arquivo>();

            for (int i = 1; i < 10; i++)
            {
                var nomeProduto = i > 4 ? $"Teste {i}" : "Teste 1";

                var arquivo = new Arquivo(i, DateTime.Now.AddDays(i), nomeProduto, 4+i, i);
                
                arquivos.Add(arquivo); 

            }
            return arquivos.GroupBy(p => p.NomeProduto).Select(x => new ArquivoConsolidadoViewModel
            {
                MenorDataEntrega = x.Min(d => d.DataEntrega),
                Nome = x.First().NomeProduto,
                QuantidadeTotal = x.Sum(q => q.Quantidade),
                ValorTotal = x.Sum(v => v.ValorUnitario)
            }).ToList();
        }

        public IEnumerable<Arquivo> GetImportacoes()
        {
           var arquivos = new List<Arquivo>();

            for (int i = 1; i < 10; i++)
            {
                var nomeProduto = i > 4 ? $"Teste {i}" : "Teste 1";

                var arquivo = new Arquivo(i, DateTime.Now.AddDays(i), nomeProduto, 4+i, i);
                
                arquivos.Add(arquivo); 

            }
            return arquivos;
        }

        public dynamic GetImportacao(int id)
        {
            dynamic obj = new ExpandoObject();
            if (id == 5)
            {
                obj.statusCode = 404;
                obj.returnObject = null;
                // this.HttpContext.Response.StatusCode = 404;
                return obj;
            }
            obj.statusCode = 200;
            obj.returnObject = new Arquivo(id, DateTime.Now.AddDays(1), "Teste", 4, 1);
            return obj;
        }

        public dynamic Insert()
        {
            var arquivos = new List<Arquivo>();

            dynamic obj = new ExpandoObject();

            for (int i = 1; i < 10; i++)
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 3);

                var arquivo = new Arquivo(i, DateTime.Now.AddDays(value), "Teste", 4+i, value);
                
                arquivos.Add(arquivo);
                if (arquivo.HasError)
                {
                    obj.statusCode = 400;
                    obj.returnObject = arquivos;
                    // this.HttpContext.Response.StatusCode = 400;
                    return obj;
                }
                
            }
            obj.statusCode = 201;
            obj.returnObject = arquivos;
            // this.HttpContext.Response.StatusCode = 201;
            return obj;
        }

    }
}