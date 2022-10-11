// See https://aka.ms/new-console-template for more information

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
    services.AddSingleton<IFlashCardService, FlashCardService>();
    services.AddSingleton<IStackService, StackService>();
    services.AddSingleton<IMenus, Menus>();
    services.AddSingleton<StacksManager, StacksManager>();
    services.AddSingleton<FlashCardsManager, FlashCardsManager>();
}