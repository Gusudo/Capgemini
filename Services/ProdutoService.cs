using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projcapgemini
{
    public class ProdutoService
    {
        public IEnumerable<ArquivoConsolidadoViewModel> GetImportacoesConsolidado()
        {
            var produtoRepositorio = new ProdutoRepositorio();
            var arquivos = produtoRepositorio.GetImportacoesFake(20);

            return arquivos.GroupBy(p => p.NomeProduto).Select(x => new ArquivoConsolidadoViewModel
            {
                MenorDataEntrega = (DateTime)x.Min(d => d.DataEntrega),
                NomeProduto = x.First().NomeProduto,
                QuantidadeTotal = (int)x.Sum(q => q.Quantidade),
                ValorTotal = (float)x.Sum(v => v.ValorUnitario)
            }).ToList();
        }

        public IEnumerable<Arquivo> GetImportacoes()
        {
            var produtoRepositorio = new ProdutoRepositorio();
            var arquivos = produtoRepositorio.GetImportacoesFake(20);

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

        public dynamic Insert(IFormFile file)
        {
            var produtoRepositorio = new ProdutoRepositorio();
            var path = produtoRepositorio.GravarArquivo(file);
            var obj = produtoRepositorio.ObterDadosExcel(path);

            // this.HttpContext.Response.StatusCode = 201;
            return obj;
        }

    }
}