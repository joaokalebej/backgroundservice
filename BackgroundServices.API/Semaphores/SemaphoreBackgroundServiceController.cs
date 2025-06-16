namespace BackgroundServices.API.Semaphores;

public static class SemaphoreBackgroundServiceController
{
    //Semáforo compartilhado entre os serviços
    //Parametro 1: Apenas uma thread pode acessar o recurso por vez
    //Parametro 2: Número máximo de permissões que o semáforo pode conceder

    private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

    //Método para adquirir o semáforo (bloquear a execução)
    public static async Task UseResourceAsync()
    {
        await Semaphore.WaitAsync();
    }

    public static void ReleaseResource()
    {
        Semaphore.Release();
    }
}