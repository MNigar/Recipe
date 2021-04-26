using FluentValidation;
using RecipeBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBLL.Validators
{
    public class MenuValidator : AbstractValidator<RecipeDTO>
    {
        public MenuValidator()
        {

            RuleFor(x => x.Description).NotEmpty();

        }
    }
}
