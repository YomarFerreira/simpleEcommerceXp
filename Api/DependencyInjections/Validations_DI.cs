using Application.Validators.Cliente;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Api.DependencyInjections
{
    public static class ValidationsDI
    {
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateClienteCommandValidator>();
            return services;
        }
    }
}
