using System;

namespace AtosCartorio.Models
{
    public class CasamentoModel
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataCasamento { get; set; }
        public ConjugeModel Conjuge1 { get; set; }
        public ConjugeModel Conjuge2 { get; set; }
    }
}
