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
        while (i < 20)
        {
            Console.WriteLine($"Processando baixa automática: {i}");
            Thread.Sleep(1000);
            Console.WriteLine($"Baixa número {i} processada com sucesso.");
            i++;
        }
    }

    public async Task GerarBoleto()
    {
        var i = 0;
        while (i < 20)
        {
            Console.WriteLine($"Processando geração de boleto: {i}");
            Thread.Sleep(1000);
            Console.WriteLine($"Boleto número {i} gerado com sucesso.");
            i++;
        }
    }
}