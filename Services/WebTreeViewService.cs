using Newtonsoft.Json;
using PruebasCandidatos.Interfaces;
using PruebasCandidatos.Modelos;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PruebasCandidatos.Services
{
    public class WebTreeViewService: IWebTreeViewService
    {

        public async Task<List<ItemsJSON>> GetListado()
        {

            string archivoJSON = ".\\Archivos\\Items.json";
            var listado = new List<ItemsJSON>();

            if (File.Exists(archivoJSON))
            {
                using (StreamReader jsonStream = File.OpenText(archivoJSON))
                {
                    var json = jsonStream.ReadToEnd();
                    listado = JsonConvert.DeserializeObject<List<ItemsJSON>>(json);
                }
                return listado;
            }
            else
            {
                throw new Exception("Archivo no encontrado");
            }

        }
    }
}
