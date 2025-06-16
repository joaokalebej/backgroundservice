namespace BackgroundServices.API.Services.Interfaces;

public interface IOperacoesBancariasServices
{
    Task ExecutarBaixaAutomatica();
    Task GerarBoleto();
}