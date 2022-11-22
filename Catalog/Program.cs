//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();

using Catalog.Models;
using System.Text.Json;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        string categoriesCsv = ".\\ArchivosCsv\\Categories.csv";
        string productsCsv = ".\\ArchivosCsv\\Products.csv";
        string rutaJSON = ".\\ArchivosGenerados\\Catalog.json";
        string rutaXML = ".\\ArchivosGenerados\\Catalog.xml";

        Console.WriteLine("Generando archivos .JSON y .XML a partir de archivos .CSV...\r");

        try
        {
            if (File.Exists(categoriesCsv) && File.Exists(productsCsv))
            {
                if (File.Exists(rutaJSON))
                {
                    File.Delete(rutaJSON);
                }
                if (File.Exists(rutaXML))
                {
                    File.Delete(rutaXML);
                }

                // Leer archivo Categories.csv
                List<CategoriasModel> categories = new List<CategoriasModel>();
                string csvCategories = File.ReadAllText(categoriesCsv);
                foreach (string row in csvCategories.Split("\r\n"))
                {
                    if (!string.IsNullOrEmpty(row) && row.Split(";")[0] != "Id")
                    {
                        categories.Add(new CategoriasModel
                        {
                            Id = Convert.ToInt32(row.Split(";")[0]),
                            Name = row.Split(";")[1],
                            Description = row.Split(";")[2]
                        });
                    }
                }

                // Leer archivo Products.csv
                List<ProductosModel> products = new List<ProductosModel>();
                string csvProducts = File.ReadAllText(productsCsv);
                foreach (string row in csvProducts.Split("\r\n"))
                {
                    if (!string.IsNullOrEmpty(row) && row.Split(";")[0] != "Id")
                    {
                        products.Add(new ProductosModel
                        {
                            Id = Convert.ToInt32(row.Split(";")[0]),
                            CategoryId = Convert.ToInt32(row.Split(";")[1]),
                            Name = row.Split(";")[2],
                            Price = Convert.ToDouble(row.Split(";")[3])
                        });
                    }
                }

                // Relacionar ambos listados
                List<CatalogoModel> catalogo = new List<CatalogoModel>();
                foreach (var cat in categories)
                {
                    catalogo.Add(new CatalogoModel
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        Description = cat.Description,
                        Productos = products.Where(x => x.CategoryId == cat.Id).ToList()
                    });
                }

                // Generar archivo JSON

                var options = new JsonSerializerOptions { WriteIndented = true };
                string catalogoJSON = JsonSerializer.Serialize(catalogo, options);
                File.WriteAllText(rutaJSON, catalogoJSON);

                // Generar archivo XML

                using (FileStream ficheroXML = File.Create(rutaXML))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = ("    ");
                    settings.CloseOutput = true;
                    using (XmlWriter writer = XmlWriter.Create(ficheroXML, settings))
                    {
                        writer.WriteStartElement("ArrayOfCategory");
                        foreach (var cat in catalogo)
                        {
                            writer.WriteStartElement("Category");
                            writer.WriteElementString("Description", cat.Description);
                            writer.WriteElementString("Id", cat.Id.ToString());
                            writer.WriteElementString("Name", cat.Name);
                            writer.WriteStartElement("Products");
                            foreach (var pro in cat.Productos)
                            {
                                writer.WriteStartElement("Product");
                                writer.WriteElementString("CategoryId", pro.CategoryId.ToString());
                                writer.WriteElementString("Id", pro.Id.ToString());
                                writer.WriteElementString("Name", pro.Name);
                                writer.WriteElementString("Price", pro.Price.ToString());
                                writer.WriteEndElement();

                            }
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.Flush();
                    }
                }
                Console.WriteLine("Archivos generados correctamente.\r");
            }
            else
            {
                Console.WriteLine("Los archivos Categories.csv y Products.csv no existen o no se encuentran.\r");
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}