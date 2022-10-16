using FlashCards.Backend.Contracts;
using FlashCards.Backend.DataAccess;
using FlashCards.Backend.Services;
using FlashCards.Backend.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.Backend;

public static class DependencyInjection
{
    public static void RegisterBackendServices(this ServiceCollection services)
    {
        services.AddTransient<IDatabase, Database>();
        services.AddTransient<IFlashCardRepository, FlashCardRepo>();
        services.AddTransient<IStackRepository, StackRepo>();
        services.AddTransient<IFlashCardService, FlashCardService>();
        services.AddTransient<IStackService, StackService>();

    }
}