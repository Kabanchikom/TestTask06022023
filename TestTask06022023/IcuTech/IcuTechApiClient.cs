using System.Xml;
using RestSharp;

namespace TestTask06022023.IcuTech;

public class IcuTechApiClient
{
    private readonly string _baseUrl;
    private static readonly string Ns1 = "http://www.w3.org/2003/05/soap-envelope";

    public IcuTechApiClient(IConfiguration configuration)
    {
        _baseUrl = configuration.GetSection("IcuTech:Url").Value;
    }

    public async Task<RestResponse?> Login(string username, string password, string ips)
    {
        var options = new RestClientOptions(_baseUrl) {
            ThrowOnAnyError = true,
            MaxTimeout = 1000
        };
    
        var client = new RestClient(options);
        client.Options.MaxTimeout = -1;
        
        var doc = new XmlDocument();
        var root = doc.AppendChild(doc.CreateElement("env", "Envelope", Ns1));
        var body = root.AppendChild(doc.CreateElement("env", "Body", ""));
        var login = body.AppendChild(doc.CreateElement("ns1", "Login", ""));

        login.AppendChild(doc.CreateElement("", "UserName", "")).InnerText = username;
        login.AppendChild(doc.CreateElement("", "Password", "")).InnerText = password;
        login.AppendChild(doc.CreateElement("", "IPs", "")).InnerText = ips;

        var request = new RestRequest()
            .AddHeader("Content-Type", "application/xml")
            .AddBody(doc.OuterXml);

        var response = await client.PostAsync(request);

        return response;
    }
}