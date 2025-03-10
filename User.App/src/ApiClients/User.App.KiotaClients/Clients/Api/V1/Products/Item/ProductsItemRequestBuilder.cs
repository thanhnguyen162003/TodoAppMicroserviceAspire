// <auto-generated/>

#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using User.App.KiotaClients.Catalogs.Models;

namespace User.App.KiotaClients.Catalogs.Api.V1.Products.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \api\v1\products\{id}
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ProductsItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::User.App.KiotaClients.Catalogs.Api.V1.Products.Item.ProductsItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ProductsItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) :
            base(requestAdapter, "{+baseurl}/api/v1/products/{id}", pathParameters)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="global::User.App.KiotaClients.Catalogs.Api.V1.Products.Item.ProductsItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ProductsItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter,
            "{+baseurl}/api/v1/products/{id}", rawUrl)
        {
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <returns>A <see cref="global::User.App.KiotaClients.Catalogs.Models.GetProductByIdResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::User.App.KiotaClients.Catalogs.Models.HttpValidationProblemDetails">When receiving a 400 status code</exception>
        /// <exception cref="global::User.App.KiotaClients.Catalogs.Models.ProblemDetails">When receiving a 404 status code</exception>
        public async Task<global::User.App.KiotaClients.Catalogs.Models.GetProductByIdResponse> GetAsync(
            Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default,
            CancellationToken cancellationToken = default)
        {
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {
                    "400",
                    global::User.App.KiotaClients.Catalogs.Models.HttpValidationProblemDetails
                        .CreateFromDiscriminatorValue
                },
                { "404", global::User.App.KiotaClients.Catalogs.Models.ProblemDetails.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::User.App.KiotaClients.Catalogs.Models.GetProductByIdResponse>(
                requestInfo,
                global::User.App.KiotaClients.Catalogs.Models.GetProductByIdResponse.CreateFromDiscriminatorValue,
                errorMapping, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        public RequestInformation ToGetRequestInformation(
            Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }

        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::User.App.KiotaClients.Catalogs.Api.V1.Products.Item.ProductsItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::User.App.KiotaClients.Catalogs.Api.V1.Products.Item.ProductsItemRequestBuilder WithUrl(
            string rawUrl)
        {
            return new global::User.App.KiotaClients.Catalogs.Api.V1.Products.Item.ProductsItemRequestBuilder(rawUrl,
                RequestAdapter);
        }
    }
}
#pragma warning restore CS0618