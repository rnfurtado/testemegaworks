using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Entities
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public int BancoId { get; set; }
        public int NumeroConta { get; set; }
        public int NumeroAgencia { get; set; }
        public DateTime DataAbertura { get; set; }
        public int Situacao { get; set; }
    }
}
