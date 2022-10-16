// See https://aka.ms/new-console-template for more information

using FlashCards.Backend;
using FlashCards.Backend.Services;
using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI;
using FlashCards.UI.Controllers;
using FlashCards.UI.Menus;
using FlashCards.UI.Menus.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

ConfigureServices(services);
services
    .AddSingleton<App,App>()
    .BuildServiceProvider()
    .GetService<App>()
    ?.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IMenus, Menus>();
    services.AddTransient<StacksController, StacksController>();
    services.AddTransient<FlashCardsController, FlashCardsController>();
    services.RegisterBackendServices();
}