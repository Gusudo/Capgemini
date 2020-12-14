using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projcapgemini;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // GET api/values
        [HttpGet, Route("v1/getimportacoesconsolidado")]
        public IEnumerable<ArquivoConsolidadoViewModel> GetImportacoesConsolidado()
        {
            var produtoService = new ProdutoService();
            return produtoService.GetImportacoesConsolidado();
        }

        [HttpGet, Route("v1/getimportacoes")]
        public IEnumerable<Arquivo> GetImportacoes()
        {
            var produtoService = new ProdutoService();
            return produtoService.GetImportacoes();
        }

        [HttpGet("v1/getimportacao/{id:int:min(1)}")]
        public Arquivo GetImportacao(int id)
        {

            var produtoService = new ProdutoService();
            dynamic dados = produtoService.GetImportacao(id);
            this.HttpContext.Response.StatusCode = dados.statusCode;
            return dados.returnObject;
        }

        // POST api/values
        [HttpPost, Route("v1/list")]
        public ActionResult<IEnumerable<object>> Post([FromBody] string value)
        {
            var obj = new List<object>();

            obj.Add(new {
                prop1 = "aaa",
                prop2 = "bbb"
            });

            return obj;
        }

        [HttpPost, Route("v1/insert")]
        public IEnumerable<Arquivo> Insert()
        {
            var produtoService = new ProdutoService();
            dynamic dados = produtoService.Insert();
            this.HttpContext.Response.StatusCode = dados.statusCode;

            return dados.returnObject;
        }
    }
}
