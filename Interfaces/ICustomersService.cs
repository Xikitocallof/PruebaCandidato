using Newtonsoft.Json;
using PruebasCandidatos.BBDD;
using PruebasCandidatos.BBDD.Models;
using PruebasCandidatos.Modelos;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PruebasCandidatos.Interfaces
{
    public interface ICustomersService
    {
        Task<List<Customers>> GetCustomers();


    }
}
