using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using User.App.Products.Features.CreatingProduct.v1;
using User.App.Products.Features.GettingProductById.v1;
using User.App.Products.Features.GettingProductsByPage.v1;
using User.App.Shared;

namespace User.App.Products;

internal static class ProductConfigurations
{
    public const string Tag = "Products";
    public const string ProductsPrefixUri = $"{CatalogsConfigurations.CatalogsPrefixUri}/products";

    public static WebApplicationBuilder AddProductsModuleServices(this WebApplicationBuilder builder)
    {
        return builder;
    }

    public static Task<WebApplication> UseProductsModule(this WebApplication app)
    {
        return Task.FromResult(app);
    }

    public static IEndpointRouteBuilder MapProductsModuleEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var products = endpoints.NewVersionedApi(Tag);
        var productsV1 = products.MapGroup(ProductsPrefixUri).HasDeprecatedApiVersion(0.9).HasApiVersion(1.0);

        productsV1.MapCreateProductEndpoint();
        productsV1.MapGetProductByIdEndpoint();
        productsV1.MapGetProductsByPageEndpoint();

        return endpoints;
    }
}