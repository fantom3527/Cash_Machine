using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using CashMachine.Application.Contracts.Services.Users;
using CashMachine.Application.Managers;
using CashMachine.Application.Services.BankAccounts;
using CashMachine.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>(); 
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<IBankAccountHistoryService, BankAccountHistoryService>();
            services.AddScoped<CurrentUserManager>();
            services.AddScoped<ICurrentUserManager>(
                p => p.GetRequiredService<CurrentUserManager>());
            services.AddScoped<CurrentBankAccountManager>();
            services.AddScoped<ICurrentBankAccountManager>(
                p => p.GetRequiredService<CurrentBankAccountManager>());

            return services;
        }
    }
}
