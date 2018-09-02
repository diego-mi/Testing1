using System.Collections.Generic;
using System.Threading.Tasks;
using Testing1.Models;

namespace Testing1.RepositoriesInterfaces
{
    public interface ITransacoesRepository
    {
        Task<IEnumerable<Transacoes>> GetTransacoes();

        Task<Transacoes> GetTransacaoById(int Id);

        Task AddTransacoes(Transacoes transacao);

        Task UpdateTransacoes(Transacoes transacao);

        Task DeleteTransacoes(Transacoes Id);
    }
}