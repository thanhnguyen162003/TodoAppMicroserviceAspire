using Riok.Mapperly.Abstractions;
using User.App.Products.Dtos.v1;
using User.App.Products.Features.CreatingProduct.v1;
using User.App.Products.Features.GettingProductById.v1;
using User.App.Products.Features.GettingProductsByPage.v1;
using User.App.Products.Models;
using User.App.Products.ReadModel;
using User.App.Shared.Clients.Dtos;

namespace User.App.Products;

// https://mapperly.riok.app/docs/configuration/static-mappers/
[Mapper]
internal static partial class ProductMappings
{
    internal static partial ProductReadModel ToProductReadModel(this Product product);

    internal static partial ProductDto ToProductDto(this ProductReadModel productReadModel);

    internal static partial Product ToProduct(this ProductDto productDto);

    internal static partial Product ToProduct(
        this User.App.KiotaClients.Catalogs.Models.ProductDto productDto
    );

    internal static partial Product ToProduct(
        this User.App.ConnectedServiceClients.Catalogs.ProductDto productDto
    );

    internal static partial CreateProduct ToCreateProduct(this CreateProductRequest createProductRequest);

    internal static partial Product ToProduct(this CreateProduct createProduct);

    internal static partial CreateProductResponse ToCreateProductResponse(this CreateProductResult createProductResult);

    internal static partial GetProductsByPage ToGetProductsByPage(
        this GetProductsByPageRequestParameters getProductsByPageRequestParameters
    );

    internal static partial GetProductsByPageResponse ToGetProductsByPageResponse(
        this GetProductsByPageResult getProductsByPageResult
    );

    internal static partial GetProductById ToGetProductById(
        this GetProductByIdRequestParameters getProductByIdRequestParameters
    );

    internal static partial GetProductByIdResponse ToGetProductByIdResponse(
        this GetProductByIdResult getProductByIdResult
    );

    internal static partial IList<Product> ToProducts(
        this ICollection<User.App.ConnectedServiceClients.Catalogs.ProductDto> getProductByIdResult
    );

    internal static partial IList<Product> ToProducts(
        this ICollection<User.App.KiotaClients.Catalogs.Models.ProductDto> getProductByIdResult
    );

    internal static partial IQueryable<ProductReadModel> ToProductsReadModel(this IQueryable<Product> products);

    internal static partial IEnumerable<Product> ToProducts(this IEnumerable<ProductClientDto> productsClientDto);

    internal static partial Product ToProduct(this ProductClientDto productClientDto);
}