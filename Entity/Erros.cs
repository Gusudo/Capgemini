using System.Collections.Generic;
using System.Linq;

namespace projcapgemini 
{
    public class Erros
    {
        public List<string> ListaErros { get; set; }
        public int Linha { get; private set; }
        public bool HasError { get { return ListaErros.ToArray().Count() > 0;} }

        public Erros(int linha)
        {
            Linha = linha;
        }
    }
}