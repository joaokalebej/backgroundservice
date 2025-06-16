using BackgroundServices.API.Semaphores;
using BackgroundServices.API.Services.Interfaces;

namespace BackgroundServices.API.BackgroundServices;

public class BaixaAutomaticaBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public BaixaAutomaticaBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessarBaixaAutomatica(stoppingToken);
        }
    }

    private async Task ProcessarBaixaAutomatica(CancellationToken stoppingToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var baixaAutomaticaService = scope.ServiceProvider.GetRequiredService<IOperacoesBancariasServices>();

            await SemaphoreBackgroundServiceController.UseResourceAsync(); //Adquirindo o semáforo.
            
            await baixaAutomaticaService.ExecutarBaixaAutomatica();
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            SemaphoreBackgroundServiceController.ReleaseResource(); //Liberando o semáforo.
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
}