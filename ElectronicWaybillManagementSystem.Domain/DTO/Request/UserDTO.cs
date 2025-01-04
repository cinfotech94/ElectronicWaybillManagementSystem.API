using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicWaybillManagementSystem.Domain.Entities
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string oName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.fName)
                           .Length(3, 50).WithMessage("name should be between 3 to 50 character")
                           .NotEmpty().WithMessage("must not be empty")
                           .NotNull().WithMessage("MUST NOT BE NULL");
        }

    }
}
