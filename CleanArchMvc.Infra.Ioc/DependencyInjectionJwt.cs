using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CleanArchMvc.Infra.Ioc
{
    // Quando se cria um metodo de extensão ele dever ser em uma classe estatica
    public static class DependencyInjectionJwt
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
        {

            // Informar o tipo de autenticação JWT-Bearer
            // Definir o modelo de desafio de autenticação 
            services.AddAuthentication(opt =>
            {
                // Esquema padrao de autenticação
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            // Habilita a autenticação JWT usando o esquema e desafio definidos 
            //Validar o Token
            .AddJwtBearer(options =>
            {
                // Habilitar a autenticação e validar o token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Oque validar
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //Valores válidos
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    // Faz com que o tempo de vida do token anterior tenha mais cinco minutos
                    ClockSkew = TimeSpan.Zero
                };

            });
            return services;
        }



    }
}
