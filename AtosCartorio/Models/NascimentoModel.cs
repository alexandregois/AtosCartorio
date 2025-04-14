using System;
using System.ComponentModel.DataAnnotations;

namespace AtosCartorio.Models
{
    public class NascimentoModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomePai { get; set; }
        public DateTime? DataNascimentoPai { get; set; }
        public string NomeMae { get; set; }
        public DateTime? DataNascimentoMae { get; set; }
        public DateTime DataRegistro { get; set; }
        public string CpfPai { get; set; }
        public string CpfMae { get; set; }
    }
}
