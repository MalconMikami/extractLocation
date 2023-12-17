using Azure;
using Azure.Core.GeoJson;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;

public class geoData
{
    public output buscar(input transacao)
    {
        AzureKeyCredential credential = new AzureKeyCredential("N7jFWwukGYdrJnRz68mQGthPFQB0IvIx5u9R9cSBcz8");
        MapsSearchClient client = new MapsSearchClient(credential);


        mockPosition m = new mockPosition();
        var geo = m.buscar(transacao);


        string pesquisa =  transacao.descricao_mcc.Substring(0,transacao.descricao_mcc.IndexOf("  "));
         Response<SearchAddressResult> fuzzySearchResponse =  client.FuzzySearch(pesquisa, new FuzzySearchOptions
        {
            Coordinates = new GeoPosition(geo.Longitude, geo.Latitude),
            Language = SearchLanguage.PortugueseBrazil,
            Top=1,
            RadiusInMeters=5000
        });

       
          
        // List<output> outs = new List<output>();
        // var retorno = "";
           output o = new output();
        foreach (SearchAddressResultItem result in fuzzySearchResponse.Value.Results)
        {
           
              o.Endereco = result.Address.FreeformAddress;
              o.Nome = result.PointOfInterest.Name;
              o.Categorias = new List<string>();

           

            foreach(var b in result.PointOfInterest.Brands)
            {
                o.Marca = b.Name;
            }
               
            
            foreach(var c in result.PointOfInterest.Categories)
            {
                o.Categorias.Add(c);
            }
              
        }
        return o;
    }
}


public class output
{
    public string Nome {get;set;}
    public string Endereco {get;set;}
    public string Marca {get;set;}
    public List<string> Categorias {get;set;}

}


public class input
{
    public string cod_conta {get;set;}
    public string account_id {get;set;}
    public string merchant {get;set;}

     public string  descricao_mcc {get;set;}
    public string  modo_compra {get;set;}

    public string  mcc {get;set;}

    public string  dt_transaction {get;set;}

    public string  amount {get;set;}

    public string  flag_compra_internacional {get;set;}


}


