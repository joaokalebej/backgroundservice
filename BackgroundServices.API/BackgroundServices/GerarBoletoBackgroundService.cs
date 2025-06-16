namespace DefaultNamespace;

public class GerarBoletoBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    public GerarBoletoBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            ProcessarGeracaoBoleto(stoppingToken);
        }
    }
    
    
}