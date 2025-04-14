using System;
using Microsoft.EntityFrameworkCore;

namespace AtosCartorio.Models
{
    [Owned]
    public class ConjugeModel
    {
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime? DataNascimentoPai { get; set; }
        public DateTime? DataNascimentoMae { get; set; }
        public string CpfPai { get; set; }
        public string CpfMae { get; set; }
    }
}
