using Microsoft.EntityFrameworkCore;
using BlazorNonConformity.Data.Context;
using BlazorNonConformity.Data.Interfaces;
using BlazorNonConformity.Models;
using MySqlConnector;

namespace BlazorNonConformity.Data.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDBContext context;

        public FornecedorRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<int> AddFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor is null) return -1;
            try
            {
                context.Add(fornecedor);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {               
                return -1;
            }

        }

        public async Task<int> DeleteFornecedor(int id)
        {
            var fornecedor = await GetFornecedorById(id);
            if (fornecedor != null)
            {
                try
                {
                    context.Fornecedores.Remove(fornecedor);
                    return await context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    return -1;
                }
            }
            return (-1);
        }

        public async Task<List<Fornecedor>> GetAll()
        {
            return await context.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor>? GetFornecedorById(int id)
        {
            return await context.Fornecedores.FirstOrDefaultAsync(f => f.IdFornecedor == id);
        }

        public async Task<int> UpdateFornecedor(Fornecedor fornecedor)
        {
            context.Fornecedores.Update(fornecedor);
            return await context.SaveChangesAsync();
        }
    }
}
