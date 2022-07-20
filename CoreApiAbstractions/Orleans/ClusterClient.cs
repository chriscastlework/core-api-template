using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

namespace CoreApiAbstractions.Orleans;

public class ClusterClient: IClient
{
    private IClusterClient Client { get; }
    
    public ClusterClient()
    {
        Client = ConnectClient().Result;
    }
    
    private static async Task<IClusterClient> ConnectClient()
    {
        var client = new ClientBuilder()
            .UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "OrleansBasics";
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .Build();

        await client.Connect();
        return client;
    }

    public IClusterClient GetClient()
    {
        return Client;
    }
}

public interface IClient
{
    IClusterClient GetClient();
}




