using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicWaybillManagementSystem.Domain.Parameter
{
    public class StaffIdParameterValidator
    {
        public string staffId { get; set; }
    }
    public class staffIdParameterValdator:AbstractValidator<StaffIdParameterValidator>
    {
        public staffIdParameterValdator()
        {
            RuleFor(x => x.staffId)
                .Length(14).WithMessage("must be 14 digit")
            .NotNull().WithMessage("staffId ncannot be null")
            .NotEmpty().WithMessage("staffId ncannot be empty");
        }
    }
}
