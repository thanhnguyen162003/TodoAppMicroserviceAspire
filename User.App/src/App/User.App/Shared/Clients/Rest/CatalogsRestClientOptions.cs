using Shared.Resiliency.Options;

namespace User.App.Shared.Clients.Rest;

public class CatalogsRestClientOptions : HttpClientOptions
{
    public string CreateProductEndpoint { get; set; } = default!;
    public string GetProductByPageEndpoint { get; set; } = default!;
    public string GetProductByIdEndpoint { get; set; } = default!;
}