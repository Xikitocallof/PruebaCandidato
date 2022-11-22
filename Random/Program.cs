//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();

using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        Random numAleatorios = new Random();
        string ruta = ".\\ArchivosGenerados\\numerosRandom.txt";

        Console.WriteLine("Generando archivo de números de 32 bits aleatorios...\r");

        try
        {
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            using (FileStream numerosRandom = File.Create(ruta))
            {
                for (int a = 0; a < 100000; a++)
                {
                    Byte[] numeros = new UTF8Encoding(true).GetBytes(numAleatorios.Next().ToString() + "\r");
                    numerosRandom.Write(numeros);
                }
            }
            Console.WriteLine("Archivo generado correctamente.\r");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
