using Shared.Abstractions.Core.Paging;
using Shared.Core.Exceptions;
using Shared.Core.Extensions;
using Shared.Core.Paging;
using User.App.KiotaClients.Catalogs;
using User.App.KiotaClients.Catalogs.Models;
using User.App.Products;
using User.App.Products.Models;
using User.App.Shared.Clients.Dtos;

namespace User.App.Shared.Clients.Kiota;

public class CatalogsKiotaClient(CatalogsKiotaApiClient catalogsKiotaApiClient) : ICatalogsKiotaClient
{
    public async Task<Guid> CreateProductAsync(
        CreateProductClientRequestDto createProductClientRequestDto,
        CancellationToken cancellationToken
    )
    {
        createProductClientRequestDto.NotBeNull();

        // resiliency using `Microsoft.Extensions.Http.Resilience`
        // https://learn.microsoft.com/en-us/dotnet/core/resilience/?tabs=dotnet-cli
        // https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience
        var createProductResponse = await catalogsKiotaApiClient.Api.V1.Products.PostAsync(
            new CreateProductRequest
            {
                Description = createProductClientRequestDto.Description,
                Name = createProductClientRequestDto.Name,
                Price = (double)createProductClientRequestDto.Price,
                CategoryId = createProductClientRequestDto.CategoryId,
                AdditionalData = new Dictionary<string, object>(),
            },
            cancellationToken: cancellationToken
        );

        if (createProductResponse?.Id == null)
        {
            throw new InvalidOperationException("The response did not contain a valid product ID.");
        }

        return createProductResponse.Id.Value;
    }

    public async Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        id.NotBeEmpty();

        // resiliency using `Microsoft.Extensions.Http.Resilience`
        // https://learn.microsoft.com/en-us/dotnet/core/resilience/?tabs=dotnet-cli
        // https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience
        var getProductByIdResponse = await catalogsKiotaApiClient
            .Api.V1.Products[id]
            .GetAsync(cancellationToken: cancellationToken);

        var product = getProductByIdResponse?.Product?.ToProduct();

        if (product is null)
            throw new NotFoundException($"product with id '{id}' not found");

        return product;
    }

    public async Task<IPageList<Product>> GetProductByPageAsync(
        GetProductsByPageClientRequestDto getProductsByPageClientRequestDto,
        CancellationToken cancellationToken
    )
    {
        getProductsByPageClientRequestDto.NotBeNull();

        // resiliency using `Microsoft.Extensions.Http.Resilience`
        // https://learn.microsoft.com/en-us/dotnet/core/resilience/?tabs=dotnet-cli
        // https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience
        var getProductsByPageResponse = await catalogsKiotaApiClient.Api.V1.Products.GetAsync(
            x =>
            {
                x.QueryParameters.PageNumber = getProductsByPageClientRequestDto.PageNumber;
                x.QueryParameters.PageSize = getProductsByPageClientRequestDto.PageSize;
            },
            cancellationToken
        );

        if (
            getProductsByPageResponse is null
            || getProductsByPageResponse.Products is null
            || getProductsByPageResponse.Products.Items is null
        )
            throw new Exception("products page list cannot be null");

        var items = getProductsByPageResponse.Products.Items.ToProducts();

        return PageList<Product>.Create(
            items.AsReadOnly(),
            getProductsByPageResponse.Products.PageNumber!.Value,
            getProductsByPageResponse.Products.PageSize!.Value,
            getProductsByPageResponse.Products.TotalCount!.Value
        );
    }
}