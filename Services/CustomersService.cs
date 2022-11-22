using Microsoft.EntityFrameworkCore;
using PruebasCandidatos.BBDD;
using PruebasCandidatos.BBDD.Models;
using PruebasCandidatos.Interfaces;

namespace PruebasCandidatos.Services
{
    public class CustomersService: ICustomersService
    {
        private readonly CustomersContext _ctx;

        public CustomersService(CustomersContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Customers>> GetCustomers()
        {
            string customersCsv = ".\\Archivos\\Customers.csv";

            //try
            //{
            if (File.Exists(customersCsv))
            {
                // Leer archivo Customers.csv
                Customers customer = new Customers();
                string csvCustomers = File.ReadAllText(customersCsv);
                foreach (string row in csvCustomers.Split("\r\n"))
                {
                    if (!string.IsNullOrEmpty(row) && row.Split(";")[0] != "Id")
                    {
                        customer = new Customers();
                        
                        customer = new Customers
                        {
                            Id = row.Split(";")[0],
                            Name = row.Split(";")[1],
                            Address = row.Split(";")[2],
                            City = row.Split(";")[3],
                            Country = row.Split(";")[4],
                            PostalCode = row.Split(";")[5],
                            Phone = row.Split(";")[6],
                        };
                        var id = _ctx.Customers.FirstOrDefault(x => x.Id == customer.Id);
                        if (id == null)
                        {
                            _ctx.Customers.Add(customer);
                            _ctx.SaveChanges();
                        }
                    }
                }
            }

            var listadoCustomers = await _ctx.Customers.AsQueryable().ToListAsync();
            return listadoCustomers;

        }
    }
}
