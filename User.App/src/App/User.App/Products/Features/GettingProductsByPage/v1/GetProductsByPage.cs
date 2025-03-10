using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.Core.CQRS;
using Shared.Abstractions.Core.Paging;
using Shared.Abstractions.Persistence.Ef;
using Shared.Core.Extensions;
using Shared.Core.Paging;
using Shared.Validation.Extensions;
using Sieve.Services;
using User.App.Products.Dtos.v1;
using User.App.Products.Models;
using User.App.Products.ReadModel;
using User.App.Shared.Data;

namespace User.App.Products.Features.GettingProductsByPage.v1;

public record GetProductsByPage : PageQuery<GetProductsByPageResult>
{
    /// <summary>
    /// GetProductById query with validation.
    /// </summary>
    /// <param name="pageRequest"></param>
    /// <returns></returns>
    public static GetProductsByPage Of(PageRequest pageRequest)
    {
        var (pageNumber, pageSize, filters, sortOrder) = pageRequest;

        return new GetProductsByPageValidator().HandleValidation(
            new GetProductsByPage
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filters = filters,
                SortOrder = sortOrder,
            }
        );
    }
}

public class GetProductsByPageValidator : AbstractValidator<GetProductsByPage>
{
    public GetProductsByPageValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page should at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize should at least greater than or equal to 1.");
    }
}

internal class GetProductByPageHandler(
    DbExecutors.GetProductsExecutor getProductsExecutor,
    ISieveProcessor sieveProcessor
) : IQueryHandler<GetProductsByPage, GetProductsByPageResult>
{
    public async ValueTask<GetProductsByPageResult> Handle(
        GetProductsByPage request,
        CancellationToken cancellationToken
    )
    {
        request.NotBeNull();

        var query = getProductsExecutor(cancellationToken);

        var pageList = await query.ApplyPagingAsync(
            pageRequest: request,
            sieveProcessor: sieveProcessor,
            projectionFunc: ProductMappings.ToProductsReadModel,
            sortExpression: x => x.Name,
            cancellationToken: cancellationToken
        );

        var result = pageList.MapTo<ProductDto>(ProductMappings.ToProductDto);

        return new GetProductsByPageResult(result);
    }
}

public record GetProductsByPageResult(IPageList<ProductDto> Products);

internal class DbExecutors : IDbExecutors
{
    // public delegate ValueTask CreateAndSaveProductExecutor(Product product, CancellationToken cancellationToken);
    public delegate IQueryable<Product> GetProductsExecutor(CancellationToken cancellationToken);

    public void Register(IServiceCollection services)
    {
        services.AddTransient<GetProductsExecutor>(sp =>
        {
            var context = sp.GetRequiredService<CatalogsDbContext>();

            IQueryable<Product> Query(CancellationToken cancellationToken)
            {
                var collection = context.Products.AsNoTracking();

                return collection;
            }

            return Query;
        });
    }
}