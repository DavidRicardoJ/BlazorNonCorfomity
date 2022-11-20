using BlazorNonConformity.Models;
using FluentValidation;

namespace BlazorNonCorfomity.Models.ValidationsModels
{
    public class ValidationFornecedor : AbstractValidator<Fornecedor>
    {
        public ValidationFornecedor()
        {
            RuleFor(x => x.IdFornecedor)
                .NotNull().WithMessage("Código não pode ser nulo.")
                .GreaterThan(0).WithMessage("O código deve ser maior que zero.")
                .NotEmpty().WithMessage("O campo não pode ser vazio.");

            RuleFor(x => x.RazaoSocial)
               .NotNull().WithMessage("O campo é obrigatório.")
               .NotEmpty().WithMessage("O campo não pode se vazio.")
               .MinimumLength(5).WithMessage("O campo deve ter no minímo 5 caracteres.")
               .MaximumLength(90).WithMessage("Máximo de 90 caracteres.");

            RuleFor(x => x.NomeFantasia)
              .NotNull().WithMessage("O campo é obrigatório.")
              .NotEmpty().WithMessage("O campo não pode se vazio.")
              .MinimumLength(5).WithMessage("O campo deve ter no minímo 5 caracteres.")
              .MaximumLength(90).WithMessage("Máximo de 90 caracteres.");

            RuleFor(x => x.CNPJ)
              .NotNull().WithMessage("O campo é obrigatório.")
              .NotEmpty().WithMessage("O campo não pode se vazio.")
              .Length(18).WithMessage("O campo deve ter 18 caracteres.")
              .Matches("(^(\\d{2}.\\d{3}.\\d{3}/\\d{4}-\\d{2})|(\\d{14})$)").WithMessage("Formato do CNPJ incorreto.");



        }
    }
}
