using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using CashMachine.Application.Contracts.Services.Users;
using CashMachine.Application.Managers;
using CashMachine.Application.Services.BankAccounts;
using CashMachine.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Application.Extensions
{
    /// <summary>
    /// Сдержит метод расширения для IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Метод добавляющий зарегистрированные сервисы приложения в контейнер внедрения зависимостей.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Коллекция сервисов с добавленными приложением сервисами.</returns>
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
