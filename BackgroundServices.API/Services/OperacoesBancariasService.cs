using BackgroundServices.API.Services.Interfaces;

namespace BackgroundServices.API.Services;

public class OperacoesBancariasService : IOperacoesBancariasServices
{
    public OperacoesBancariasService()
    {
    }

    public async Task ExecutarBaixaAutomatica()
    {
        var i = 0;
        while (i < 100)
        {
            Console.WriteLine($"Processando baixa automática: {i}");
            Thread.Sleep(1000);
            Console.WriteLine($"Baixa número {i} processada com sucesso.");
            i++;
        }
    }

    public async Task GerarBoleto()
    {
        throw new NotImplementedException();
    }
}