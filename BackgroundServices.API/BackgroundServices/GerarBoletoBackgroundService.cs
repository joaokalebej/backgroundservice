using BackgroundServices.API.Semaphores;
using BackgroundServices.API.Services.Interfaces;

namespace DefaultNamespace;

public class GerarBoletoBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    public GerarBoletoBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessarGeracaoBoleto(stoppingToken);
        }
    }

    private async Task ProcessarGeracaoBoleto(CancellationToken stoppingToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var boletoService = scope.ServiceProvider.GetRequiredService<IOperacoesBancariasServices>();

            await SemaphoreBackgroundServiceController.UseResourceAsync();
            
            boletoService.GerarBoleto();
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            SemaphoreBackgroundServiceController.ReleaseResource();
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
        
    }
}