using BlazorNonConformity.Models;

namespace BlazorNonConformity.Data.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> GetFornecedorById(int id);
        Task<List<Fornecedor>> GetAll();
        Task<int> UpdateFornecedor(Fornecedor fornecedor);
        Task<int> DeleteFornecedor(int id);
        Task<int> AddFornecedor(Fornecedor fornecedor);
    }
}
