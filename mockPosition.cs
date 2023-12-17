
using Azure.Core.GeoJson;

public class mockPosition
{
    public  GeoPosition buscar(input transacao)
    {
        GeoPosition g = new GeoPosition();
        if(transacao.cod_conta == "3744828")
        {
            if(transacao.dt_transaction.Contains("2023-11-02"))
                g = new GeoPosition(-48.516168, -27.5893828); //floripa
            else
                g = new GeoPosition(-50.1602621, -25.0971392); //ponta grossa
        }
        else
            g = new GeoPosition(-43.2121921, -22.9002596); // rio de janeiro


        return g;
    }
}

