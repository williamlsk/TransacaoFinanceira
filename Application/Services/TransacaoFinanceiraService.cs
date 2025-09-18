using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoFinanceira.Domain.Entities;
using TransacaoFinanceira.Domain.Validator;
using TransacaoFinanceira.Infrastructure.Interface;

namespace TransacaoFinanceira.Application.Services
{
    public class TransacaoFinanceiraService
    {

        private readonly IContaRepository _contaRepository;
        private readonly TransacaoValidator _validator;

        public TransacaoFinanceiraService(IContaRepository contaRepository, TransacaoValidator validator)
        {
            _contaRepository = contaRepository;
            _validator = validator;
        }

        public bool Transferir(int correlationId, long contaOrigemId, long contaDestinoId, decimal valor)
        {
            var contaOrigem = _contaRepository.GetSaldo(contaOrigemId);
            var contaDestino = _contaRepository.GetSaldo(contaDestinoId);

            if (!_validator.ValidarTransacao(valor, contaOrigem, contaDestino, out var motivo))
            {
                Console.WriteLine($"Transação {correlationId} cancelada: {motivo}");
                return false;
            }

            contaOrigem.Debitar(valor);
            contaDestino.Creditar(valor);

            _contaRepository.Atualizar(contaOrigem);
            _contaRepository.Atualizar(contaDestino);

            Console.WriteLine($"Transação {correlationId} efetuada com sucesso.");
            return true;
        }

    }
}
