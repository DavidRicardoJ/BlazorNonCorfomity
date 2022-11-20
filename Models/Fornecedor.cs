using System.ComponentModel.DataAnnotations;

namespace BlazorNonConformity.Models
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }

        public string? CNPJ { get; set; }

        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
    }
}
