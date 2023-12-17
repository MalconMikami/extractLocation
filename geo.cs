using Azure;
using Azure.Core.GeoJson;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;

public class geo
{
    public string buscar(decimal lat, decimal lon)
    {
        AzureKeyCredential credential = new AzureKeyCredential("N7jFWwukGYdrJnRz68mQGthPFQB0IvIx5u9R9cSBcz8");
        MapsSearchClient client = new MapsSearchClient(credential);


         Response<SearchAddressResult> fuzzySearchResponse =  client.FuzzySearch("COCO BAMBU FLORIA", new FuzzySearchOptions
        {
            Coordinates = new GeoPosition(-48.51666, -27.5889),
            Language = SearchLanguage.PortugueseBrazil,
            Top=10,
            RadiusInMeters=500
        });

       

        var retorno = "";
        foreach (SearchAddressResultItem result in fuzzySearchResponse.Value.Results)
        {
            retorno = result.Address.FreeformAddress;
            Console.WriteLine("Coordinate: {0}, Address: {1}",
                result.Position, result.Address.FreeformAddress);

            Console.WriteLine("Nome:" + result.PointOfInterest.Name);

            foreach(var b in result.PointOfInterest.Brands)
                Console.WriteLine("Marca:" + b.Name);
            
            foreach(var c in result.PointOfInterest.Categories)
                Console.WriteLine("Categorias:" + c);
        }
        return retorno;
    }
}
