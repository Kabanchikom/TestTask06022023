using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TestTask06022023.IcuTech;

public class IcuTechService
{
    private readonly IcuTechApiClient _apiClient;

    public IcuTechService(IcuTechApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<string> Login(string username, string password)
    {
        var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
        
        var response = await _apiClient.Login(username, password, ip.ToString());

        if (response?.Content == null)
        {
            throw new NullReferenceException("Response content is null");
        }

        var xdoc = XDocument.Parse(response.Content);
        var json = xdoc.Descendants("return").First().Value;
    
        var result =  JObject.Parse(json);

        if (string.IsNullOrWhiteSpace(result.ToString()))
        {
            throw new NullReferenceException("Response content is null or empty");
        }

        if (!string.IsNullOrWhiteSpace(result["ResultCode"]?.ToString()) 
            && (!int.TryParse(result["ResultCode"]?.ToString(), out var resultCode) || resultCode == -1))
        {
            throw new UnauthorizedAccessException("Wrong login or password");
        }

        return json;
    }  
}