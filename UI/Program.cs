using System.Collections.Concurrent;
using System.Threading.Tasks;
using TransacaoFinanceira.Application.Services;
using TransacaoFinanceira.Domain.Entities;
using TransacaoFinanceira.Domain.Validator;
using TransacaoFinanceira.Infrastructure.Repositories;



//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var transacoes = new ConcurrentBag<Transacao>(new[]
            {
               new Transacao { CorrelationId=1, DateTime="09/09/2023 14:15:00", ContaOrigem=938485762L, ContaDestino=2147483649L, Valor=150M },
               new Transacao { CorrelationId=2, DateTime="09/09/2023 14:15:05", ContaOrigem=2147483649L, ContaDestino=210385733L, Valor=149M },
               new Transacao { CorrelationId=3, DateTime="09/09/2023 14:15:29", ContaOrigem=347586970L, ContaDestino=238596054L, Valor=1100M },
               new Transacao { CorrelationId=4, DateTime="09/09/2023 14:17:00", ContaOrigem=675869708L, ContaDestino=210385733L, Valor=5300M },
               new Transacao { CorrelationId=5, DateTime="09/09/2023 14:18:00", ContaOrigem=238596054L, ContaDestino=674038564L, Valor=1489M },
               new Transacao { CorrelationId=6, DateTime="09/09/2023 14:18:20", ContaOrigem=573659065L, ContaDestino=563856300L, Valor=49M },
               new Transacao { CorrelationId=7, DateTime="09/09/2023 14:19:00", ContaOrigem=938485762L, ContaDestino=2147483649L, Valor=44M },
               new Transacao { CorrelationId=8, DateTime="09/09/2023 14:19:01", ContaOrigem=573659065L, ContaDestino=675869708L, Valor=150M },
            });

            var repository = new ContaRepository();
            var validator = new TransacaoValidator();
            var service = new TransacaoFinanceiraService(repository, validator);

            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

            Parallel.ForEach(transacoes, parallelOptions, item =>
            {
                service.Transferir(item.CorrelationId, item.ContaOrigem, item.ContaDestino, item.Valor);
            });
        }
    }
}
