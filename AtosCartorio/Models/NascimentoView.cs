using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtosCartorio.Models
{
    public class NascimentoView
    {
        public int Id { get; set; }
        public string NomeRegistrado { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataNascimentoMae { get; set; }
        public DateTime? DataNascimentoPai { get; set; }
        public string CpfMae { get; set; }
        public string CpfPai { get; set; }
        public DateTime DataRegistro { get; set; }
        public NascimentoModel ModeloOriginal { get; set; }

        // Propriedade para mostrar o nome completo do registrado
        public string NomeCompleto => NomeRegistrado;

    }
}
