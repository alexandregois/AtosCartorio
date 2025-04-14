using System;
using System.ComponentModel.DataAnnotations;

namespace AtosCartorio.Models
{
    public class ObitoModel
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataFalecimento { get; set; }
        public string NomeFalecido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime? DataNascimentoPai { get; set; }
        public DateTime? DataNascimentoMae { get; set; }
    }
}
