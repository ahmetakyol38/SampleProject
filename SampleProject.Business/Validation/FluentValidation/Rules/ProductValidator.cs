using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SampleProject.Entities.Concrete;

namespace SampleProject.Business.Validation.FluentValidation.Rules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Lütfen ürün adını belirtiniz.")
                .Length(5, 100).WithMessage("Lütfen ürün adını 5-100 karakter sayısı aralığında belirtiniz.");

            RuleFor(m => m.Price)
                .NotNull().WithMessage("Lütfen ürün fiyatını belirtiniz.")
                .GreaterThan(0m).WithMessage("Ürün fiyatı 0 dan büyük olmalıdır.");

            RuleFor(m => m.UnitsInStock)
                .NotNull().WithMessage("Lütfen ürün stok adetini belirtiniz.")
                .GreaterThanOrEqualTo(0).WithMessage("Ürün adeti 0 dan küçük olamaz.");
        }
    }
}
