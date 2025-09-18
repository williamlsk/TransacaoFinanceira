using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoFinanceira.Domain.Entities;

namespace TransacaoFinanceira.Domain.Validator
{
    public class TransacaoValidator
    {
        public bool ValidarTransacao(decimal valor, ContaSaldo contaOrigem, ContaSaldo contaDestino, out string motivo)
        {
            motivo = string.Empty;

            if (contaOrigem == null)
            {
                motivo = "Conta de origem não encontrada.";
                return false;
            }

            if (contaDestino == null)
            {
                motivo = "Conta de destino não encontrada.";
                return false;
            }

            if (valor <= 0)
            {
                motivo = "Valor da transação deve ser maior que zero.";
                return false;
            }

            if (contaOrigem.Saldo < valor)
            {
                motivo = "Saldo insuficiente na conta de origem.";
                return false;
            }

            return true;
        }

    }
}
