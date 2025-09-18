using TransacaoFinanceira.Domain.Entities;


namespace TransacaoFinanceira.Infrastructure.Interface
{
    public interface IContaRepository
    {
        ContaSaldo GetSaldo(long conta);
        bool Atualizar<T>(T conta) where T : ContaSaldo;

    }
}
