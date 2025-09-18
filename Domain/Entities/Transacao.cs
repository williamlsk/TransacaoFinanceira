using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Domain.Entities
{
    internal record Transacao
    {
        public int CorrelationId { get; set; }
        public string DateTime { get; set; }
        public long ContaOrigem { get; set; }
        public long ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
