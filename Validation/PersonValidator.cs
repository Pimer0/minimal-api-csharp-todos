using FluentValidation;
using minimal_api_csharp_todos.data.models;

namespace minimal_api_csharp_todos.Validation;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Lastname).NotEmpty();
    }
}