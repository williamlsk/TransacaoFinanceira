using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoFinanceira.Application;
using TransacaoFinanceira.Domain.Entities;
using TransacaoFinanceira.Infrastructure.Interface;

namespace TransacaoFinanceira.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly List<ContaSaldo> _saldos;

        public ContaRepository()
        {
            _saldos = new List<ContaSaldo>
            {
                new ContaSaldo(938485762, 180),
                new ContaSaldo(347586970, 1200),
                new ContaSaldo(2147483649, 0),
                new ContaSaldo(675869708, 4900),
                new ContaSaldo(238596054, 478),
                new ContaSaldo(573659065, 787),
                new ContaSaldo(210385733, 10),
                new ContaSaldo(674038564, 400),
                new ContaSaldo(563856300, 1200)
            };
        }
        public bool Atualizar<T>(T conta) where T : ContaSaldo
        {
            if (conta == null)
                throw new ArgumentNullException(nameof(conta));

            _saldos.RemoveAll(x => x.Conta == conta.Conta);
            _saldos.Add(conta);
            return true;
        }
                ContaSaldo IContaRepository.GetSaldo(long conta)
        {
            return (ContaSaldo)Convert.ChangeType(_saldos.Find(x => x.Conta == conta), typeof(ContaSaldo));
        }
    }
}
