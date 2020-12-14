using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data.OleDb;

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

        public dynamic ObterDadosExcel(string path)
        {
            dynamic obj = new ExpandoObject();
            obj.statusCode = 201;

            OleDbConnection connect = new OleDbConnection($@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {path}; Extended Properties = 'Excel 12.0 Xml;HDR=YES'; ");
            string comandoSql = "Select * from [Planilha1$]";
            OleDbCommand comando = new OleDbCommand(comandoSql, connect);
            List<Arquivo> listaDeArquivos = new List<Arquivo>();

            try
            {
                int linha = 1;
                connect.Open();
                OleDbDataReader rd = comando.ExecuteReader();

                while (rd.Read())
                {
                    var teste = (DateTime)rd["Data Entrega"];
                    var arquivo = new Arquivo
                    (
                        linha,
                        (DateTime)rd["Data Entrega"],
                        rd["Nome do Produto"].ToString(),
                        Convert.ToInt32(rd["Quantidade"]),
                        float.Parse(rd["Valor Unitário"].ToString())

                    );

                    listaDeArquivos.Add(arquivo);
                    
                    if (arquivo.HasError)
                    {
                        obj.statusCode = 400;
                        obj.returnObject = listaDeArquivos;
                        return obj;
                    }
                    linha++;
                }

                if (listaDeArquivos.Count() > 0)
                {
                    obj.returnObject = listaDeArquivos;
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                //Console.WriteLine("Não foi possivel ler a planilha do excel.");
                return null;
            }
            finally
            {
                connect.Close();
            }
            //return new List<Arquivo>();
        }
        public string GravarArquivo(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"Files\\{file.FileName}");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return path;
        }
    }

}