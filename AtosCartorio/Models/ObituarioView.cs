using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtosCartorio.Models
{
    public class ObituarioView
    {
        public int Id { get; set; }
        public string NomeFalecido { get; set; }
        public DateTime? DataFalecimento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataRegistro { get; set; }
        public ObitoModel ModeloOriginal { get; set; }
    }
}
