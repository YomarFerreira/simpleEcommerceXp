namespace Api.DependencyInjections
{
    public static class MappersDI
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            // Registrar AutoMapper profiles aqui
            return services;
        }
    }
}
