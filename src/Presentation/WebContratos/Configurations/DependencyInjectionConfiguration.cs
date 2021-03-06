﻿using Microsoft.Extensions.DependencyInjection;
using PGLaw.Infra.Cross.IoC;

namespace PGLaw.Presentation.WebContratos.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
