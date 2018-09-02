using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Testing1.Models;
using Testing1.RepositoriesInterfaces;

namespace Testing1.Repositories
{
    public class TransacoesRepository : ITransacoesRepository
    {

        private readonly IConfiguration _config;

        public TransacoesRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Testing1"));
            }
        }

        public async Task AddTransacoes(Transacoes transacao)
        {
            using (IDbConnection conn = Connection)
            {
                try
                {
                    conn.Execute(@"insert Transacoes (Descricao)
                                    values (@Descricao)", transacao);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //con.Close();
                }
            }
        }

        public async Task DeleteTransacoes(Transacoes Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transacoes>> GetTransacoes()
        {
            throw new NotImplementedException();
        }

        public async Task<Transacoes> GetTransacaoById(int Id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT ID, Descricao FROM Transacoes WHERE ID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<Transacoes>(sQuery, new { ID = Id });
                return result.FirstOrDefault();
            }
        }

        public async Task UpdateTransacoes(Transacoes transacao)
        {
            throw new NotImplementedException();
        }
    }
}
