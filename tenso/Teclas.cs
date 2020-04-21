using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tenso
{
    public class Teclas
    {
        public int Quantidade { get; set; }
        public string NomeTecla { get; set; }

        public Teclas(int quantidade, string nomeTecla)
        {
            Quantidade = quantidade;
            NomeTecla = nomeTecla;
        }
    }
}
