using Newtonsoft.Json;
using PruebasCandidatos.Modelos;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PruebasCandidatos.Interfaces
{
    public interface IWebTreeViewService
    {
        Task<List<ItemsJSON>> GetListado();
        
    }
}
