using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("You cannot leave the first name field blank.");
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Please enter at least 3 characters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("You cannot leave the last name field blank.");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Please enter at least 3 characters.");

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("You cannot leave the birthdate field blank.");
        }
    }
}
