using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtosCartorio.Models
{
    public class CasamentoView
    {
        public int Id { get; set; }
        public string NomeConjuge1 { get; set; }
        public string NomeConjuge2 { get; set; }
        public DateTime DataCasamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public CasamentoModel ModeloOriginal { get; set; }

    }
}
