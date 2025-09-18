using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Domain.Entities
{
    public class ContaSaldo
    {
        public ContaSaldo(long conta, decimal valor)
        {
            Conta = conta;
            Saldo = valor;
        }
        public long Conta { get; private set; }
        public decimal Saldo { get; private set; }

        public bool PodeDebitar(decimal valor) => Saldo >= valor;

        public void Debitar(decimal valor)
        {
            if (!PodeDebitar(valor))
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;
        }

        public void Creditar(decimal valor)
        {
            Saldo += valor;
        }
    }
}
